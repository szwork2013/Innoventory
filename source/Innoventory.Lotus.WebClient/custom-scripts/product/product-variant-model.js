(function (inv) {
    var productVariantModel = function () {

        var me = this;

        me.productVariantId = {};
        me.productId = {};
        me.barCode = "";
        me.salesVolume = [];
        me.purchaseVolume = [];
        me.reorderPoint = [];
        me.reorderQuantity = [];
        me.caseLength = [];
        me.caseWidth = [];
        me.caseHeight = [];
        me.caseWeight = [];
        me.productLength = [];
        me.productWidth = [];
        me.productHeight = [];
        me.productWeight = [];
        me.lastSupplierId = [];
        me.isSellable = "";
        me.isPurchasable = "";
        me.isActive = "";
        me.imageId = [];
        me.skuCode = "";
        me.lastPurchasePrice = 0;
        me.basePrice = 0;
        me.shelfPrice = 0;
        me.promotionId = {};
        me.imageFileIds = [];
    };

    var productVariantListItemModel = function () {

        var me = this;

        me.productVariantId = {};
        me.attributeValueString = "";
        me.availableQuantity = 0;
        me.skuCode = "";
        me.basePrice = 0;
        me.shelfPrice = 0;
    };

    inv.productVariantListItemModel = productVariantListItemModel;

    inv.productVariantModel = productVariantModel;

}(window.Innoventory));
