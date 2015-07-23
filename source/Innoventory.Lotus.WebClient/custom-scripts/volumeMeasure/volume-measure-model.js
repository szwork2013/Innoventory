(function (inv) {

    var volumemeasureModel = function () {

        var me = this;
        me.volumemeasureId = Innoventory.emptyGuid;
        me.volumemeasureName = "";
        me.description = "";

    }

    inv.volumemeasureModel = volumemeasureModel;

}(window.Innoventory));