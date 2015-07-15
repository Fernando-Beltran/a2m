/*
 * @namespace A2M
 */
var A2M = A2M || {};
/**
 * Manejo de URLs para las peticiones
 * @namespace
 * @requires A2M.properties.js
 */
A2M.Request = {
	/**
	 * Debug mode.
	 * @type {boolean}
	 */
	debug: null,
	/**
	 * Default values.
	 * @readonly
	 * @type {Object}
	 */
	VALUES: {
		"EXAMPLE_REQUEST": "example/{0}/{1}", //example/{param1}/{param2}
	
	},
	/**
	 * Valores para desarrollo
	 * @readonly
	 * @type {Object}
	 */
	OVERRIDES: {
		// Desarrollo

	},
	/**
	 * Obtiene la propiedad por nombre
	 * @param {string} Nombre de la propiedad
	 * @returns {string|number|boolean}
	 */
	getRequest: function (key) {
		if (this.debug == null) {
		    this.debug = A2M.Properties.getProperty("debug." + this.CLASS_NAME);
		}
		var value = A2M.Request.OVERRIDES[key];
		if (value == null) {
		    value = A2M.Request.VALUES[key];
		}
		return value;
	},

	/**
    * Ejemplo
    * @returns peticion
    */
	example: function () {
	    var request = A2M.Request.getRequest("EXAMPLE_REQUEST");
		if (this.debug) console.log(this.CLASS_NAME + ": Request " + request);
		return request;
	},

	CLASS_NAME: "A2M.Request",
};

