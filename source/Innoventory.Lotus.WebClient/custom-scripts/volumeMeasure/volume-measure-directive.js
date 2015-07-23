(function () {
    var app = angular.module('volumemeasure-directives', []);

    app.directive("volumemeasureList", function () {

        return {
            restrict: 'E',
            templateUrl: '../templates/volumemeasure/List.html'

        }

    });

    app.directive("volumemeasure", function () {
        return {
            restrict: 'E',
            templateUrl: '../templates/volumemeasure/VolumeMeasure.html'
        };
    });



 
})()