/**
* Prototype y fallbacks globales
* @param {Array} args Argumentos del format
*/
String.prototype.format = function (args) {
	var s = this;
	for (var i = 0; i < arguments.length; i++) {
		var reg = new RegExp("\\{" + i + "\\}", "gm");
		s = s.replace(reg, arguments[i]);
	}
	return s;

};

if (typeof String.prototype.trim !== 'function') {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    }
}

String.prototype.format.regex = new RegExp("{-?[0-9]+}", "g");

/**
* Permite recuperar un número de decimales (sin redondeo)
* @param {Number} decimalPlaces Número de decimales
*/
Number.prototype.decimalPlacesNoRounding = function (decimalPlaces) {
	var str = this.toString(); //If it's not already a String
	if (str.indexOf(".") == -1) return str;
	str = str.slice(0, (str.indexOf(".")) + (decimalPlaces + 1)); //With 3 exposing the hundredths place
	return Number(str); //If you need it back as a Number
};

/**
* Parsea una cadena a formato teléfono xxx.xxx.xxx
* @param {String} phone Teléfono a enmascarar (ej 923123213)
* @returns {String} xxx.xxx.xxx
*/
String.prototype.toPhone = function () {
	var newValue = '';
	for (var i = 0; i < this.length; i++) {
		if (i % 3 == 0 && i != 0) {
			newValue += '.';
		}
		newValue += this[i];
	}
	return newValue;
};

/**
* Elimina elementos de un array
* @param {Number} from Desde el número de elemento
* @param {Number} top Hasta el número de elemento
*/
Array.prototype.remove = function (from, to) {
	var rest = this.slice((to || from) + 1 || this.length);
	this.length = from < 0 ? this.length + from : from;
	return this.push.apply(this, rest);
};

//Fallback para navegadores muy antiguos
if (typeof console === "undefined" || typeof console.log === "undefined") {
	console = {};
	console.log = function () { };
}

/**
 * @namespace A2M
 */
var A2M = A2M || {};

/**
 * Sección de utilidades y funciones comunes
 *
 * @namespace
 */
A2M.Utils = {
	/**
	* Permite sobreescribir un método
	*
	* @param {object} object Objeto del cual queremos sobreescribir la función
	* @param {methodName} methodName Método que sobreescribimos
	* @param {callback} callback callback
	*/
	override : function (object, methodName, callback) {
		object[methodName] = callback(object[methodName]);
	},

	after : function (extraBehavior) {
		return function(original) {
			return function() {
				var returnValue = original.apply(this, arguments);
				extraBehavior.apply(this, arguments);
				return returnValue;
			}
		}
	},

	/**
	 * Permite establecer tiempos de ejecución para cualquier función
	 * @param {function} original Función original sobre la que queremos establecer el benchmark	
	 */
	benchmark : function (original) {
		return function() {
			var startTime = new Date().getTime();
			var returnValue = original.apply(this, arguments);
			var finishTime = new Date().getTime();
			console.log('Benchmark - Took', finishTime - startTime, 'ms.');
			return returnValue;
		};
	},
	/**
	 * Completa con un número determinado de ceros un número.
	 *
	 * @param {Number} num Número
	 * @returns {Number} len Cantidad de ceros que deseamos
	 */
	fillWithZeros: function(num, len) {
		if (num.length < len) {
		    return A2M.Utils.fillWithZeros("0" + num, len);
		}
		return num;
	},
	/**
	* Obtiene los parametros de la URL y sus valores     
	* @param {String} varName Nombre del parámetro
	* @returns {String|false} Valor del parámetro o false si no existe
	* @example ?id=1&image=awesome.jpg A2M.Utils.getQueryVariable("image") retuns "awesome.jpg" 
	*/
	getQueryVariable: function(varName) {
		var query = window.location.search.substring(1);
		var vars = query.split("&");
		for (var i = 0; i < vars.length; i++) {
			var pair = vars[i].split("=");
			if (pair[0] == varName) {
				return pair[1];
			}
		}
		return(false);
	},
	/**
   * Retorna si existe un parámetro en la URL   
   * @param {String} varName Nombre del parámetro
   * @returns {true|false} Si existe o no ese parámetro en la URL
   * @example ?id=1&image=awesome.jpg A2M.Utils.getQueryVariable("image") retuns true 
   */
	haveQueryVariable: function(varName) {
		var query = window.location.search.substring(1);
		var vars = query.split("&");
		for (var i = 0; i < vars.length; i++) {
			var pair = vars[i].split("=");
			if (pair[0] == varName) {
				return true;
			}
		}
		return(false);
	},
	/**
	* Obtiene el path base, para rutas de iconos....
	*/
	getBasePath: function() {
		var pathArray = window.location.href.split('/');
		var protocol = pathArray[0];
		var host = pathArray[2];
		return protocol + '//' + host;
	},
	/**
	* Valida un email
	* @param {String} email Email a validar
	* @returns {Boolean} Si el email es válido sintácticamente
	*/
	validateEmail: function (email) {
		var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return re.test(email);
	},
	/**
	* Validar fecha (DD/MM/AAAA)
	* @param {String} dateStr - Fecha a validar
	* @returns {Boolean} Si la fecha es válida
	*/
	validateDate: function (dateStr) {
		var pattern = /^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$/;
		return pattern.test(dateStr);
	},
	/**
	* Validar telefono XXXXXXXXX
	* @param {String} phone - Teléfono a validar
	* @returns {Boolean} Si el teléfono es válido
	*/
	validatePhone: function (phone) {
		var pattern = /^([0-9])*$/;
		return pattern.test(phone);
		
	},
	/**
   * Valida un dni
   * @param {String} dni - dni a validar
   * @returns {Boolean} Si el dni es válido
   */
	validateDni : function(dni) {
		// Comprobamos si tiene longitud 9
		if (dni.length == 9) {
			// Extraemos los 8 primeros caracteres
			var numbersDni = dni.substring(0, 8);

			// Función que comprueba si un número es un
			// entero no negativo
			var isInteger = function (n) {
				var intRegex = /^\d+$/;
				if (intRegex.test(n)) return true;
				return false;
			}

			// Comprobamos si los 8 primeros caracteres
			// son números
			if (!isInteger(numbersDni)) return false;

			// Extraemos el último caracter
			var letterDni = dni.substring(8);

			// Función que hemos elaborado antes para
			// el cálculo de la letra
			var getLetterDni = function (dnip) {
				var table = "TRWAGMYFPDXBNJZSQVHLCKE";
				return table.charAt(dnip % 23);
			}

			// Calculamos la letra de las cifras que se
			// han introducido
			var letterCalculated = getLetterDni(numbersDni);

			// Si la letra es correcta damos por válido el DNI
			if (letterCalculated == letterDni) return true;
		}

		return false;

	},
	/**
	* Valida un NIE
	* @param {String} nie - Nie a validar
	* @returns {Boolean} Si el nie es válido
	*/
	validateNie : function(nie) {
		nie = nie.toUpperCase();

		// Basic format test
		if (!nie.match('((^[A-Z]{1}[0-9]{7}[A-Z0-9]{1}$|^[T]{1}[A-Z0-9]{8}$)|^[0-9]{8}[A-Z]{1}$)')) {
			return false;
		}

		// Test NIE
		//T
		if (/^[T]{1}/.test(nie)) {
			return (nie[8] === /^[T]{1}[A-Z0-9]{8}$/.test(nie));
		}

		//XYZ
		if (/^[XYZ]{1}/.test(nie)) {
			return (nie[8] === "TRWAGMYFPDXBNJZSQVHLCKE".charAt(nie.replace('X', '0')
		 .replace('Y', '1')
		 .replace('Z', '2')
		 .substring(0, 8) % 23));}

		return false;


	},
	/**
	* Valida un NIF
	* @param {String} nif - Nif a validar
	* @returns {Boolean} Si el nif es válido
	*/
	validateNif : function(nif) {
		nif = nif.toUpperCase();

		// Basic format test

		if (!nif.match('((^[A-Z]{1}[0-9]{7}[A-Z0-9]{1}$|^[T]{1}[A-Z0-9]{8}$)|^[0-9]{8}[A-Z]{1}$)')) {

			return false;
		}

		// Test NIF
		if (/^[0-9]{8}[A-Z]{1}$/.test(nif)) {
			return ("TRWAGMYFPDXBNJZSQVHLCKE".charAt(nif.substring(8, 0) % 23) === nif.charAt(8));
		}
		// Test specials NIF (starts with K, L or M)
		if (/^[KLM]{1}/.test(nif)) {
			return (nif[8] === String.fromCharCode(64));
		}

		return false;

	},
	/**
	* Valida la password del usuario en función de criterios
	* @param {String} password Contraseña a validar
	* @returns {Boolean} Si la contraseña es válida sintácticamente (mínimo 6 caracteres, sin espacios)
	*/
	validatePass : function(password) {
		var passRequisitesNoSpaces = "/^$|\s+/";
		var passRequisitesMinLength = /^.{6,}$/;
	}
}

/**
 * Función para llamar a una función pasado un número de tiempo establecido
 * @callback A2M.Utils.rateLimit~RateLimitCallback
 */

/**
 * Permite controlar la llamada y evitar un overflow de llamadas en eventos recurrentes (EJ scroll, mousemove)
 * Para llamar al evento una única vez (una fez finalizado el timeout)
 *
 * @param {string} id
 * @param {number} timeout
 * @param {UNLWorkshop.Utils.rateLimit~RateLimitCallback} callback
 * @param {Object} scope Context for the callback function.
 */
A2M.Utils.rateLimit = function (id, timeout, callback, scope) {
    if (A2M.Utils.rateLimitTimers[id] != null) {
        window.clearTimeout(A2M.Utils.rateLimitTimers[id]);
		A2M.Utils.rateLimitTimers[id] = null;
	}
	if (typeof callback == "function") {
	    A2M.Utils.rateLimitTimers[id] = window.setTimeout(function () {
			callback.apply(scope);
			A2M.Utils.rateLimitTimers[id] = null;
		}, timeout);
	}
};
/**
 * Control de timers necesarios para la función A2M.Utils.rateLimit 
 * @private
 * @type {Array.<string>}
 */
A2M.Utils.rateLimitTimers = [];

