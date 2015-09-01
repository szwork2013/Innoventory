(function (inv) {

    var dataGridService = function () {

        var me = this;

        me.gridOptions = {
            enableRowSelection: true,
            enableRowHeaderSelection: false,
            enableColumnResizing: true,
            enableGridMenu: true,
            enableSorting: true,
            enableHorizontalScrollbar: 0,
            enableVerticalScrollbar: 0,
            enablePaging: true,
            paginationPageSizes: [10, 20, 30],
            paginationPageSize: paginationOptions.pageSize,
            columnDefs: [],
        }


        return this;

    };

    inv.dataGridService = dataGridService;

})(window.Innoventory);