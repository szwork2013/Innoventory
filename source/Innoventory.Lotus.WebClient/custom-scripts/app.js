(function () {

    var underscore = angular.module('underscore', []);
    underscore.factory('_', function () {
        return window._;
    });

    var commonModule = angular.module('common', ["_", 'ngRoute', 'ui.bootstrap']);

    var innoventoryApp = angular.module("innoventoryApp", ['common', "product-directives"]);

    innoventoryApp.controller("productController", productController);

    innoventoryApp.factory("productService", productService);

    innoventoryApp.factory("innoventoryService", innoventoryService);
      

})()