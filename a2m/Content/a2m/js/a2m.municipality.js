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
    * Actualiza el botónde paginación con los resultados    
    * @param {Number} totalResults Número total de resultados
    * @param {Number} currentPageSize Número total de página
    * @param {Number} currentPage Página actual
    */
    this.updatePaginateButton = function (totalResults,currentPageSize,currentPage) {
        var buttonResultText = "<span>Ver los siguientes {0} resultados de {0}";
        var buttonNoResultText = "No hay más resultados.";
        $(this.$btnPaginate).data("currentPage",currentPage);
        var pending = currentPageSize * currentPage;
        if (totalResults > pending) {
            if ($(this.$btnPaginate).hasClass("btn-nomore-result")) {
                $(this.$btnPaginate).removeClass("btn-nomore-result");
            }
            if (!$(this.$btnPaginate).hasClass("btn-more-result")) {
                $(this.$btnPaginate).addClass("btn-more-result");
            }
            $(this.$btnPaginate).html(buttonResultText.format("a", "v"));
        } else {
            if (!$(this.$btnPaginate).hasClass("btn-nomore-result")) {
                $(this.$btnPaginate).addClass("btn-nomore-result");
            }
            if ($(this.$btnPaginate).hasClass("btn-more-result")) {
                $(this.$btnPaginate).removeClass("btn-more-result");
            }
            $(this.$btnPaginate).html(buttonNoResultText);
        }
    }
    /**
    * Actualiza los resultados en función de los filtros
    * @param {Number} page Número de página
    * @param {Boolean} clean Si tiene que limpiar resultados, por cambio de filtros o solo suma paginación
    */
    this.updateFilters = function (page,clean) {
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
            "CurrentMunicipality": this.currenMunicipality,
            "CurrentPage" : page
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
                       if (clean) {
                           $(this.$municipalityRenderDiv).html("");
                       }
                       $(this.$municipalityRenderDiv).append(response.ResultHtmlView);
                       this.updatePaginateButton(response.PageSize, response.PageSize, response.NextPage);
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

        this.$btnPaginate.click(function (evt) {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $btnPaginate click");
            var currentPage = $(evt.currentTarget).data("currentPage")
            A2M_Municipality.updateFilters(currentPage++,false); //Avanzamos página
        });

        this.$checkFilterList.click(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": image of checkbox change");
            var item = $(this).find("input[type='checkbox']");
            if (item.is(":checked")) {
                item.prop("checked", false);
            } else {
                item.prop("checked", true);
            }
            //A2M_Municipality.updateFilters(0,true);//Reseteamos a la página uno cada vez que cambiamos filtros
        });

        this.$chkOrderToHome.change(function () {           
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $chkOrderToHome checked change");
            if ($(this).is(":checked")) {
                $(this).prop("checked", false);
            } else {
                $(this).prop("checked", true);
            }
            A2M_Municipality.updateFilters(0, true);
         
        });        
        this.$chkBrochurePdf.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": chkBrochurePdf checked change");
            if ($(this).is(":checked")) {
                $(this).prop("checked", false);
            } else {
                $(this).prop("checked", true);
            }
            A2M_Municipality.updateFilters(0, true);
                 
        });
        this.$chkOnlineOrder.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $chkOnlineOrder checked change");
            if ($(this).is(":checked")) {
                $(this).prop("checked", false);
            } else {
                $(this).prop("checked", true);
            }
            A2M_Municipality.updateFilters(0, true);
       
        });
        this.$chkPickupOrder.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $chkPickupOrder checked change");
            if ($(this).is(":checked")) {
                $(this).prop("checked", false);
            } else {
                $(this).prop("checked", true);
            }
            A2M_Municipality.updateFilters(0, true);
           
        });
        this.$chkReserves.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $chkReserves checked change");
            if ($(this).is(":checked")) {
                $(this).prop("checked", false);
            } else {
                $(this).prop("checked", true);
            }
            A2M_Municipality.updateFilters(0, true);
          
        });
      
        this.$chkMenu.change(function () {
            if (A2M_Municipality.debug) console.log(A2M_Municipality.CLASS_NAME + ": $chkMenu checked change");
            if ($(this).is(":checked")) {
                $(this).prop("checked", false);
            } else {
                $(this).prop("checked", true);
            }
            A2M_Municipality.updateFilters(0, true);
           
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