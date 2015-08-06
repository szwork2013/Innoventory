﻿
(function (inv) {

    var categoryController = function ($scope, $q, apiService, $interval, uiGridConstants) {

        var cc = this;

        cc.test = "Test";

        $scope.isData = false;

        $scope.gridOptions = {
            enableColumnResizing: true,
            enableSorting: true,
            paginationPageSizes: [10, 20, 30],
            paginationPageSize: 10,
            enableRowSelection: true,
            enableRowHeaderSelection: false,
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



        GetCategories = function () {
            apiService.apiGet("Category/categories", {}, function (result) {

                if (result.Entities) {
                    $scope.categories = result.Entities;
                    if ($scope.categories && $scope.categories.length > 0) {
                        $scope.isData = true;
                        $scope.gridOptions.data = result.Entities;
                        
                    }
                    else {
                        $scope.isData = false;
                    }


                    return $scope.categories;
                }

            });

        };

        $interval(function () { $scope.gridApi.selection.selectRow($scope.gridOptions.data[0]); }, 0, 1);

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

            $scope.categoryVM = null;

            $scope.showCategory = false;
            $scope.selectedId = null;
        }

        GetCategories();

        return this;

    };

    inv.categoryController = categoryController;

}(window.Innoventory));