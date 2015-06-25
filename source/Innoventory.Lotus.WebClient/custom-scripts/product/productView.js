(function () {

    var innoventoryApp = angular.module('product-directives', []);

    innoventoryApp.directive("productDetail", function () {
        return {
            restrict: 'E',
            tmplateUrl: '../templates/product-detail.html'
        }

    });

})();