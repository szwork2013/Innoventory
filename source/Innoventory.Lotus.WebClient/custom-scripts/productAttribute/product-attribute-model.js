(function (inv) {

    var productAttributeModel = function() {

        var me = this;
        me.productAttributeId = Innoventory.emptyGuid;
        me.attributeName = "";
        me.attributeDescription = "";

    }

    inv.productAttributeModel = productAttributeModel;

}(window.Innoventory));