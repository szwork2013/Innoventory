(function (inv) {

    var subCategoryModel = function () {

        var me = this;
        me.subCategoryId = Innoventory.emptyGuid;
        me.subCategoryName = "";
        me.description = "";
        me.categoryIds = [];
        me.selectedCategoryNames = "";

    }

    inv.subCategoryModel = subCategoryModel;

}(window.Innoventory));