var A2M = A2M || {};
A2M.Enums = A2M.Enums || {};
/** @namespace a2m.Enums */

/**
 * Enum Tipos de respuestas genéricas para todas las peticiones
 * @readonly
 * @enum {Number}
 */
A2M.Enums.CommonRequestResponses = {
    /** @description Respuesta correcta*/
    "Ok": 0,
    /** @description Usuario no logado*/
    "NotAuthenticated": 1,
    /** @description Error*/
    "Error": 2
}