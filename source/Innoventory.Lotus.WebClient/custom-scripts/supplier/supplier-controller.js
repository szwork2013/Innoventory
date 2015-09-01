(function (inv) {

    var supplierController = function ($scope, $q, apiService) {

        var me = this;

        $scope.apiService = apiService;

        paginationOptions = {
            pageSize: 10,
            pageNumber: 1,
        }

        $scope.supplierVM = {};
        $scope.searchString = "";

        $scope.gridOptions = {
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            enableColumnResizing: true,
            enableGridMenu: true,
            enableSorting: true,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enablePaging: true,
            paginationPageSizes: [10, 20, 30],
            paginationPageSize: paginationOptions.pageSize,

            columnDefs: [

                { field: 'supplierName', displayName: 'Supplier Name', width: "30%" },
                { field: 'supplierContactNo', displayName: 'Contact No', width: "30%" },
                { field: 'supplierEmailId', displayName: 'Email', width: "40%" },


            ]
        };

        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $scope.editSupplier(row.entity.supplierId);
            });

            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                $scope.gridOptions.paginationOptions.pageNumber = newPage;
                $scope.gridOptions.paginationOptions.pageSize = pageSize;
                onCancel();
                $scope.tableStyle = getTableStyle($scope.gridOptions, $scope.gridApi);

            });
        };

        $scope.newSupplier = function () {

            $scope.showSupplier = true;
            $scope.showDelete = false;

            $scope.formTitle = "New Supplier";
            $scope.supplierVM = new Innoventory.supplierModel();

        }


        $scope.searchSuppliers = function (e) {

            e.preventDefault();

            onSearchSuppliers();

        }

        onSearchSuppliers = function () {

            if (!$scope.searchString) {
                $scope.searchString = "";
            };

            var url = "supplier/search/" + $scope.searchString;

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

        $scope.editSupplier = function (supplierId) {

            var url = "supplier/getSupplier/" + supplierId;

            apiService.apiGet(url, {}, function (result) {

                if (result.Entity) {

                    $scope.supplierVM = result.Entity;
                    $scope.showDelete = true;
                    $scope.showSupplier = true;
                    $scope.formTitle = "Edit Supplier";

                };

            });
        }

        $scope.deleteSupplier = function (e) {

            e.preventDefault();

            onDelete();

        }

        onDelete = function () {



        }

        $scope.saveSupplier = function (e) {

            e.preventDefault();

            onSaveSupplier();

        }

        onSaveSupplier = function () {

            var supplier = angular.copy($scope.supplierVM);
            var hasErrors = false;
            var errors = [];

            if (!(supplier.supplierName && supplier.supplierName != "")) {

                hasErrors = true;
                errors.push("Supplier Name can not be empty");

            };

            if (!(supplier.supplierContactNo && supplier.supplierContactNo != "")) {

                hasErrors = true;
                errors.push("Supplier Contact No can not be empty");

            };

            if (hasErrors) {
                apiService.showError(errors);
                return;
            }

            var url = "supplier/save";

            if (supplier.supplierId == null) {

                supplier.supplierId = Innoventory.emptyGuid;
            }


            apiService.apiPost(url, supplier, function (result) {

                if (result.Success) {

                    $scope.showSupplier = false;
                    $scope.supplierVM = null;

                    onSearchSuppliers();

                };

            });

        }

        $scope.cancel = function (e) {

            e.preventDefault();

            onCancel();

        }

        onCancel = function () {

            $scope.showSupplier = false;
            $scope.showDelete = false;

            $scope.formTitle = "";
            $scope.supplierVM = null;

        }

        onSearchSuppliers();

        return this;

    }

    inv.supplierController = supplierController;

})(window.Innoventory)