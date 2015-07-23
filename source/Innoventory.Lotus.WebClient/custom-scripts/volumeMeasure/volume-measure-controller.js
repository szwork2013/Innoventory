
(function (inv) {

    var volumemeasureController = function ($scope, $q, apiService) {

        var cc = this;

        cc.test = "Test";

        $scope.isData = false;

        $scope.apiService = apiService;
        $scope.showVolumeMeasure = false;

        $scope.newVolumeMeasure = function () {

            $scope.volumemeasureVM = new Innoventory.volumemeasureModel();
            $scope.showDelete = false;
            $scope.showVolumeMeasure = true;
            $scope.formTitle = "New VolumeMeasure";

        };


        GetCategories = function () {
            apiService.apiGet("VolumeMeasure/categories", {}, function (result) {

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

        $scope.editVolumeMeasure = function (volumemeasure) {
            $scope.volumemeasureVM = angular.copy(volumemeasure);

            $scope.formTitle = "Edit VolumeMeasure";
            $scope.showDelete = true;
            $scope.showVolumeMeasure = true;
            $scope.selectedId = volumemeasure.volumemeasureId;

        }

        $scope.saveVolumeMeasure = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.volumemeasureVM.volumemeasureName == null || $scope.volumemeasureVM.volumemeasureName == "") {
                errors.push("VolumeMeasure Name can not be blank!");
                hasErrors = true;
            };

            if ($scope.volumemeasureVM.description == null || $scope.volumemeasureVM.description == "") {

                errors.push("Description can not be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.volumemeasureVM.volumemeasureId == null) {
                $scope.volumemeasureVM.volumemeasureId = Innoventory.emptyGuid;
            }

            apiService.apiPost("VolumeMeasure/SaveVolumeMeasure", $scope.volumemeasureVM, function (result) {


                $scope.volumemeasureVM = null;

                $scope.showVolumeMeasure = false;

                GetCategories();

            });

        }

        $scope.deleteVolumeMeasure = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this volumemeasure?")) {

                apiService.apiDelete("VolumeMeasure/Delete/" + $scope.volumemeasureVM.volumemeasureId, function (result) {

                    $scope.showVolumeMeasure = false;

                    GetCategories();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.volumemeasureVM = null;

            $scope.showVolumeMeasure = false;
            $scope.selectedId = null;
        }

        GetCategories();

        return this;

    };

    inv.volumemeasureController = volumemeasureController;

}(window.Innoventory));