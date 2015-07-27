(function (inv) {
    var productModel = function () {
        var me = this;
        me.productId = {};
        me.itemType = 0;
        me.itemTypeValue = '';
        me.productName = '';
        me.description = '';
        me.remarks = '';
        me.categorySubCategoryMapId = {};
        me.categoryId = {};
        me.categoryName = '';
        me.subCategoryId = {};
        me.subCategoryName = '';
        me.imageId = [];
        me.salesOrderUnitId = {};
        me.salesOrderVolumeMeasureName = '';
        me.purchaseOrderVolumeMeasureId = {};
        me.purchaseOrderUnit = {};
        me.productVariants = [];
        me.imageUrl = '';
    };
    inv.productModel = productModel;
}(window.Innoventory));
