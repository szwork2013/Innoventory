(function (inv) {

    var purchaseOrderModel = function () {

        var me = this;
        me.purchaseOrderId = Innoventory.emptyGuid;
        me.purchaseOrderName = "",
        me.shortName = ""
    }

    inv.purchaseOrderModel = purchaseOrderModel;

}(window.Innoventory));