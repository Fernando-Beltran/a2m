/*
 * @namespace A2M
 */
var A2M = A2M || {};


/**
 * Clase para el manejo de cookies
 *
 * @namespace
 */
A2M.Cookie = {
	/**
	 * Crea y maneja las cookies de la página
	 *
	 * Se requieren los dos primeros parámetros . Los otros, si se suministra , debe
     * Pasarse en el orden indicado anteriormente. Para omitir un campo opcional no utilizada ,
     * Utilizar nulo como un marcador de posición . Por ejemplo, para llamar setCookie utilizando el nombre ,
     * El valor y la ruta , que serían código:
	 *
	 *     setCookie ("myCookieName", "myCookieValue", null, "/");
	 *
	 * Note that trailing omitted parameters do not require a placeholder.
	 *
	 * To set a secure cookie for path "/myPath", that expires after the
	 * current session, you might code:
	 *
	 *     setCookie (myCookieVar, cookieValueVar, null, "/myPath", null, true);
	 *
	 * @param {string} name String object containing the cookie name.
	 * @param {string} value String object containing the cookie value. May
	 *     contain any valid string characters.
	 * @param {Date} expires Date object containing the expiration date of the
	 *     cookie. If omitted or null, expires the cookie at the end of the
	 *     current session.
	 * @param {string} path String object indicating the path for which the
	 *     cookie is valid. If omitted or null, uses the path of the calling
	 *     document.
	 * @param {string} domain String object indicating the domain for which the
	 *     cookie is valid. If omitted or null, uses the domain of the calling
	 *     document.
	 * @param {boolean} secure Boolean value indicating whether cookie
	 *     transmission requires a secure channel (HTTPS).
	 */
	setCookie: function (name, value, maxAge, path, domain, secure) {
		if (value == null) {
		    A2M.Cookie.deleteCookie(name, path, domain);
			return;
		}
		// Instead of providing expires, we calculate it from max_age and set both
		var expires = null;
		if (maxAge) {
			expires = new Date();
			expires.setTime(expires.getTime() + maxAge * 1000);
		}
		document.cookie = name + "=" + escape(value) +
			((maxAge) ? "; max-age=" + maxAge : "") +
			((expires) ? "; expires=" + expires.toGMTString() : "") +
			((path) ? "; path=" + path : "") +
			((domain) ? "; domain=" + domain : "") +
			((secure) ? "; secure" : "");
	},

	/**
	 * Return the value of the cookie specified by name.
	 *
	 * @param {string} name The cookie name.
	 * @return {string} The cookie value, or null if the cookie does not exist.
	 */
	getCookie: function (name) {
		var arg = name + "=";
		var alen = arg.length;
		var clen = document.cookie.length;
		var i = 0;
		while (i < clen) {
			var j = i + alen;
			if (document.cookie.substring(i, j) == arg) {
			    return A2M.Cookie._getCookie(j);
			}
			i = document.cookie.indexOf(" ", i) + 1;
			if (i == 0) {
				break;
			}
		}
		return null;
	},

	/**
	 * Function to correct for 2.x Mac date bug. Call this function to fix a
	 * date object prior to passing it to setCookie.
	 * IMPORTANT: This function should only be called *once* for any given date
	 * object! See example at the end of this document.
	 *
	 * @param {Date} date
	 */
	fixCookieDate: function (date) {
		var base = new Date(0);
		var skew = base.getTime();	// Dawn of (Unix) time - should be 0
		if (skew > 0) {				// except on the Mac - ahead of its time
			date.setTime(date.getTime() - skew);
		}
	},

	/**
	 * Delete a cookie (sets expiration date to start of epoch).
	 *
	 * @param {string} name String object containing the cookie name.
	 * @param {string} path String object containing the path of the cookie to
	 *     delete. This MUST be the same as the path used to create the cookie,
	 *     or null/omitted if no path was specified when creating the cookie.
	 * @param {string} domain String object containing the domain of the cookie
	 *     to delete. This MUST be the same as the domain used to create the
	 *     cookie, or null/omitted if no domain was specified when creating the
	 *     cookie.
	 */
	deleteCookie: function (name, path, domain) {
	    if (A2M.Cookie.getCookie(name)) {
			document.cookie = name + "=" +
				((path) ? "; path=" + path : "") +
				((domain) ? "; domain=" + domain : "") +
				"; max-age=0";
		}
	},

	/**
	 * Return the decoded value of a cookie.
	 *
	 * @private
	 * @param {number} offset
	 * @returns {string}
	 */
	_getCookie: function (offset) {
		var endstr = document.cookie.indexOf(";", offset);
		if (endstr == -1) {
			endstr = document.cookie.length;
		}
		return unescape(document.cookie.substring(offset, endstr));
	},

	CLASS_NAME: "A2M.Cookie"
};
