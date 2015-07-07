(function (inv) {
    var global = function () {

        var gl = this;
        gl.globals = {

            webApiBaseUrl: "http://localhost/api/v1/",

            apiUrl: inv.appConfig.ApiUrl,
            imageHost: inv.appConfig.ImageHost,

        };

        return this;
    };

    inv.global = global;

}(window.Innoventory));