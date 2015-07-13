(function (inv) {

    var subCategoryModel = function () {

        var me = this;
        me.SubCategoryId = Innoventory.emptyGuid;
        me.SubCategoryName = "";
        me.Description = "";
        me.Categories = [];
        me.SelectedCategories = [];

    }

    inv.subCategoryModel = subCategoryModel;

}(window.Innoventory));