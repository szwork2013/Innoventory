(function (inv) {

    var subCategoryController = function ($scope, $q, apiService) {

        var scc = this;

        $scope.apiService = apiService;
        $scope.showSubCategory = false;
        $scope.subCategory = {};


        $scope.newSubCategory = function () {

            $scope.subCategoryVM = new Innoventory.subCategoryModel();
            $scope.showDelete = false;
            $scope.showSubCategory = true;
            $scope.formTitle = "New Sub Category";
            
            $scope.subCategoryVM.categories = $scope.categories;
        };

        GetSubCategories = function () {
            apiService.apiGet("SubCategory/SubCategories", {}, function (result) {

                if (result.Entities) {
                    $scope.subCategories = result.Entities;


                    
                    return $scope.subCategories;
                }

            });

        };


        //GetCategories = function () {
        //    apiService.apiGet("Category/categories", {}, function (result) {

        //        if (result.Entities) {
        //            $scope.categories = result.Entities;
        //            return $scope.categories;
        //        }

        //    });

        //};

        $scope.editSubCategory = function (subCategory) {
            $scope.subCategoryVM = angular.copy(subCategory);

            $scope.formTitle = "Edit Category";
            $scope.showDelete = true;
            $scope.showSubCategory = true;

        }

        $scope.saveSubCategory = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.categoryVM.CategoryName == null || $scope.categoryVM.CategoryName == "") {
                errors.push("Category Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.categoryVM.Description == null || $scope.categoryVM.Description == "") {

                errors.push("Description can not be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.categoryVM.categoryId == null) {
                $scope.categoryVM.categoryId = Innoventory.emptyGuid;
            }

            apiService.apiPost("Category/SaveCategory", $scope.categoryVM, function (result) {


                $scope.subCategoryVM = null;

                $scope.showSubCategory = false;

                GetSubCategories();

            });

        }

        $scope.deleteSubCategory = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this category?")) {

                apiService.apiDelete("Category/Delete/" + $scope.categoryVM.CategoryId, function (result) {

                    $scope.showSubCategory = false;

                    GetSubCategories();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.subCategoryVM = null;

            $scope.showSubCategory = false;
        }

        GetSubCategories();

        return this;

    };

    inv.subCategoryController = subCategoryController;

}(window.Innoventory));