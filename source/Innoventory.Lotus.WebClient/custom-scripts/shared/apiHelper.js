(function (inv) {
    var apiHelper = function ($http, $q) {

        var me = this;


        me.modelIsValid = true;

        me.errors = [];
        me.isLoading = false;

        me.apiGet = function (uri, data, success, failure, always) {
            me.isLoading = true;
            me.modelIsValid = true;

            $http.get(Innoventory.rootPath + uri, data)
            .then(function (result) {

                showAlert(result.data);

                success(result);

                if (always != null) {
                    always();
                };

                me.isLoading = false;
            }, function (result) {

                me.hasErrors = true;

                if (failure == null) {
                    if (result.status != 400) {
                        me.errors = [result.status + ':' + result.data.message];
                    }
                    else {
                        me.errors = [result.data.ErrorMessage];
                    };
                }
                else {

                    me.errors = [result.data.ErrorMessage];
                    failure(result);

                };

                if (always != null) {
                    always();
                };

                me.isLoading = false;

            })

        }

        me.apiPost = function (uri, data, success, failure, always) {
            me.isLoading = true;
            me.modelIsValid = true;

            $http.post(Innoventory.appConfig.apiUrl + uri, data)
            .then(function (result) {

                showAlert(result.data);

                success(result);

                if (always != null) {
                    always();
                };

                me.isLoading = false;
            }, function (result) {
                if (failure == null) {
                    if (result.status != 400) {
                        me.errors = [result.status + ':' + result.data.message];
                    }
                    else {
                        me.errors = [result.data.message];
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

        showAlert = function (data) {
            if (data) {
                if (data && data.Success) {
                    me.hasSuccess = true;
                    me.successMessage = result.data.SuccessMessage;
                } else {
                    me.hasErrors = true;
                    me.errors.push(result.data.ErrorMessage);
                };
            }
        };

        return me;


    };

    inv.apiHelper = apiHelper;

}(window.Innoventory))