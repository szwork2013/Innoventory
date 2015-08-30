(function (inv) {
    var apiService = function ($http, $q, $timeout) {

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
                   
                    me.showSuccess(data.SuccessMessage);
                    
                } else if (data.Success == false && data.ErrorMessage != "") {
                    me.hasErrors = true;
                    me.errors.push(data.ErrorMessage);
                    $timeout(dismissAlert(), 3000);
                };
            }


        };


        me.showSuccess = function (message) {
            me.hasSuccess = true;
            me.successMessage = message;
            displayAlert();
        }

        displayAlert = function () {

            var alertBox = document.getElementById("alert-box");
            
            alertBox.style.opacity = 1;

            var w = window.innerWidth;
            var h = window.innerHeight;

            var dw = alertBox.offsetWidth;
            var dh = alertBox.offsetHeight;

            var x = w - 500 - 40;

            var y = h - 300 - 50;

            alertBox.style.position = "fixed";
            alertBox.style.right = 5 + "px";
            alertBox.style.bottom = 5 + "px";


            $timeout(dismissAlert, 6000);

        };

        me.showError = function (errors) {
                        
            me.hasErrors = true;
            me.errors = errors;
            displayAlert();
                                    
        }

        var dismissAlert = function () {
            document.getElementById("alert-box").style.opacity = 0;
            $timeout(cancelError, 2000);
            
        }

        var cancelError = function () {
            me.hasSuccess = false;
            me.successMessage = "";
            me.hasErrors = false;
            me.errors = [];
            //document.getElementById("error-alert").style.opacity = 1;
        }

        me.generateUUID = function(){
            var d = new Date().getTime();
            var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
                var r = (d + Math.random()*16)%16 | 0;
                d = Math.floor(d/16);
                return (c=='x' ? r : (r&0x3|0x8)).toString(16);
            });

            return uuid;
        }

        return me;


    };

    inv.apiService = apiService;

}(window.Innoventory))