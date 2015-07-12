
(function (inv) {

    var categoryController = function ($scope, $q, apiHelper) {

        var cc = this;

        cc.test = "Test";

        $scope.apiHelper = apiHelper;
        $scope.showCategory = false;

        $scope.newCategory = function () {

            $scope.categoryVM = new Innoventory.categoryModel();
            $scope.showDelete = false;
            $scope.showCategory = true;
            $scope.formTitle = "New Category";

        };


        GetCategories = function () {
            apiHelper.apiGet("Category/categories", {}, function (result) {

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
                apiHelper.hasErrors = true;
                apiHelper.errors = errors;
                return;
            };

            if ($scope.categoryVM.categoryId == null) {
                $scope.categoryVM.categoryId = Innoventory.emptyGuid;
            }

            apiHelper.apiPost("Category/SaveCategory", $scope.categoryVM, setTimeout(function (result) {


                $scope.categoryVM = null;

                $scope.showCategory = false;

                GetCategories();

            }), 1000);

        }

        $scope.deleteCategory = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this category?")) {

                apiHelper.apiDelete("Category/Delete/" + $scope.categoryVM.CategoryId, function (result) {

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