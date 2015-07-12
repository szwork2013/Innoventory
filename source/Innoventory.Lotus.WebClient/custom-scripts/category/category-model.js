(function (inv) {

    var categoryModel = function() {

        var me = this;
        me.CategoryId = Innoventory.emptyGuid;
        me.CategoryName = "";
        me.Description = "";

    }

    inv.categoryModel = categoryModel;

}(window.Innoventory));