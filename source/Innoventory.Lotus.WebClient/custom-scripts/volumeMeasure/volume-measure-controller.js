
(function (inv) {

    var volumeMeasureController = function ($scope, $q, apiService) {

        var cc = this;

        cc.test = "Test";

        $scope.isData = false;

        $scope.apiService = apiService;
        $scope.showVolumeMeasure = false;

        $scope.newVolumeMeasure = function () {

            $scope.volumeMeasureVM = new Innoventory.volumeMeasureModel();
            $scope.showDelete = false;
            $scope.showVolumeMeasure = true;
            $scope.formTitle = "New VolumeMeasure";

        };


        GetVolumeMeasures = function () {
            apiService.apiGet("VolumeMeasure/volumeMeasures", {}, function (result) {

                if (result.Entities) {
                    $scope.categories = result.Entities;
                    if ($scope.categories && $scope.categories.length > 0) {
                        $scope.isData = true;
                    }
                    else {
                        $scope.isData = false;
                    }

                    return $scope.categories;
                }

            });

        };

        $scope.editVolumeMeasure = function (volumeMeasure) {
            $scope.volumeMeasureVM = angular.copy(volumeMeasure);

            $scope.formTitle = "Edit Volume Measure";
            $scope.showDelete = true;
            $scope.showVolumeMeasure = true;
            $scope.selectedId = volumeMeasure.volumeMeasureId;

        }

        $scope.saveVolumeMeasure = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.volumeMeasureVM.volumeMeasureName == null || $scope.volumeMeasureVM.volumeMeasureName == "") {
                errors.push("Volume Measure Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.volumeMeasureVM.shortName == null || $scope.volumeMeasureVM.shortName == "") {

                errors.push("Description can't be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.volumeMeasureVM.volumeMeasureId == null) {
                $scope.volumeMeasureVM.volumeMeasureId = Innoventory.emptyGuid;
            }

            apiService.apiPost("VolumeMeasure/SaveVolumeMeasure", $scope.volumeMeasureVM, function (result) {


                $scope.volumeMeasureVM = null;

                $scope.showVolumeMeasure = false;

                GetVolumeMeasures();

            });

        }

        $scope.deleteVolumeMeasure = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this Volume Measure?")) {

                apiService.apiDelete("VolumeMeasure/Delete/" + $scope.volumeMeasureVM.volumeMeasureId, function (result) {

                    $scope.showVolumeMeasure = false;

                    GetVolumeMeasures();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.volumeMeasureVM = null;

            $scope.showVolumeMeasure = false;
            $scope.selectedId = null;
        }

        GetVolumeMeasures();

        return this;

    };

    inv.volumeMeasureController = volumeMeasureController;

}(window.Innoventory));