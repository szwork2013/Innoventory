(function (inv) {

    var underscore = angular.module('underscore', []);

    underscore.factory('_', function () {
        return window._;
       
    });

    var commonModule = angular.module('common', ["_", 'ngRoute', 'ui.bootstrap']);

    var mainApp = angular.module("mainApp", ['common', "product-directives"]);

    mainApp.controller("productController", productController);

    mainApp.factory("productService", productService);

    mainApp.factory("innoventoryService", innoventoryService);



})(window.Innoventory)