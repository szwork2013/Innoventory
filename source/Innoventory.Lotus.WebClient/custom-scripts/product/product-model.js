(function (inv) {
    var productModel = function () {
        var me = this;
        me.productId = {};
        me.itemType = 0;
        me.itemTypeValue = "";
        me.productName = "";
        me.description = "";
        me.remarks = "";
        me.categorySubCategoryMapId = {};
        me.categoryId = {};
        me.categoryName = "";
        me.subCategoryId = {};
        me.subCategoryName = "";
        me.imageId = [];
        me.salesVolumeMeasureId = {};
        me.salesVolumeMeasureName = "";
        me.purchaseVolumeMeasureId = {};
        me.purchaseVolumeMeasureName = "";
        me.productVariants = [];
        me.imageUrl = "";
    };

    var productListItemModel = function () {
        var me = this;
        me.productId = {};
        me.itemType = 0;
        me.itemTypeValue = "";
        me.productName = "";
        me.description = "";
        me.categoryName = "";
        me.subCategoryId = {};
        me.subCategoryName = "";
        me.imageId = {};
    };

    var productFilterOption = function () {
        var me = this;

        me.searchTerm = "";
        me.subCategoryId = {};
        me.categoryId = {};
    }

    inv.productFilterOption = productFilterOption;
    inv.productModel = productModel;
    inv.productListItemModel = productListItemModel;

}(window.Innoventory));

