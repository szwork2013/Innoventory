(function (inv) {
    var productVariantModel = function () {

        var me = this;

        me.productVariantId = {};
        me.productId = {};
        me.barCode = "";
        me.unitVolume = 0;
        me.availableQuantity = 0;
        me.reorderPoint = 0;
        me.reorderQuantity = 0;
        me.caseLength = 0;
        me.caseWidth = 0;
        me.caseHeight = 0;
        me.caseWeight = 0;
        me.productLength = 0;
        me.productWidth = 0;
        me.productHeight = 0;
        me.productWeight = 0;
        me.lastSupplierId = [];
        me.isSellable = true;
        me.isPurchasable = true;
        me.isActive = "";
        me.imageId = [];
        me.skuCode = "";
        me.lastPurchasePrice = 0;
        me.basePrice = 0;
        me.shelfPrice = 0;
        me.promotionId = {};
        me.imageFileIds = [];
        me.imageUrls = [];
        me.imageFileId = null;
        me.mainImageUrl = "";
        me.ProductVariantAttributeValues = [];
        
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

    var productVariantAttributeValueModel = function () {

        var me = this;
        me.productVariantId = "";
        me.productAttributeId = "";
        me.attributeValueListId = "";
        me.productAttributeName = "";
        me.productAttributeValue = "";

    }

    inv.productVariantAttributeValueModel = productVariantAttributeValueModel;

    inv.productVariantListItemModel = productVariantListItemModel;

    inv.productVariantModel = productVariantModel;

}(window.Innoventory));
