
(function (inv) {

    var productAttributeController = function ($scope, $q, apiService) {

        var cc = this;

        $scope.isData = false;

        $scope.apiService = apiService;
        $scope.showProductAttribute = false;

        $scope.newProductAttribte = function () {

            $scope.productAttribteVM = new Innoventory.productAttribteModel();
            $scope.showDelete = false;
            $scope.showProductAttribte = true;
            $scope.formTitle = "New ProductAttribte";

        };


        GetCategories = function () {
            apiService.apiGet("ProductAttribte/productAttribtes", {}, function (result) {

                if (result.Entities) {
                    $scope.productAttribtes = result.Entities;
                    if ($scope.productAttribtes && $scope.productAttribtes.length > 0)
                    {
                        $scope.isData = true;
                    }
                    else
                    {
                        $scope.isData = false;
                    }

                    return $scope.productAttribtes;
                }

            });

        };

        $scope.editProductAttribte = function (productAttribte) {
            $scope.productAttribteVM = angular.copy(productAttribte);

            $scope.formTitle = "Edit ProductAttribte";
            $scope.showDelete = true;
            $scope.showProductAttribte = true;
            $scope.selectedId = productAttribte.productAttribteId;

        }

        $scope.saveProductAttribte = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.productAttribteVM.categoryName == null || $scope.productAttribteVM.categoryName == "") {
                errors.push("ProductAttribte Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.productAttribteVM.description == null || $scope.productAttribteVM.description == "") {

                errors.push("Description can not be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.productAttribteVM.productAttribteId == null) {
                $scope.productAttribteVM.productAttribteId = Innoventory.emptyGuid;
            }

            apiService.apiPost("ProductAttribte/SaveProductAttribte", $scope.productAttribteVM, function (result) {


                $scope.productAttribteVM = null;

                $scope.showProductAttribte = false;

                GetCategories();

            });

        }

        $scope.deleteProductAttribte = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this productAttribte?")) {

                apiService.apiDelete("ProductAttribte/Delete/" + $scope.productAttribteVM.productAttribteId, function (result) {

                    $scope.showProductAttribte = false;

                    GetCategories();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.productAttribteVM = null;

            $scope.showProductAttribte = false;
            $scope.selectedId = null;
        }

        GetCategories();

        return this;

    };

    inv.productAttributeController = productAttributeController;

}(window.Innoventory));