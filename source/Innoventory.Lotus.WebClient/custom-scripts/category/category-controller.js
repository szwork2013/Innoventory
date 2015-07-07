
(function (inv) {

    var categoryController = function ($scope, $q, apiHelper) {

        var cc = this;

        cc.test = "Test";

        $scope.apiHelper = apiHelper;

        $scope.New = function () {

            $scope.categoryModel = new Innoventory.categoryModel();

        };

        //$scope.Save = function (category) {



        //};

        GetCategories = function () {
            apiHelper.apiGet("api/Category/categories", {}, function (result) {

                $scope.categories = result.data;


            });

            //categoryModel = {
            //    categoryName: "Test",
            //    description: "Test 123"

            //}

            //$scope.categories = [];

            //$scope.categories.push(categoryModel);
        }

        GetCategories();

        return this;

    };

    inv.categoryController = categoryController;

}(window.Innoventory));