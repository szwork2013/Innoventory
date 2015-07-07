(function (inv) {
    var productController = function ($scope, $q, productService) {
        //var page = this;

        var pc = this;

        $scope.product = {};
        $scope.products = [];



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

        pc.onGetProductSuccess = function (result) {
            pc.products = result.products;

        };

        pc.onGetProductsError = function (err) {
            page.Error = err.errorMessage;
        };

        getProducts();

        return this;
    };

    inv.productController = productController;

}(window.Innoventory))