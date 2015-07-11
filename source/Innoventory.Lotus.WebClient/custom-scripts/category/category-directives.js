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

})()