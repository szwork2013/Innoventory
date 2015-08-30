(function (inv) {
    var productService = function ($http, $q, apiService) {


        var ps = this;
               

        ps.getProducts = function () {
        
            
        };

        ps.getAttributeValues = function (categorySubCategoryMap) {

            var url = "";

        }

        ps.validateProductBeforeNewPV = function (product) {

            var errors = [];

            var hasError = false;

            if (!product.productName || product.productName == null) {
                errors.push("Please enter Product Name");
                hasError = true;
            }

            if (!product.description || product.description == null) {
                errors.push("Please enter Description");
                hasError = true;
            }

            if (!product.categoryId) {
                errors.push("Please select a Category");
                hasError = true;
            }
            else if (!product.subCategoryId) {
                errors.push("Please select a Sub Category");
                hasError = true;
            }

            if (hasError) {
                apiService.showError(errors);
                return false;
            }

            return true;

        };

        ps.validateProduct = function (product) {

            var errors = [];

            var hasError = false;

            if (!product.productName || product.productName == "") {
                errors.push("Product Name can not be empty");
            };

            if (!product.description || product.description == "") {
                errors.push("Description can not be empty");
            };

            if (!product.categorySubCategoryMapId) {
                errors.push("Please select a Category and Sub Category");
            };

            
            if (!product.volumeMeasureId) {
                errors.push("Please select a Volume Measure");
            };


            if (!product.productVariants || product.productVariants.length == 0) {
                errors.push("Please add at least one Product Variant");
            };

            if (errors.length > 0) {
                apiService.showError(errors);
                return false;
            }

            return true;

        }

        // Product list
        

        return this;

    };

    inv.productService = productService;

})(window.Innoventory)