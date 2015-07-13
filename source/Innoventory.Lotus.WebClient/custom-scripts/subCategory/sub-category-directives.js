(function () {
    var app = angular.module('sub-category-directives', []);

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