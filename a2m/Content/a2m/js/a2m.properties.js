/*
 * @namespace A2M
 */
var A2M = A2M || {};

/**
 * Configuracion de propiedades
 *
 * @namespace
 */
A2M.Properties = {
	/**
	 * Valores por defecto
	 *
	 * @readonly
	 * @type {Object}
	 */
	VALUES: {
	    /** @description Versión del API javascript */
		"app.version": "1.0.0",
	    /** @description Timeout para las peticiones por defecto (ajax)*/
		"default.network.timeout": 10000,		
	},
	/**
	 * Valores de desarrollo 
	 *
	 * @readonly
	 * @type {Object}
	 */
	DEBUG: {
		// Debug settings		
	    "debug.A2M.Municipality": true,
	    "debug.A2M.Request": true,		
	},
	/**
	 * Obtiene el valor de la propiedad por nombre
	 *
	 * @param {string} key Nombre de la propiedad
	 * @returns {string|number|boolean}
	 */
	getProperty: function (key) {
	    var value = A2M.Properties.DEBUG[key];
		if (value == null) {
		    value = A2M.Properties.VALUES[key];
		}
		return value;
	}
};
