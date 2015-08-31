(function (inv) {
    var productVariantGrid = function ($scope) {

        var me = this;
        me.gridOptions = {
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            enableGridMenu: true,
            enableSorting: true,
            enableHorizontalScrollbar: 1,
            enableVerticalScrollbar: 0,
            columnDefs: [
                            { field: 'rowId', displayName: 'Row Id', width: "20%" },
                            { field: 'skuCode', displayName: 'SKU Code', width: "20%" },
                            { field: 'attributeValueString', displayName: 'Attributes', width: "40%" },
                            { field: 'availableQuantity', displayName: 'Available Quantity', width: "25%" },
                            { field: 'basePrice', displayName: 'Base Price', width: "12%", cellFilter: "currency:'£'", cellClass: "ui-grid-cell-number" },
                            { field: 'shelfPrice', displayName: 'Shelf Price', width: "12%", cellFilter: "currency:'£'", cellClass: "ui-grid-cell-number" },

                        ]
        };

        me.gridOptions.multiSelect = false;
        me.gridOptions.modifierKeysToMultiSelect = false;
        me.gridOptions.noUnselect = true;
    };

    inv.productVariantGrid = productVariantGrid;

}(window.Innoventory))