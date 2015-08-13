(function (inv) {
    var productController = function ($scope, $q, apiService) {
        //var page = this;

        var pc = this;

        $scope.product = {};
        $scope.products = [];
        $scope.categories = [];

        $scope.subCategories = [];
        $scope.volumeMeasures = [];

        $scope.productFilterOption = {};

        $scope.searchCategory = {};
        $scope.searchSubCategory = {};
        $scope.searchTerm = "";

        $scope.apiService = apiService;

        $scope.isSubCategories = false;
        $scope.isData = false;
        $scope.isPVData = false;

        $scope.productGrid = new Innoventory.productGrid();
        $scope.productVariantGrid = new Innoventory.productVariantGrid();

        $scope.gridOptions = $scope.productGrid.gridOptions;

        $scope.pvGridOptions = $scope.productVariantGrid.gridOptions;

        $scope.pvGridOptions.data = {};


        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $scope.editProduct(row.entity.productId);
            });

            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                paginationOptions.pageNumber = newPage;
                paginationOptions.pageSize = pageSize;
                onCancel();
                getTableStyle();
            });
        };

    

        getTableStyle = function () {
            var rowHeight = $scope.gridOptions.rowHeight;
            var headerHeight = $scope.gridOptions.headerHeight;
            var height = 400;

            if ($scope.gridOptions.data && $scope.gridOptions.data.length) {
                var go = $scope.gridOptions;

                var dataLength = go.data.length;
                var rowCount = 0;
                var currentPageNo = go.paginationCurrentPage;

                var restRows = dataLength - (go.paginationPageSize * (currentPageNo - 1));

                if (restRows > go.paginationPageSize) {
                    rowCount = go.paginationPageSize;
                }
                else {
                    rowCount = restRows;
                }



                height = ((rowCount * rowHeight) + headerHeight) + 30;


                //height = (dataLength * rowHeight) + headerHeight - 20 + "px";

                $scope.gridApi.grid.gridHeight = height - 20;


                if (height < $scope.gridApi.grid.gridHeight) {
                    height = $scope.gridApi.grid.gridHeight;
                }



            };

            $scope.tableStyle = {
                height: height + "px"
            };
        };

        function init() {

            $scope.productFilterOption = new Innoventory.productFilterOption();

            var url = "Category/getCategorySelectList";

            $scope.apiService.apiGet(url, {}, function (result) {

                $scope.categories = result.EntityList;

            });

        }

        $scope.onSearchCategoryChange = function () {

            var category = $scope.searchCategory;

            if (category) {

                var scurl = "SubCategory/getSubCategorySelectList/" + category.entityId;
                $scope.apiService.apiGet(scurl, {}, function (result) {

                    $scope.subCategories = result.EntityList;

                    if ($scope.subCategories && $scope.subCategories.length > 0) {
                        $scope.isSubCategories = true;
                    }
                    else {
                        $scope.isSubCategories = false;
                    }
                });
            };
        }

        $scope.searchProducts = function(e) {

            e.preventDefault();

            if($scope.searchCategory)
            {
                $scope.productFilterOption.categoryId = $scope.searchCategory.entityId;
            }

            if($scope.searchSubCategory)
            {
                $scope.productFilterOption.subCategoryId = $scope.searchSubCategory.entityId;
            }

            
            var url = "product/searchProduct" ;

            apiService.apiPost(url, $scope.productFilterOption, function (result) {

                $scope.productListItems = result.Entities;

            });

            if($scope.productListItems && $scope.productListItems.length > 0)
            {
                $scope.isData = true;
            }
            else
            {
                $scope.isData = false;
            }

        };

        pc.onGetProductSuccess = function (result) {
            pc.products = result.products;

        };

        //pc.onGetProductsError = function (err) {
        //    page.Error = err.errorMessage;
        //};

        $scope.newProduct = function () {

            $scope.productVM = new Innoventory.productModel();
            $scope.formTitle = "New Product";
            $scope.showDelete = false;
            $scope.showProduct = true;

        };

        $scope.onCancelProduct = function (e) {
            $scope.productVM = null;

            $scope.showProduct = false;
            $scope.selectedId = null;
            $scope.gridApi.selection.clearSelectedRows();
        }

        init();

        //getProducts();

        return this;
    };

    inv.productController = productController;

}(window.Innoventory))