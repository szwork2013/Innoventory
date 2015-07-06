
var productService = ["$http", function ($http) {

    var getProducts = function () {

        //var url = innoventoryService.webApiBaseUrl;
               
        service.product = { productName: "World|" };

        return service.product;
    };

    var service = {
        product: {},
        products: [], // Product list
        getProducts: getProducts,

    };

    return service;


}]