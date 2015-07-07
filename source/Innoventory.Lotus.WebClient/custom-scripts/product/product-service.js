(function (inv) {
    var productService = function ($http, $q, viewModelHelper) {

        var ps = this;

        ps.product = {};
        ps.products = [];

        ps.getProducts = function () {

            //var url = innoventoryService.webApiBaseUrl;

            ps.product = { productName: "World|" };

            return ps.product;
        };


        // Product list
        

        return this;

    };

    inv.productService = productService;

})(window.Innoventory)