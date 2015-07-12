(function (inv) {
    var apiHelper = function ($http, $q) {

        var me = this;

        me.apiUrl = Innoventory.rootPath + 'api/'
        me.modelIsValid = true;

        me.errors = [];
        me.isLoading = false;
        me.hasErrors = false;

        me.apiGet = function (uri, data, success, failure, always) {

            
            me.isLoading = true;
            me.modelIsValid = true;
            me.hasErrors = false;

            $http.get(me.apiUrl + uri, data)
            .then(function (result) {

                showAlert(result.data);

                success(result.data);

                if (always != null) {
                    always();
                };

                me.isLoading = false;
            }, function (result) {

                me.hasErrors = true;

                if (failure == null) {

                    if (result.status == 404) {

                        me.errors = [result.status + ": Resource not found (Wrong Url mentioned)"];
                    }
                    else if (result.data.ErrorMessage) {
                        me.errors = [result.data.ErrorMessage];
                    }

                    else if (result.status != 400) {
                        me.errors = [result.status + ':' + result.message];
                    }
                    else {
                        me.errors = [result.message];
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

            });

        };

        me.apiDelete = function (uri, success, failure, always) {

            me.isLoading = true;
            me.modalIsValid = true;
            me.hasErrors = false;


            $http.delete(me.apiUrl + uri)
            .then(function (result) {
                showAlert(result.data);

                success(result.data);

                if (always != null) {
                    always();
                };

            }, function (result) {

                me.hasErrors = true;

                if (failure == null) {

                    if (result.status == 404) {

                        me.errors = [result.status + ": Resource not found (Wrong Url mentioned)"];
                    }
                    else if (result.data.ErrorMessage) {
                        me.errors = [result.data.ErrorMessage];
                    }

                    else if (result.status != 400) {
                        me.errors = [result.status + ':' + result.statusText];
                    }
                    else {
                        me.errors = [result.message];
                    };

                }
                else {
                    failure(result);

                };

                if (always != null) {
                    always();
                };

                me.isLoading = false;

            });
        };

        me.apiPost = function (uri, data, success, failure, always) {
            me.isLoading = true;
            me.modelIsValid = true;
            me.hasErrors = false;

            $http.post(me.apiUrl + uri, data)
            .then(function (result) {

                showAlert(result.data);

                success(result.data);

                if (always != null) {
                    always();
                };

                me.isLoading = false;
            }, function (result) {
                if (failure == null) {

                    if (result.status == 404) {

                        me.errors = [result.status + ": Resource not found (Wrong Url mentioned)"];
                    }
                    else if (result.data.ErrorMessage) {
                        me.errors = [result.data.ErrorMessage];
                    }

                    else if (result.status != 400) {
                        me.errors = [result.status + ':' + result.message];
                    }
                    else {
                        me.errors = [result.message];
                    };

                    me.hasErrors = true;

                }
                else {
                    failure(result);

                };

                if (always != null) {
                    always();
                };

                me.isLoading = false;


            });
        };

        showAlert = function (data) {
            if (data) {
                if (data && data.Success && data.SuccessMessage && data.SuccessMessage != "") {
                    me.hasSuccess = true;
                    me.successMessage = data.SuccessMessage;
                } else if(data.Success == false && data.ErrorMessage != "") {
                    me.hasErrors = true;
                    me.errors.push(data.ErrorMessage);
                };
            }
        };

        return me;


    };

    inv.apiHelper = apiHelper;

}(window.Innoventory))