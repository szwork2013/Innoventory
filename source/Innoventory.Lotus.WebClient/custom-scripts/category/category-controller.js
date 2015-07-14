
(function (inv) {

    var categoryController = function ($scope, $q, apiService) {

        var cc = this;

        cc.test = "Test";

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
                    return $scope.categories;
                }

            });

        };

        $scope.editCategory = function (category) {
            $scope.categoryVM = angular.copy(category);

            $scope.formTitle = "Edit Category";
            $scope.showDelete = true;
            $scope.showCategory = true;

        }

        $scope.saveCategory = function (e) {

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


                $scope.categoryVM = null;

                $scope.showCategory = false;

                GetCategories();

            });

        }

        $scope.deleteCategory = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this category?")) {

                apiService.apiDelete("Category/Delete/" + $scope.categoryVM.CategoryId, function (result) {

                    $scope.showCategory = false;

                    GetCategories();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.categoryVM = null;

            $scope.showCategory = false;
        }

        GetCategories();

        return this;

    };

    inv.categoryController = categoryController;

}(window.Innoventory));