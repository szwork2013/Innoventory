
(function (inv) {

    var productAttributeController = function ($scope, $q, apiService) {

        var pa = this;

        pa.productAttributeVM = {};

        $scope.isData = false;

        $scope.apiService = apiService;
        $scope.showProductAttribute = false;

        $scope.newProductAttribute = function () {

            pa.productAttributeVM = new Innoventory.productAttributeModel();

            getSubCategories();

            $scope.showDelete = false;
            $scope.showProductAttribute = true;
            $scope.formTitle = "New ProductAttribute";

        };


        getSubCategories = function () {

            url = "SubCategory/SubCategories";

            var subCategories = [];

            apiService.apiGet(url, {}, function (result) {

                subCategories = result.Entities;

                subCategories.forEach(function (subCategory, key) {

                    subCategorySelection = {
                        subCategory: subCategory,
                        isSelected: false,
                    }

                    pa.productAttributeVM.subCategorySelections.push(subCategorySelection);
                });

                $scope.productAttributeVM = pa.productAttributeVM;

            });

        };

        getProductAttributes = function () {
            apiService.apiGet("ProductAttribute/productAttributes", {}, function (result) {

                if (result.Entities) {
                    $scope.productAttributes = result.Entities;
                    if ($scope.productAttributes && $scope.productAttributes.length > 0) {
                        $scope.isData = true;
                    }
                    else {
                        $scope.isData = false;
                    }

                    return $scope.productAttributes;
                }

            });

        };

        $scope.editProductAttribute = function (productAttribute) {
            $scope.productAttributeVM = angular.copy(productAttribute);

            $scope.formTitle = "Edit ProductAttribute";
            $scope.showDelete = true;
            $scope.showProductAttribute = true;
            $scope.selectedId = productAttribute.productAttributeId;

        }

        $scope.saveProductAttribute = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.productAttributeVM.attributeName == null || $scope.productAttributeVM.attributeName == "") {
                errors.push("Product Attribute Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.productAttributeVM.attributeDescription == null || $scope.productAttributeVM.attributeDescription == "") {

                errors.push("Description can not be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.productAttributeVM.productAttributeId == null) {
                $scope.productAttributeVM.productAttributeId = Innoventory.emptyGuid;
            }

            apiService.apiPost("ProductAttribute/SaveProductAttribute", $scope.productAttributeVM, function (result) {

                $scope.productAttributeVM = null;

                $scope.showProductAttribute = false;

                getProductAttributes();

            });

        }

        $scope.deleteProductAttribute = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this productAttribute?")) {

                apiService.apiDelete("ProductAttribute/Delete/" + $scope.productAttributeVM.productAttributeId, function (result) {

                    $scope.showProductAttribute = false;

                    getProductAttributes();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.productAttributeVM = null;

            $scope.showProductAttribute = false;
            $scope.selectedId = null;
        }

        getProductAttributes();

        return this;

    };

    inv.productAttributeController = productAttributeController;

}(window.Innoventory));