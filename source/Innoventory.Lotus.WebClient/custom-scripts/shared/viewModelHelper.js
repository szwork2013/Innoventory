(function (inv) { 
var viewModelHelper = ['$http', '$q', function ($http, $q) {

    var me = this;

    me.modelIsValid = true;

    me.modelErrors = [];
    me.isLoading = false;

    me.apiGet = function (uri, data, success, failure, always) {
        me.isLoading = true;
        me.modelIsValid = true;

        $http.get(Innoventory.appConfig.apiUrl + uri, data)
        .then(function (result) {
            success(result);

            if (always != null) {
                always();
            };

            me.isLoading = false;
        }, function (result) {
            if (failure == null) {
                if (result.status != 400) {
                    me.modelErrors = [result.status + ':' + result.data.message];
                }
                else {
                    me.modelErrors = [result.data.message];
                };

                me.modelIsValid = false;

            }
            else {
                failure(result);

            };

            if (always != null) {
                always();
            };

            me.isLoading = false;


        })

    }

    me.post = function (uri, data, success, failure, always) {
        me.isLoading = true;
        me.modelIsValid = true;

        $http.post(Innoventory.appConfig.apiUrl + uri, data)
        .then(function (result) {
            success(result);

            if (always != null) {
                always();
            };

            me.isLoading = false;
        }, function (result) {
            if (failure == null) {
                if (result.status != 400) {
                    me.modelErrors = [result.status + ':' + result.data.message];
                }
                else {
                    me.modelErrors = [result.data.message];
                };

                me.modelIsValid = false;

            }
            else {
                failure(result);

            };

            if (always != null) {
                always();
            };

            me.isLoading = false;


        })
    };

    return me;
       

}];

inv.viewModelHelper = viewModelHelper;

})(window.Innoventory)