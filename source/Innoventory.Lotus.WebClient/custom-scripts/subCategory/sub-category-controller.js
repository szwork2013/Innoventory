(function (inv) {

    var subCategoryController = function ($scope, $q, apiService) {

        var scc = this;

        scc.subCategoryVM = {};

        $scope.apiService = apiService;
        $scope.showSubCategory = false;
        $scope.subCategory = {};


        $scope.newSubCategory = function () {

            scc.subCategoryVM = new Innoventory.subCategoryModel();
            $scope.showDelete = false;
            $scope.showSubCategory = true;
            $scope.title = "New Sub Category";

            GetCategories()

        };

        GetSubCategories = function () {
            apiService.apiGet("SubCategory/SubCategories", {}, function (result) {

                if (result.Entities) {
                    $scope.subCategories = result.Entities;

                    if (result.Entities.length > 0) {
                        $scope.isData = true;
                    }
                    else {
                        $scope.isData = false;
                    }

                    return $scope.subCategories;
                }
                else {
                    $scope.isData = false;
                }

            });

        };


        GetCategories = function () {

            var categories = [];
            var categorySelections = [];

            apiService.apiGet("Category/categories", {}, function (result) {

                categories = result.Entities;

                categories.forEach(function (category, key) {

                    var categorySelection = {
                        category: category,
                        isSelected: false
                    };

                    categorySelections.push(categorySelection);

                });

                scc.subCategoryVM.categories = categorySelections;

                $scope.subCategoryVM = scc.subCategoryVM;
                
            });

            
        };

        $scope.editSubCategory = function (subCategory) {
            //$scope.subCategoryVM = angular.copy(subCategory);

            $scope.title = "Edit Sub Category";

            var subCategoryVM = {};
            $scope.selectedId = subCategory.subCategoryId;

            apiService.apiGet("SubCategory/SubCategory/" + subCategory.subCategoryId, {}, function (result) {


                if (result.Entity) {

                    scc.subCategoryVM = result.Entity.subCategory;

                    scc.subCategoryVM.categories = result.Entity.categorySelections;

                    $scope.subCategoryVM = scc.subCategoryVM;
                };
            });

            
            
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

            $scope.subCategoryVM.categories;

            if (hasErrors) {
                apiService.showError(errors);
                
                return;
            };

            if ($scope.subCategoryVM.subCategoryId == null) {
                $scope.subCategoryVM.subCategoryId = Innoventory.emptyGuid;
            }

            var localVM = angular.copy($scope.subCategoryVM);

            var subCategoryViewModel = getSubCategorySaveModel(localVM);

            apiService.apiPost("SubCategory/SaveSubCategory", subCategoryViewModel, function (result) {


                $scope.subCategoryVM = null;

                $scope.showSubCategory = false;

                GetSubCategories();

            });

        }

        $scope.deleteSubCategory = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this category?")) {

                apiService.apiDelete("Category/Delete/" + $scope.subCategoryVM.subCategoryId, function (result) {

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

            subCategoryVM.categories.forEach(function (value, key) {
                if (value.isSelected) {
                    subCategory.categoryIds.push(value.category.categoryId);
                    selectedNames = selectedNames.concat(value.category.categoryName + ", ");
                }

            });

            subCategory.selectedCategoryNames = selectedNames;

            return subCategory;

        };

        return this;

    };

    inv.subCategoryController = subCategoryController;

}(window.Innoventory));