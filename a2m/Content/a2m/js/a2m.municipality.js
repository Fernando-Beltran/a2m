/*
 * @namespace a2m
 */
var A2M = A2M || {};
// ReSharper disable MisuseOfOwnerFunctionThis
/**
 * Gestión de la home de municipios
 *
 * @class 
 * @constructor 
 * @requires jQuery.js
 * @requires a2m.properties.js
 * @requires a2m.utils.js
 * @requires a2m.request.js 
 * @requires a2m.enums.js 
 */
A2M.Municipality = function () {
    /** @property {boolean} debug - Muestra las trazas en la consola */
    this.debug = null;
    this.requestInProgress = false;

    /* DOM Links */
    this.$chkOnlineOrder = null;
    this.$chkOrderToHome = null;
    this.$chkPickupOrder = null;
    this.$chkReserves = null;
    this.$chkBrochurePdf = null;
    this.$chkMenu = null;
    /* / DOM Links */
    /**
    * Actualiza los resultados en función de los filtros
    */
    this.updateFilters = function () {

        A2M.Global.IsBusy = true;

        var request = A2M.Request.getRequest("GET_municipality_update_filters");
        var headers = {};
        var token = $('input[name="__RequestVerificationToken"]').val();
        headers['__RequestVerificationToken'] = token;
        var data = JSON.stringify({
            "Type": 1,
            "Sku": 2,
            "Description": 1
        });
        $.ajax({
            url: request,
            type: "POST",
            headers: headers,
            contentType: 'application/json; charset=utf-8',
            //data: data
        })
       .done(function (response) {           
           if (response) {
               switch (response.Status) {
                   case A2M.Enums.CommonRequestResponses.Ok:
                       if (this.debug) console.log(this.CLASS_NAME + ": updateFilters response ok");
                       break;
                   case A2M.Enums.CommonRequestResponses.NotAuthenticated:
                       if (this.debug) console.log(this.CLASS_NAME + ": updateFilters response NotAuthenticated");
                       break;
                   case A2M.Enums.CommonRequestResponses.Error:
                       if (this.debug) console.log(this.CLASS_NAME + ": updateFilters response Error");
                       break;
               }
                   
           }
       }.bind(this))
       .fail(function (response, textStatus, errorThrown) {
           if (this.debug) console.error(this.CLASS_NAME + ": updateFilters fail: " + response.responseText + "," + response.statusText + "," + errorThrown);
       }.bind(this))
       .always(function () {
           if (this.debug) console.log(this.CLASS_NAME + ": updateFilters always ");
           this.requestInProgress = false;
           
       }.bind(this));
    }
    /**
	 * Se generan los enlaces con los con los elementos del DOM
	 */
    this.bindDOMObjects = function () {
        this.$chkBrochurePdf = $("#chkBrochurePdf");
        this.$chkOrderToHome = $("#chkOrderToHome");
        this.$chkPickupOrder = $("#chkPickupOrder");
        this.$chkReserves = $("#chkReserves");
        this.$chkBrochurePdf = $("#chkBrochurePdf");
        this.$chkMenu = $("#chkMenu");
    };

    /**
    * Se generan los enlaces con los con los eventos de elementos del DOM
    */
    this.bindDOMEvents = function () {
        this.$chkBrochurePdf.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": chkBrochurePdf checked change");
            A2M_Municipality.updateFilters();
            if ($(this).is(":checked")) {            
                
            } else {
                
            }           
        });
        this.$chkOrderToHome.change(function () {
            if ($(this).is(":checked")) {

            } else {

            }
        });
        this.$chkPickupOrder.change(function () {
            if ($(this).is(":checked")) {

            } else {

            }
        });
        this.$chkReserves.change(function () {
            if ($(this).is(":checked")) {

            } else {

            }
        });
        this.$chkBrochurePdf.change(function () {
            if ($(this).is(":checked")) {

            } else {

            }
        });
        this.$chkMenu.change(function () {
            if ($(this).is(":checked")) {

            } else {

            }
        });
    };

    /**
	* Inicialización de la clase a2m Municipality Digital
	* @param {Function(result)} [qUnitCallback] callback - Callback para test qUnit
	* @param {Boolean} callback.result - Resultado del callback para wUnit
	*/
    this._init = function (qUnitCallback) {
        try {
            if (this.debug == null) {
                this.debug = A2M.Properties.getProperty("debug." + this.CLASS_NAME);
                if (this.debug) console.info(this.CLASS_NAME + ": Inicializada");
            }
            this.bindDOMObjects();
            this.bindDOMEvents();
            if (qUnitCallback != null) qUnitCallback(true);

        } catch (ex) {
            if (this.debug) console.error(this.CLASS_NAME + ": Init error" + ex.message);
            if (qUnitCallback != null) qUnitCallback(false);
        }
    };
    this.CLASS_NAME = "A2M.Municipality";
};
var A2M_Municipality = new A2M.Municipality(); //Se inicializa siempre el objeto;
// ReSharper restore MisuseOfOwnerFunctionThis