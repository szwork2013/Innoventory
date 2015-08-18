(function (inv) {
    var productController = function ($scope, $q, apiService) {
        //var page = this;

        var pc = this;

        $scope.categorySubCategoryMap = {};

        var paginationOptions = {
            pageNumber: 1,
            pageSize: 10,
        }




        //$scope.productService = productService;
        //$scope.pvService = productVariantService;

        $scope.productVM = {};
        $scope.productVariantVM = {};
        $scope.products = [];
        $scope.categories = [];

        $scope.subCategories = [];
        $scope.volumeMeasures = [];

        $scope.productFilterOption = {};

        $scope.searchCategory = {};
        $scope.searchSubCategory = {};
        $scope.searchTerm = "";

        $scope.productCategory = {};
        $scope.productSubCategory = {};
        $scope.isProdCategorySelected = false;

        $scope.apiService = apiService;

        $scope.isSubCategories = false;
        $scope.isData = false;
        $scope.isPVData = false;

        $scope.productGrid = new Innoventory.productGrid();
        $scope.productVariantGrid = new Innoventory.productVariantGrid();

        $scope.gridOptions = $scope.productGrid.gridOptions;

        //$scope.gridOptions.data = [];

        //$scope.pvGridOptions.data = [];

        $scope.pvGridOptions = $scope.productVariantGrid.gridOptions;

        $scope.pvGridOptions.data = {};

        $scope.salesVolumeMeasure = {};
        $scope.purchaseVolumeMeasure = {};


        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
            gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $scope.editProduct(row.entity.productId);
            });

            gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
               $scope.gridOptions.paginationOptions.pageNumber = newPage;
               $scope.gridOptions.paginationOptions.pageSize = pageSize;
                onCancel();
                getTableStyle($scope.gridOptions, $scope.gridApi);
            });
        };

        $scope.pvGridOptions.onRegisterApi = function (pvGridApi) {

            $scope.pvGridApi = pvGridApi;
            pvGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $scope.editProductVariant(row.entity.productId);
            });
                       
        };


        getTableStyle = function (gridOptions, gridApi) {

            var rowHeight = gridOptions.rowHeight;
            var headerHeight = gridOptions.headerHeight;
            var height = 400;

            if (gridOptions.data && gridOptions.data.length) {
                var go = gridOptions;

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

                gridApi.grid.gridHeight = height - 20;


                if (height < gridApi.grid.gridHeight) {
                    height = gridApi.grid.gridHeight;
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
                $scope.productCategories = result.EntityList;

            });

            getVolumeMeasures();

        }

        getVolumeMeasures = function () {
            $scope.volumeMeasures = {};

            var url = "volumeMeasure/getVolumeMeasureSelectList";

            $scope.apiService.apiGet(url, {}, function (result) {

                $scope.volumeMeasures = result.EntityList;

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

        $scope.onProductCategoryChange = function (category) {

            var category = $scope.productCategory;

            $scope.categorySubCategoryMap = {};

            if (category) {

                var scurl = "SubCategory/getSubCategorySelectList/" + category.entityId;
                $scope.apiService.apiGet(scurl, {}, function (result) {

                    $scope.productSubCategories = result.EntityList;

                    if ($scope.productSubCategories && $scope.productSubCategories.length > 0) {

                        $scope.isProductSubCategories = true;

                    }
                    else {

                        $scope.isProductSubCategories = false;

                    }
                });
            };
        }

        $scope.onProductSubCategoryChange = function () {

            var subCategoryId = $scope.productSubCategory.entityId;
            var categoryId = $scope.productCategory.entityId;

            if (subCategoryId) {

                var url = "SubCategory/getCategorySubCategoryMap/" + categoryId + "/" + subCategoryId;

                apiService.apiGet(url, {}, function (result) {
                    if (result) {

                        $scope.categorySubCategoryMap = result.Entity;
                    }
                });
            }

        }

        $scope.searchProducts = function (e) {

            e.preventDefault();

            if ($scope.searchCategory) {
                $scope.productFilterOption.categoryId = $scope.searchCategory.entityId;
            }

            if ($scope.searchSubCategory) {
                $scope.productFilterOption.subCategoryId = $scope.searchSubCategory.entityId;
            }


            var url = "product/searchProduct";

            apiService.apiPost(url, $scope.productFilterOption, function (result) {

                $scope.productListItems = result.Entities;

                $scope.gridOptions.data = $scope.productListItems;

            });

            if ($scope.productListItems && $scope.productListItems.length > 0) {
                $scope.isData = true;
            }
            else {
                $scope.isData = false;
            }

        };

        $scope.getAttributeList = function () {

            var catSubCatMapId = $scope.categorySubCategoryMap.categorySubCategoryMapId;

            var url = "productAttribute/getAttributeValues/" + catSubCatMapId;

            apiService.apiGet(url, {}, function (result) {

                if (result.Entities) {

                    $scope.attributeValueListCollection = result.Entities;
                }
            });

        }

        //pc.onGetProductsError = function (err) {
        //    page.Error = err.errorMessage;
        //};

        $scope.newProduct = function () {

            $scope.productVM = new Innoventory.productModel();
            $scope.formTitle = "New Product";
            $scope.showDelete = false;
            $scope.showProduct = true;

        };

        $scope.newProductVariant = function (e) {
            e.preventDefault();
            
            $scope.pvFormTitle = "New Product Variant";
            $scope.showDeletePV = false;
            $scope.showProductVariant = true;
            $scope.getAttributeList();
            $scope.productVariantVM = new Innoventory.productVariantModel();

        }

        $scope.editProduct = function (productId) {
            var pUrl = "product/GetProduct/" + productId;

            apiService.apiGet(pUrl, {}, function (result) {
                if (result.Entity) {

                    $scope.productVM = result.Entity;
                    $scope.showProduct = true;
                    $scope.showDelete = false;
                }
            });
        }

        $scope.editProductVariant = function (pvId) {

            var pvUrl = "productVariant/GetProductVariant/" + pvId;

            apiService.apiGet(pvUrl, {}, function (result) {
                if (result.Entity) {

                    $scope.productVariantVM = result.Entity;

                    //$scope.pvGridOptions.data = result.Entity.productVariants;
                }

            });
            //$scope.productVariantVM = 
        }

        $scope.saveProduct = function (e) {

            var product = angular.copy($scope.productVM);
            var isValid = false;
            var errors = [];

            product.categoryId = $scope.productCategory.entityId;
            product.categoryName = $scope.productCategory.entityName;

            product.subCategoryId = $scope.productSubCategory.entityName;
            product.subCategoryName = $scope.productsubcategory.entityName;

            product.salesVolumeMeasureId = $scope.salesVolumeMeasure.entityId;
            product.salesVolumeMeasureName = $scope.salesVolumeMeasure.entityName;

            product.purchaseVolumeMeasureId = $scope.purchaseVolumeMeasure.entityId;
            product.purchaseVolumeMeasureName = $scope.purchaseVolumeMeasure.entityna;

            if (!product.productName || product.productName == "") {
                errors.push("Product Name can not be empty");
            };

            if (!product.description || product.description == "") {
                errors.push("Description can not be empty");
            };

            if (!product.category) {
                errors.push("Please select a Category");
            };

            if (!product.subCategory) {
                errors.push("Please select a Sub Category");
            };

            if (!product.salesVolumeMeasureId) {
                errors.push("Please select a Sales Volume Measure");
            };

            if (!product.purchaseVolumeMeasureId) {
                errors.push("Please select a Purchase Volume Measure");
            };

            if (!product.productVariants || product.productVariants.length == 0) {
                errors.push("Please add at least one Product Variant");
            };

            if (errors.length > 0) {
                apiService.showError(errors);
            }
        }



        $scope.onCancelProduct = function (e) {
            e.preventDefault();

            onCancel();
        };

        onCancel = function () {
            $scope.productVM = null;
            $scope.showProduct = false;
            $scope.selectedId = null;
            $scope.gridApi.selection.clearSelectedRows();
        }

        $scope.onCancelProductVariant = function (e) {
            e.preventDefault();

            onPVCancel();
        }

        onPVCancel = function () {
            $scope.productVariantVM = null;
            $scope.showProductVariant = false;
            $scope.selectedPVId = null;
            $scope.pvGridApi.selection.clearSelectedRows();
        }


        init();

        //getProducts();

        return this;
    };

    inv.productController = productController;

}(window.Innoventory))