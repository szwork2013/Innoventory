
(function (inv) {

    var categoryController = function ($scope, $q, apiService, $interval, uiGridConstants) {

        var cc = this;

        cc.test = "Test";

        $scope.isData = false;

        var paginationOptions = {
            pageNumber: 1,
            pageSize: 10,
        }

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
            paginationPageSize: 10,
            //rowTemplate: '<div ng-style="{ \'cursor\': row.cursor }" ng-repeat="col in renderedColumns" ng-class="col.colIndex()" class="ngCell {{col.cellClass}}"><div class="ngVerticalBar" ng-style="{height: rowHeight}" ng-class="{ ngVerticalBarVisible: !$last }">&nbsp;</div><div ng-cell></div></div>',

            verticalScrollbarVisible: false,
            columnDefs: [
            { field: 'categoryName', displayName: 'Category Name' },
            { field: 'description', displayName: 'Description' }
            ]

        };

        $scope.gridOptions.multiSelect = false;
        $scope.gridOptions.modifierKeysToMultiSelect = false;
        $scope.gridOptions.noUnselect = true;
        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                var category = {
                    categoryId: row.entity.categoryId,
                    categoryName: row.entity.categoryName,
                    description: row.entity.description,
                }
                $scope.editCategory(category);
            });

            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;
                onCancel();
                getTableStyle();
            });
        };

        $scope.toggleRowSelection = function () {
            $scope.gridApi.selection.clearSelectedRows();
            $scope.gridOptions.enableRowSelection = !$scope.gridOptions.enableRowSelection;
            $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.OPTIONS);
        };



        $scope.apiService = apiService;
        $scope.showCategory = false;

        $scope.newCategory = function () {

            $scope.categoryVM = new Innoventory.categoryModel();
            $scope.showDelete = false;
            $scope.showCategory = true;
            $scope.formTitle = "New Category";

        };

        getTableStyle = function () {
            var rowHeight = 30;
            var headerHeight = 45;

            var height = 400;



            if ($scope.gridOptions.data && $scope.gridOptions.data.length) {
                var go = $scope.gridOptions;

                var dataLength = go.data.length;
                var rowCount = 0;
                var currentPageNo = go.paginationCurrentPage;

                var restRows = dataLength - (go.paginationPageSize * (currentPageNo - 1));

                if (restRows > go.paginationPageSize) {
                    rowCount = go.paginationPageSize;
                }
                else {
                    rowCount = restRows;
                }



                height = ((rowCount * rowHeight) + headerHeight) + 30;


                //height = (dataLength * rowHeight) + headerHeight - 20 + "px";

                $scope.gridApi.grid.gridHeight = height - 30;


                if (height < $scope.gridApi.grid.gridHeight) {
                    height = $scope.gridApi.grid.gridHeight;
                }



            };

            $scope.tableStyle = {
                height: height + "px"
            };
        };

        GetCategories = function () {
            apiService.apiGet("Category/categories", {}, function (result) {

                if (result.Entities) {
                    $scope.categories = result.Entities;
                    if ($scope.categories && $scope.categories.length > 0) {
                        $scope.isData = true;
                        $scope.gridOptions.data = result.Entities;

                        //$interval(function () { $scope.gridApi.selection.selectRow($scope.gridOptions.data[0]); }, 0, 1);
                        getTableStyle();
                    }
                    else {
                        $scope.isData = false;
                    }


                    return $scope.categories;
                }

            });

        };



        $scope.editCategory = function (category) {


            $scope.categoryVM = angular.copy(category);

            $scope.formTitle = "Edit Category";
            $scope.showDelete = true;
            $scope.showCategory = true;
            $scope.selectedId = category.categoryId;

        }

        $scope.saveCategory = function (e) {


            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.categoryVM.categoryName == null || $scope.categoryVM.categoryName == "") {
                errors.push("Category Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.categoryVM.description == null || $scope.categoryVM.description == "") {

                errors.push("Description can not be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.showError(errors);
                //apiService.hasErrors = true;
                //apiService.errors = errors;
                return;
            };

            if ($scope.categoryVM.categoryId == null) {
                $scope.categoryVM.categoryId = Innoventory.emptyGuid;
            }

            apiService.apiPost("Category/SaveCategory", $scope.categoryVM, function (result) {


                $scope.categoryVM = null;

                $scope.showCategory = false;

                GetCategories();

            });

        }

        $scope.deleteCategory = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this category?")) {

                apiService.apiDelete("Category/Delete/" + $scope.categoryVM.categoryId, function (result) {

                    $scope.showCategory = false;

                    GetCategories();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();
            onCancel();

        }

        onCancel = function () {
            $scope.categoryVM = null;

            $scope.showCategory = false;
            $scope.selectedId = null;
            $scope.gridApi.selection.clearSelectedRows();
        }

        GetCategories();

        getTableStyle();

        return this;

    };

    inv.categoryController = categoryController;

}(window.Innoventory));