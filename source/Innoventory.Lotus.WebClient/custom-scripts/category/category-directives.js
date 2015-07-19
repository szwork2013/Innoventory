(function () {
    var app = angular.module('category-directives', []);

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

})()