(function (inv) {
    var global = function () {
        var globals = {

            webApiBaseUrl: "http://localhost/api/v1/",

            apiUrl: inv.appConfig.ApiUrl,
            imageHost: inv.appConfig.ImageHost,

        };

        return globals;
    };

    inv.global = global;

}(window.Innoventory));