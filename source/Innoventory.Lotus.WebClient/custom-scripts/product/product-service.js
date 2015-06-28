
var productService = ["$http", function () {

    

    var getProducts = function () {

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