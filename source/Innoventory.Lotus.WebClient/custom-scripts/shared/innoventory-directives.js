﻿(function () {
    var app = angular.module('innoventory-directives', []);

    app.directive("categoryList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/category/List.html'

        }

    });

    app.directive("category", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/category/Category.html'
        };
    });

    app.directive("subCategoryList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/sub-category/List.html'

        }

    });

    app.directive("subCategory", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/sub-category/SubCategory.html'
        };
    });

    app.directive("volumeMeasureList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/volume-measure/List.html'

        }

    });

    app.directive("volumeMeasure", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/volume-measure/VolumeMeasure.html'
        };
    });

    app.directive("productAttributeList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/product-attribute/List.html'

        }

    });

    app.directive("productAttribute", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/product-attribute/ProductAttribute.html'
        };
    });


    app.directive("purchaseOrderList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/purchaseorder/List.html'

        }

    });


    app.directive("purchaseOrder", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/purchaseorder/PurchaseOrder.html'
        };
    });


    app.directive("productList", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/product/List.html'
        };
    });

    app.directive("product", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/product/Product.html'
        };
    });

    app.directive("productVariantList", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/product-variant/List.html'
        };
    });

    app.directive("productVariant", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/product-variant/ProductVariant.html'
        };
    });

    app.directive("customerList", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/customer/List.html'
        };
    });

    app.directive("customer", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/customer/customer.html'
        };
    });


    app.directive("supplierList", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/supplier/List.html'
        };
    });

    app.directive("supplier", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/supplier/supplier.html'
        };
    });

})()