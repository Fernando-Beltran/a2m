/*
 * @namespace
 */
var A2M = A2M || {};

/**
 * HTML5 LocalStorage / SessionStorage recubrimiento A2M
 *
 * @namespace
 * @requires A2M.cookie.js para fallback 
 */
A2M.Storage = {
	/**
	 * Retorna el valor especificado por la clave del localStorage
	 *
	 * @param {string} key El nombre de la clave
	 * @returns {string|number|boolean|object} El valor de la clave, o null si no existe o ha expirado
	 */
	getLocalItem: function (key) {
		return this.getItem("localStorage", key);
	},

	/**
	 * Retorna el valor especificado por la clave del sessionStorage
	 *
	 * @param {string} key El nombre de la clave
	 * @returns {string|number|boolean|object} El valor de la clave, o null si no existe o ha expirado
	 */
	getSessionItem: function (key) {
		return this.getItem("sessionStorage", key);
	},

	/**
	 * Retorna el objeto seleccionado por la clave
	 *
	 * @param {string} storageName
	 * @param {string} key
	 * @returns {string|number|boolean|object}
	 * @private
	 */
	getItem: function (storageName, key) {
		var storage = window[storageName];
		if (storage) {
			// Check item expiration
			var now = new Date().getTime();
			if (storage[key] != null) {
				try {
					var obj = JSON.parse(storage[key]);
					if (obj.expires == null || now <= obj.expires) {
						// Item found
						return obj.value;
					}
					else {
						// Item expired, remove it
						storage.removeItem(key);
					}
				}
				catch (err) {
					// Error parsing JSON
				}
			}
		}
		else if (A2M.Cookie.getCookie) {
		    return A2M.Cookie.getCookie(key);
		}
		return null;
	},

	/**
	 * Stores a value for the given key.
	 *
	 * @param {string} key The name of the key.
	 * @param {string|number|boolean|object} value The value to be stored for
	 *     the key.
	 * @param {number} max_age The value validity time in seconds.
	 */
	setLocalItem: function (key, value, maxAge) {
		this.setItem("localStorage", key, value, maxAge);
	},

	/**
	 * Stores a value for the given key.
	 *
	 * @param {string} key The name of the key.
	 * @param {string|number|boolean|object} value The value to be stored for
	 *     the key.
	 * @param {number} max_age The value validity time in seconds.
	 */
	setSessionItem: function (key, value, maxAge) {
		this.setItem("sessionStorage", key, value, maxAge);
	},

	/**
	 * Stores a value for the given key.
	 *
	 * @param {string} storageName
	 * @param {string} key
	 * @param {string|number|boolean|object} value
	 * @param {number} max_age
	 * @private
	 */
	setItem: function (storageName, key, value, maxAge) {
		var storage = window[storageName];
		if (storage) {
			// Persistent item with expiration
			var obj = {
				value: value,
				expires: maxAge ? new Date().getTime() + maxAge * 1000 : undefined
			};
			// Store item
			try {
				var json = JSON.stringify(obj);
				storage[key] = json;
			}
			catch (err) {
				// Error serializing JSON
			}
		}
		else if (A2M.Cookie.setCookie) {
			if (storageName == "sessionStorage") {
			    A2M.Cookie.setCookie(key, value, maxAge, "/");				// Volatile cookie
			}
			else {
				if (maxAge) {
				    A2M.Cookie.setCookie(key, value, maxAge, "/");			// Volatile cookie
				}
				else {
				    A2M.Cookie.setCookie(key, value, 10 * 365 * 24 * 3600, "/");	// "Persistent" cookie, for 10 years
				}
			}
		}
	},

	/**
	 * Deletes the stored value for the given key.
	 *
	 * @param {string} key The name of the key.
	 */
	deleteLocalItem: function (key) {
		this.deleteItem("localStorage", key);
	},

	/**
	 * Deletes the stored value for the given key.
	 *
	 * @param {string} key The name of the key.
	 */
	deleteSessionItem: function (key) {
		this.deleteItem("sessionStorage", key);
	},

	/**
	 * Deletes the stored value for the given key.
	 *
	 * @param {string} storageName
	 * @param {string} key
	 * @private
	 */
	deleteItem: function (storageName, key) {
		var storage = window[storageName];
		if (storage) {
			// Remove item
			storage.removeItem(key);
		}
		else if (A2M.Cookie.deleteCookie) {
		    A2M.Cookie.deleteCookie(key, "/");
		}
	},

	/**
	 * Deletes all expired values.
	 *
	 * @private
	 */
	cleanup: function () {
	    var self = A2M.Storage;

		var storage = window["localStorage"];
		if (storage) {
			for (var x = 0; x < storage.length; x++) {
				// Check item expiration, remove it if expoired
				var akey = storage.key(x);
				self.getItem(storage, akey);
			}
		}

		storage = window["sessionStorage"];
		if (storage) {
			for (var i = 0; i < storage.length; i++) {
				// Check item expiration, remove it if expoired
				var key = storage.key(i);
				self.getItem(storage, key);
			}
		}
	},

	CLASS_NAME: "A2M.Storage"
};

// Do a cleanup on load and on unload
A2M.Storage.cleanup();
if (window.addEventListener) {
    window.addEventListener('unload', A2M.Storage.cleanup, false);
}
else if (window.attachEvent) {
    window.attachEvent('onunload', A2M.Storage.cleanup);
}
