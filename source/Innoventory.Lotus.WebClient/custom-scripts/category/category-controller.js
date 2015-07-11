
(function (inv) {

    var categoryController = function ($scope, $q, apiHelper) {

        var cc = this;

        cc.test = "Test";

        $scope.apiHelper = apiHelper;
        $scope.showCategory = false;

        $scope.newCategory = function () {

            $scope.categoryModel = new Innoventory.categoryModel();
            $scope.showCategory = true;
            $scope.formTitle = "New Category";

        };

        //$scope.Save = function (category) {



        //};

        GetCategories = function () {
            apiHelper.apiGet("Category/categories", {}, function (result) {

                if (result.Entities) {
                    $scope.categories = result.Entities;
                    return $scope.categories;
                }


            });

          
        };
        $scope.editCategory = function (category) {
            $scope.category = category;
            $scope.formTitle = "Edit Category";
            $scope.showCategory = true;

        }

        $scope.saveCategory = function (e) {

            e.preventDefault();

            if($scope.category.categoryId == null)
            {
                $scope.category.categoryId = Innoventory.emptyGuid;
            }

            apiHelper.apiPost("Category/SaveCategory", $scope.category, function (result) {

                $scope.showCategory = false;

                GetCategories();

            });

        }

        $scope.deleteCategory = function (e) {

            e.preventDefault();

            apiHelper.apiDelete("Category/Delete", $scope.category, function (result) {



            });
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.category = null;

            $scope.showCategory = false;
        }

        GetCategories();

        return this;

    };

    inv.categoryController = categoryController;

}(window.Innoventory));