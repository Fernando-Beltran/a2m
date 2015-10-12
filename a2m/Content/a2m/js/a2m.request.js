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
	 * Api path
	 * @type {boolean}
	 */
    apiPath: "api",
    /**
	 * Aplication path
	 * @type {boolean}
	 */
    appPath: "a2m",
	/**
	 * Default values.
	 * @readonly
	 * @type {Object}
	 */
	VALUES: {
	    "GET_municipality_update_filters": "GET_municipality_update_filters", //Actualiza los filtros de los resultados de municipios
	    "GET_municipality_get_results": "GET_municipality_get_results" //Obtiene los resultados por página
	
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
		return A2M.Utils.getBasePath() + "/" + this.appPath + "/" + value;
	},
    /**
	 * Obtiene la propiedad por nombre
	 * @param {string} Nombre de la propiedad
	 * @returns {string|number|boolean}
	 */
	getApiRequest: function (key) {
	    if (this.debug == null) {
	        this.debug = A2M.Properties.getProperty("debug." + this.CLASS_NAME);
	    }
	    var value = A2M.Request.OVERRIDES[key];
	    if (value == null) {
	        value = A2M.Request.VALUES[key];
	    }
	    return A2M.Utils.getBasePath() + "/" + this.apiPath + "/" + value;
	},

	CLASS_NAME: "A2M.Request",
};

