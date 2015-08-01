(function (inv) {

    var productAttributeModel = function() {

        var me = this;
        me.productAttributeId = Innoventory.emptyGuid;
        me.attributeName = "";
        me.attributeDescription = "";
        me.subCategoryNames = "";
        me.subCategorySelections = [];

    }

    inv.productAttributeModel = productAttributeModel;

}(window.Innoventory));