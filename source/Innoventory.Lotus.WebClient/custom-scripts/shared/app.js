
(function (inv) {

    inv.emptyGuid = "00000000-0000-0000-0000-000000000000";

    var commonModule = angular.module('common', ['ngRoute', 'ui.bootstrap']);


    commonModule.constant("emptyGuid", "00000000-0000-0000-0000-000000000000");
    commonModule.factory('apiService', ['$http', '$q', function ($http, $q) {
        return Innoventory.apiService($http, $q);
    }]);

    
    var mainApp = angular.module("mainApp", ['common', 'category-directives']);

    mainApp.controller("productController", ["$scope", "$q", "productService", function ($scope, $q, productService) {

        Innoventory.productController($scope, $q, productService);

    }]);



    mainApp.factory("productService", ['$http', '$q', 'apiService', function ($http, $q, apiService) {
        return Innoventory.productService($http, $q, apiService);
    }]);


    var categoryModule = angular.module("categoryModule", ['common']);

    mainApp.controller("categoryController", ["$scope", "$q", "apiService", function ($scope, $q, apiService) {
        Innoventory.categoryController($scope, $q, apiService);
    }]);


    mainApp.factory("categoryService", ['apiService', function (apiService) {
        return Innoventory.categoryService(apiService);
    }]);

    mainApp.controller("subCategoryController", ["$scope", "$q", "apiService", function ($scope, $q, apiService) {
        Innoventory.subCategoryController($scope, $q, apiService);
    }]);

    mainApp.controller("volumeMeasureController", ["$scope", "$q", "apiService", function ($scope, $q, apiService) {
        Innoventory.volumeMeasureController($scope, $q, apiService);
    }]);
       

}(window.Innoventory));