(function (inv) {
	 var salesOrderItemModel = function() {
	 	 var me = this;
	 	 me.salesOrderItemId = null;
	 	 me.salesOrderId = {};
	 	 me.productVariantId = {};
	 	 me.quantity = 0;
	 	 me.price = 0;
	 	 me.productVariant = {};
	 	 me.amount = 0;
	 };
	 inv.salesOrderItemModel = salesOrderItemModel;
}(window.Innoventory));
