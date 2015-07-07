(function (inv) {

    var categoryModel = function() {

        var me = this;
        me.categoryId = Innoventory.emptyGuid;
        me.categoryName = "";
        me.description = "";

    }

    inv.categoryModel = categoryModel;

}(window.Innoventory));