
(function (inv) {

    var purchaseOrderController = function ($scope, $q, apiService) {

        var cc = this;

        cc.test = "Test";

        $scope.isData = false;

        $scope.apiService = apiService;
        $scope.showPurchaseOrder = false;

        $scope.newPurchaseOrder = function () {

            $scope.purchaseOrderVM = new Innoventory.purchaseOrderModel();
            $scope.showDelete = false;
            $scope.showPurchaseOrder = true;
            $scope.formTitle = "New Purchase Order";

        };


        GetPurchaseOrders = function () {
            apiService.apiGet("PurchaseOrder/purchaseOrders", {}, function (result) {

                if (result.Entities) {
                    $scope.purchaseOrders = result.Entities;
                    if ($scope.purchaseOrders && $scope.purchaseOrders.length > 0) {
                        $scope.isData = true;
                    }
                    else {
                        $scope.isData = false;
                    }

                    return $scope.purchaseOrders;
                }

            });

        };

        $scope.editPurchaseOrder = function (purchaseOrder) {
            $scope.purchaseOrderVM = angular.copy(purchaseOrder);

            $scope.formTitle = "Edit Purchase Order";
            $scope.showDelete = true;
            $scope.showPurchaseOrder = true;
            $scope.selectedId = purchaseOrder.purchaseOrderId;

        }

        $scope.savePurchaseOrder = function (e) {

            var errors = [];
            var hasErrors = false;

            e.preventDefault();

            if ($scope.purchaseOrderVM.purchaseOrderName == null || $scope.purchaseOrderVM.purchaseOrderName == "") {
                errors.push("Purchase Order can not be blank!");
                hasErrors = true;
            };

            if ($scope.purchaseOrderVM.shortName == null || $scope.purchaseOrderVM.shortName == "") {

                errors.push("Description can't be blank!");
                hasErrors = true;

            };

            if (hasErrors) {
                apiService.hasErrors = true;
                apiService.errors = errors;
                return;
            };

            if ($scope.purchaseOrderVM.purchaseOrderId == null) {
                $scope.purchaseOrderVM.purchaseOrderId = Innoventory.emptyGuid;
            }

            apiService.apiPost("PurchaseOrder/SavePurchaseOrder", $scope.purchaseOrderVM, function (result) {


                $scope.purchaseOrderVM = null;

                $scope.showPurchaseOrder = false;

                GetPurchaseOrders();

            });

        }

        $scope.deletePurchaseOrder = function (e) {

            e.preventDefault();

            if (confirm("Are you sure you want to delete this Purchase Order?")) {

                apiService.apiDelete("PurchaseOrder/Delete/" + $scope.purchaseOrderVM.purchaseOrderId, function (result) {

                    $scope.showPurchaseOrder = false;

                    GetPurchaseOrders();
                });
            };
        }

        $scope.cancel = function (e) {
            e.preventDefault();

            $scope.purchaseOrderVM = null;

            $scope.showPurchaseOrder = false;
            $scope.selectedId = null;
        }

        GetPurchaseOrders();

        return this;

    };

    inv.purchaseOrderController = purchaseOrderController;

}(window.Innoventory));