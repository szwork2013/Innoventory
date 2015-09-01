(function (inv) {
	 var salesOrderModel = function() {
	 	 var me = this;
	 	 me.salesOrderId = null;
	 	 me.salesOrderDate = "";
	 	 me.customerId = {};
	 	 me.shippingCost = 0;
	 	 me.taxes = 0;
	 	 me.salesOrderItems = [];
	 	 me.customer = {};
	 	 me.totalAmount = 0;
	 };
	 inv.salesOrderModel = salesOrderModel;
}(window.Innoventory));
