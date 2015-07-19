(function (inv) {

    var subCategoryModel = function () {

        var me = this;
        me.subCategoryId = Innoventory.emptyGuid;
        me.subCategoryName = "";
        me.description = "";
        me.categories = [];
        me.selectedCategoryNames = "";

    }

    inv.subCategoryModel = subCategoryModel;

}(window.Innoventory));