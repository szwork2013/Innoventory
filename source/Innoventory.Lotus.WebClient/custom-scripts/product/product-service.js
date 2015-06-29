
var productService = ["$http", 'innoventoryService', function () {

    var getProducts = function () {

        var url = innoventoryService.webApiBaseUrl;
               
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