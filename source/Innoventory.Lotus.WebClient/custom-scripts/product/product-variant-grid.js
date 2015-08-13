(function (inv) {
    var productVariantGrid = function ($scope) {

        var me = this;
        me.gridOptions = {
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            enableColumnResizing: true,
            enableGridMenu: true,
            enableSorting: true,
            enableHorizontalScrollbar: 1,
            enableVerticalScrollbar: 0,
            enablePaging: true,
            rowHeight: 45,
            paginationPageSizes: [10, 20, 30],
            paginationPageSize: 10,
            //rowTemplate: '<div ng-style="{ \'cursor\': row.cursor }" ng-repeat="col in renderedColumns" ng-class="col.colIndex()" class="ngCell {{col.cellClass}}"><div class="ngVerticalBar" ng-style="{height: rowHeight}" ng-class="{ ngVerticalBarVisible: !$last }">&nbsp;</div><div ng-cell></div></div>',

            columnDefs: [
                { field: 'productVariantId', displayName: 'productVariantId', width: "10%", enableSorting: false},
                { field: 'attributeValueString', displayName: 'Attributes', width: "40%" },
                { field: 'availableQuantity', displayName: 'Available Quantity', width: "25%" },
                { field: 'skuCode', displayName: 'SKU Code', width: "20%" },
                { field: 'basePrice', displayName: 'Base Price', width: "12%", cellFilter:"currency:'£'", cellClass:"ui-grid-cell-number" },
                { field: 'shelfPrice', displayName: 'Shelf Price', width: "12%", cellFilter: "currency:'£'", cellClass: "ui-grid-cell-number" },

            ]
        };

        me.gridOptions.multiSelect = false;
        me.gridOptions.modifierKeysToMultiSelect = false;
        me.gridOptions.noUnselect = true;
    };

    inv.productVariantGrid = productVariantGrid;

}(window.Innoventory))