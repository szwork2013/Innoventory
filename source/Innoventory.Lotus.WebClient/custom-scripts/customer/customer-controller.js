(function (inv) {

    var customerController = function ($scope, $q, apiService) {

        var me = this;

        $scope.apiService = apiService;

        paginationOptions = {
            pageSize: 10,
            pageNumber: 1,
        }

        $scope.customerVM = {};
        $scope.searchString = "";

        $scope.gridOptions = {
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            enableColumnResizing: true,
            enableGridMenu: true,
            enableSorting: true,
            enableHorizontalScrollbar: 1,
            enableVerticalScrollbar: 0,
            enablePaging: true,
            paginationPageSizes: [10, 20, 30],
            paginationPageSize: paginationOptions.pageSize,


            columnDefs: [

                { field: 'customerName', displayName: 'Customer Name', width: "30%" },
                { field: 'customerContactNo', displayName: 'Contact No', width: "30%" },
                { field: 'customerEmailId', displayName: 'Email', width: "40%" },


            ]
        };

        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $scope.editCustomer(row.entity.customerId);
            });

            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                $scope.gridOptions.paginationOptions.pageNumber = newPage;
                $scope.gridOptions.paginationOptions.pageSize = pageSize;
                onCancel();
                $scope.tableStyle = getTableStyle($scope.gridOptions, $scope.gridApi);

            });
        };

        $scope.newCustomer = function () {

            $scope.showCustomer = true;
            $scope.showDelete = false;

            $scope.formTitle = "New Customer";
            $scope.customerVM = new Innoventory.customerModel();

        }


        $scope.searchCustomers = function (e) {

            e.preventDefault();

            onSearchCustomers();

        }

        onSearchCustomers = function () {

            if (!$scope.searchString) {
                $scope.searchString = "";
            };

            var url = "customer/search/" + $scope.searchString;

            apiService.apiGet(url, {}, function (result) {

                if (result.Entities && result.Entities.length > 0) {

                    $scope.gridOptions.data = result.Entities;
                    $scope.isData = true;

                }
                else {

                    $scope.isData = false;
                }

                $scope.tableStyle = apiService.getTableStyle($scope.gridOptions, $scope.gridApi);

            });

        }

        $scope.editCustomer = function (customerId) {

            var url = "customer/getCustomer/" + customerId;

            apiService.apiGet(url, {}, function (result) {

                if (result.Entity) {

                    $scope.customerVM = result.Entity;
                    $scope.showDelete = true;
                    $scope.showCustomer = true;
                    $scope.formTitle = "Edit Customer";

                };

            });
        }

        $scope.deleteCustomer = function (e) {

            e.preventDefault();

            onDelete();

        }

        onDelete = function () {



        }

        $scope.saveCustomer = function (e) {

            e.preventDefault();

            onSaveCustomer();

        }

        onSaveCustomer = function () {

            var customer = angular.copy($scope.customerVM);
            var hasErrors = false;
            var errors = [];

            if (!(customer.customerName && customer.customerName != "")) {

                hasErrors = true;
                errors.push("Customer Name can not be empty");

            };

            if (!(customer.customerContactNo && customer.customerContactNo != "")) {

                hasErrors = true;
                errors.push("Customer Contact No can not be empty");

            };

            if (hasErrors) {
                apiService.showError(errors);
                return;
            }

            var url = "customer/save";

            if (customer.customerId == null) {

                customer.customerId = Innoventory.emptyGuid;
            }


            apiService.apiPost(url, customer, function (result) {

                if (result.Success) {

                    $scope.showCustomer = false;
                    $scope.customerVM = null;

                    onSearchCustomers();

                };

            });

        }

        $scope.cancel = function (e) {

            e.preventDefault();

            onCancel();

        }

        onCancel = function () {

            $scope.showCustomer = false;
            $scope.showDelete = false;

            $scope.formTitle = "";
            $scope.customerVM = null;

        }

        onSearchCustomers();

        return this;

    }

    inv.customerController = customerController;

})(window.Innoventory)