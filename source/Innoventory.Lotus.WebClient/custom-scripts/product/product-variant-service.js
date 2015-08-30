(function (inv) {

    var productVariantService = function ($http, $q, apiService) {

        var me = this;

        me.validateProductVariant = function (productVariant) {

            var hasErrors = false;
            var errors = [];

            if (isNaN(productVariant.availableQuantity) || productVariant.availableQuantity < 0) {

                errors.push("Available Quantity must be a non negative number");
                hasErrors = true;

            };

            if (isNaN(productVariant.lastPurchasePrice) || productVariant.lastPurchasePrice < 0) {

                errors.push("Purchase Price must be a non negative number");
                hasErrors = true;

            }

            if (isNaN(productVariant.basePrice) || productVariant.basePrice < 0) {

                errors.push("Base Price must be a non negative number");
                hasErrors = true;
            }

            if (isNaN(productVariant.shelfPrice) || productVariant.shelfPrice < 0) {

                errors.push("Shelf Price must be a non negative number");
                hasErrors = true;
            }

            if (hasErrors) {
                apiService.showError(errors);

                return false;
            }


            return true;

        };



        return this;

    };

    inv.productVariantService = productVariantService;

})(window.Innoventory)