(function (inv) {

    var volumeMeasureModel = function () {

        var me = this;
        me.volumeMeasureId = Innoventory.emptyGuid;
        me.volumeMeasureName = "",
        me.shortName = ""
    }

    inv.volumeMeasureModel = volumeMeasureModel;

}(window.Innoventory));