
var productController = ["$scope", "$q", "productService", function ($scope, $q, productService) {
    //var page = this;
    
    $scope.product = {};
    $scope.products = [];

    getProducts();

    function getProducts() {
        $scope.product = { productName: "World!" };
        

        //.then({
        //    success: function (result) {
        //        page.onGetProductsSuccess;
        //    },
        //    error: function (err) {
        //        page.onGetProductsError;
        //    }
        //});
    };

    $scope.onGetProductSuccess = function (result) {
        $scope.products = result.products;
        
    };

    $scope.onGetProductsError = function (err) {
        page.Error = err.errorMessage;
    };

    
    
}]