(function () {

    var underscore = angular.module('underscore', []);
    underscore.factory('_', function () {
        return window._;
    });

    var innoventoryApp = angular.module("innoventoryApp", ["_", "product-directives"]);

    innoventoryApp.controller("productController", productController);

    innoventoryApp.factory("productService", productService);

    innoventoryApp.factory("innoventoryService", innoventoryService);

   

})()