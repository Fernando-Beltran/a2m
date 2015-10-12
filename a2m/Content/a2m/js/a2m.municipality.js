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
    /** @property {boolean} requestInProgress - Si hay petición en curso */
    this.requestInProgress = false;
    /** @property {String} requestInProgress - Si hay petición en curso */
    this.currenMunicipality;
    this.business;

    /* DOM Links */
    this.$chkOnlineOrder = null;
    this.$chkOrderToHome = null;
    this.$chkPickupOrder = null;
    this.$chkReserves = null;
    this.$chkBrochurePdf = null;
    this.$chkMenu = null;
    this.$municipalityRenderDiv = null;
    this.$loader = null;
    this.$checkFilterList = null;
    this.$btnPaginate = null;
    /* / DOM Links */
    /**
    * Actualiza los resultados en función de los filtros
    * @param {Number} page Número de página
    */
    this.updateFilters = function (page) {
        if (this.debug) console.log(this.CLASS_NAME + ": updateFilters");
        A2M.Global.IsBusy = true;
        this.$loader.removeClass("hide");
        var request = A2M.Request.getApiRequest("GET_municipality_update_filters");
        var headers = {};
        var token = $('input[name="__RequestVerificationToken"]').val();
        headers['__RequestVerificationToken'] = token;

        var IsOnlineOrder = this.$chkOnlineOrder.is(":checked");
        var IsOrderToPickup = this.$chkPickupOrder.is(":checked");
        var IsReserve = this.$chkReserves.is(":checked");
        var IsBrochure = this.$chkBrochurePdf.is(":checked");
        var IsDiaryMenu = this.$chkMenu.is(":checked");
        var IsOrderToHome = this.$chkOrderToHome.is(":checked");
   

        var data = JSON.stringify({            
            "IsOnlineOrder": IsOnlineOrder,
            "IsOrderToHome" : IsOrderToHome,
            "IsOrderToPickup": IsOrderToPickup,
            "IsReserve": IsReserve,
            "IsBrochure": IsBrochure,
            "IsDiaryMenu": IsDiaryMenu,
            "CurrentMunicipality": this.currenMunicipality
        });
        $.ajax({
            url: request,
            type: "POST",
            headers: headers,
            contentType: 'application/json; charset=utf-8',
            data: data
        })
       .done(function (response) {           
           if (response) {
               switch (response.Status) {
                   case A2M.Enums.CommonRequestResponses.Ok:
                       if (this.debug) console.log(this.CLASS_NAME + ": updateFilters response ok");
                       this.$municipalityRenderDiv.html(response.ResultHtmlView);

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
           this.$loader.addClass("hide");
       }.bind(this));
    }
    /**
	 * Se generan los enlaces con los con los elementos del DOM
	 */
    this.bindDOMObjects = function () {
        this.$chkOrderToHome = $("#chkOrderToHome");
        this.$chkBrochurePdf = $("#chkBrochurePdf");
        this.$chkOnlineOrder = $("#chkOnlineOrder");
        this.$chkPickupOrder = $("#chkPickupOrder");
        this.$chkReserves = $("#chkReserves");
        this.$chkBrochurePdf = $("#chkBrochurePdf");
        this.$chkMenu = $("#chkMenu");
        this.$municipalityRenderDiv = $("#municipalityRenderDiv");
        this.$loader = $("#loader");
        this.$btnPaginate = $("#btnPaginate");
        this.$checkFilterList = $(".check-filter");
    };

    /**
    * Se generan los enlaces con los con los eventos de elementos del DOM
    */
    this.bindDOMEvents = function () {

        this.$btnPaginate(function (evt) {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $btnPaginate click");
            var currentPage = $(evt.currenTarget).data("currentPage")
            A2M_Municipality.updateFilters(currentPage++); //Avanzamos página
        });

        this.$checkFilterList.click(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": image of checkbox change");
            var item = $(this).find("input[type='checkbox']");
            if (item.is(":checked")) {
                item.prop("checked", false);
            } else {
                item.prop("checked", true);
            }
        });

        this.$chkOrderToHome.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $chkOrderToHome checked change");
            A2M_Municipality.updateFilters(1);
         
        });        
        this.$chkBrochurePdf.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": chkBrochurePdf checked change");
            A2M_Municipality.updateFilters(1);
                 
        });
        this.$chkOnlineOrder.change(function () {
            A2M_Municipality.updateFilters(1);
       
        });
        this.$chkPickupOrder.change(function () {
            A2M_Municipality.updateFilters(1);
           
        });
        this.$chkReserves.change(function () {
            A2M_Municipality.updateFilters(1);
          
        });
        this.$chkBrochurePdf.change(function () {
            A2M_Municipality.updateFilters(1);
           
        });
        this.$chkMenu.change(function () {
            A2M_Municipality.updateFilters(1);
           
        });
    };

    /**
	* Inicialización de la clase a2m Municipality Digital
    * @param {String} currenMunicipality - Municipio actual
	* @param {Function(result)} [qUnitCallback] callback - Callback para test qUnit
	* @param {Boolean} callback.result - Resultado del callback para wUnit
	*/
    this._init = function (currenMunicipality,qUnitCallback) {
        try {
            if (this.debug == null) {
                this.debug = A2M.Properties.getProperty("debug." + this.CLASS_NAME);
                if (this.debug) console.info(this.CLASS_NAME + ": Inicializada");
            }
            this.currenMunicipality = currenMunicipality;
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