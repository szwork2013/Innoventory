(function (inv) {
    var salesOrderController = function ($scope, $q, apiService, dataGridService) {

        var me = this;

        $scope.apiService = apiService;
        $scope.dataGridService = dataGridServie;

        $scope.soGridOptions = dataGridService.gridOptions;

        $scope.itemGridOptions = dataGridService.gridOptions;


        $scope.soGridOptions.coloumDefs = [

            { field: 'customerName', displayName: 'Customer Name', width: "25%" },
            { field: 'salesOrderDate', displayName: 'Order Date', width: "15%" },
            { field: 'referenceNo', displayName: 'Reference No', width: "15%" },
            { field: 'shippingCost', displayName: 'Shipping Charges', width: "15%", cellFilter: "currency : '£'", cellClass: "ui-grid-cell-number" },
            { field: 'taxes', displayName: 'Taxes', width: "15%", cellFilter: "currency : '£'", cellClass: "ui-grid-cell-number" },
            { field: 'totalAmount', displayName: 'Total Amount', width: "15%", cellFilter: "currency : '£'", cellClass: "ui-grid-cell-number" },

        ];

        $scope.itemGridOptions.coloumDefs = [

            { field: 'customerName', displayName: 'Customer Name', width: "25%" },
            { field: 'customerName', displayName: 'Customer Name', width: "25%" },
            { field: 'customerName', displayName: 'Customer Name', width: "25%" },


        ];

        return this;

    };

    inv.salesOrderController = salesOrderController;

})(window.Innoventory);