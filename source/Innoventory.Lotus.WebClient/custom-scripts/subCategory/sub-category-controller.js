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

            $scope.subCategoryVM.categories = GetCategories();

            return $scope.subCategoryVM;

        };

        GetSubCategories = function () {
            apiService.apiGet("SubCategory/SubCategories", {}, function (result) {

                if (result.Entities) {
                    $scope.subCategories = result.Entities;



                    return $scope.subCategories;
                }

            });

        };


        GetCategories = function () {
            apiService.apiGet("Category/categories", {}, function (result) {

                if (result.Entities) {
                    $scope.categories = result.Entities;
                    return $scope.categories;
                }

            });

        };

        $scope.editSubCategory = function (subCategory) {
            $scope.subCategoryVM = angular.copy(subCategory);

            $scope.formTitle = "Edit Category";
            $scope.showDelete = true;
            $scope.showSubCategory = true;

        }

        //Save Sub Category
        $scope.saveSubCategory = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.subCategoryVM.subCategoryName == null || $scope.subCategoryVM.subCategoryName == "") {
                errors.push("Sub Category Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.subCategoryVM.description == null || $scope.subCategoryVM.description == "") {

                errors.push("Sub Description can not be blank!");
                hasErrors = true;

            };

            $scope.subCategoryVM.categories = $scope.categories;

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.subCategoryVM.categoryId == null) {
                $scope.subCategoryVM.categoryId = Innoventory.emptyGuid;
            }

            var subCategoryViewModel = getSubCategorySaveModel($scope.subCategoryVM);

            apiService.apiPost("SubCategory/SaveSubCategory", subCategoryViewModel, function (result) {


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

        getSubCategorySaveModel = function (subCategoryVM) {



            var subCategory = {
                subCategoryId: subCategoryVM.subCategoryId,
                subCategoryName: subCategoryVM.subCategoryName,
                description: subCategoryVM.description,
                categoryIds: [],
                selectedCategoryNames: "",
            };


            var selectedNames = "";

            subCategoryVM.categories.forEach(function (category, key) {


                if (category.isSelected) {
                    subCategory.categoryIds.push(category.categoryId);
                    selectedNames = selectedNames.concat(category.categoryName + ", ");
                }

            });

            return subCategory;

        };

        return this;

    };

    inv.subCategoryController = subCategoryController;

}(window.Innoventory));