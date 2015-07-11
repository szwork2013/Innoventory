
(function (inv) {

    var categoryController = function ($scope, $q, apiHelper) {

        var cc = this;

        cc.test = "Test";

        $scope.apiHelper = apiHelper;
        $scope.showCategory = false;

        $scope.newCategory = function () {

            $scope.categoryModel = new Innoventory.categoryModel();
            $scope.showCategory = true;

        };

        //$scope.Save = function (category) {



        //};

        GetCategories = function () {
            apiHelper.apiGet("api/Category/categories", {}, function (result) {

                $scope.categories = result.data;


            });

          
        };

        $scope.saveCategory = function (e) {

            e.preventDefault();

            if($scope.category.categoryId == null)
            {
                $scope.category.categoryId = Innoventory.emptyGuid;
            }

            apiHelper.apiPost("api/Category/SaveCategory", $scope.category, function (result) {

                $scope.showCategory = false;

                GetCategories();

            });

        }


        GetCategories();

        return this;

    };

    inv.categoryController = categoryController;

}(window.Innoventory));