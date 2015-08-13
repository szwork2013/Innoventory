(function (inv) {
    var productGrid = function ($scope) {

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
                { field: 'imageId', displayName: 'Image', width: "10%", enableSorting: false },
                { field: 'productName', displayName: 'Product Name', width: "30%" },
                { field: 'description', displayName: 'Description', width: "35%" },
                { field: 'categoryName', displayName: 'Category', width: "12%" },
                { field: 'subCategoryName', displayName: 'Sub Category', width: "12%" },

            ]
        };

        me.gridOptions.multiSelect = false;
        me.gridOptions.modifierKeysToMultiSelect = false;
        me.gridOptions.noUnselect = true;
    };

    inv.productGrid = productGrid;

}(window.Innoventory))