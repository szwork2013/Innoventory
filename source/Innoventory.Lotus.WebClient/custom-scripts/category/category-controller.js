
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

            if ($scope.categoryVM.categoryName == null || $scope.categoryVM.categoryName == "") {
                errors.push("Category Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.categoryVM.description == null || $scope.categoryVM.description == "") {

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

            apiHelper.apiDelete("Category/Delete/" + $scope.categoryVM.CategoryId, function (result) {

                $scope.showCategory = false;

                GetCategories();
            });
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