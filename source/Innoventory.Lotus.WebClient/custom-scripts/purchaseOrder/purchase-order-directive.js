(function () {
    var app = angular.module('purchaseorder-directives', []);

    app.directive("purchaseorderList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/purchaseorder/List.html'

        }

    });

    app.directive("purchaseorder", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/purchaseorder/PurchaseOrder.html'
        };
    });




})()