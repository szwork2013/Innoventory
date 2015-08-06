﻿
(function (inv) {

    inv.emptyGuid = "00000000-0000-0000-0000-000000000000";

    var commonModule = angular.module('common', ['ngRoute', 'ui.bootstrap']);


    commonModule.constant("emptyGuid", "00000000-0000-0000-0000-000000000000");
    commonModule.factory('apiService', ['$http', '$q', '$timeout', function ($http, $q, $timeout) {
        return Innoventory.apiService($http, $q, $timeout);
    }]);

    
    var mainApp = angular.module("mainApp", ['common', 'innoventory-directives', 'ui.grid', 'ui.grid.selection']);

    mainApp.controller("productController", ["$scope", "$q", "productService", function ($scope, $q, productService) {

        Innoventory.productController($scope, $q, productService);

    }]);



    mainApp.factory("productService", ['$http', '$q', 'apiService', function ($http, $q, apiService) {
        return Innoventory.productService($http, $q, apiService);
    }]);


    var categoryModule = angular.module("categoryModule", ['common']);

    mainApp.controller("categoryController", ["$scope", "$q", "apiService", "$interval", 'uiGridConstants', function ($scope, $q, apiService, $interval, uiGridConstants) {
        Innoventory.categoryController($scope, $q, apiService, $interval, uiGridConstants);
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

    mainApp.controller("productAttributeController", ["$scope", "$q", "apiService", function ($scope, $q, apiService) {
        Innoventory.productAttributeController($scope, $q, apiService);
    }]);
       

}(window.Innoventory));