(function (inv) {

    var productController = function ($scope, $q, productService, productVariantService, apiService) {
        //var page = this;


        var pc = this;

        pc.pvRowId = 0;

        pc.pvEditRowId = 0

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

        $scope.volumeMeasure = {};
        $scope.category = {};
        $scope.subCategory = {};

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
        $scope.hasAttribute = false;

        $scope.productGrid = new Innoventory.productGrid();
        $scope.productVariantGrid = new Innoventory.productVariantGrid();

        $scope.gridOptions = $scope.productGrid.gridOptions;

        $scope.pvTableStyle = "";
        $scope.tableStyle = "";

        //$scope.gridOptions.data = [];

        //$scope.pvGridOptions.data = [];

        $scope.pvGridOptions = $scope.productVariantGrid.gridOptions;

        $scope.pvGridOptions.data = [];

        $scope.salesVolumeMeasure = {};
        $scope.purchaseVolumeMeasure = {};


        getTableStyle = function (gridOptions, gridApi) {

            var rowHeight = gridOptions.rowHeight;
            var headerHeight = gridOptions.headerRowHeight;
            var height = 400;

            if (gridOptions.data && gridOptions.data.length) {
                var go = gridOptions;

                var dataLength = go.data.length;
                var rowCount = 0;

                if (gridOptions.enablePaginationControls) {
                    var currentPageNo = go.paginationCurrentPage;

                    var restRows = dataLength - (go.paginationPageSize * (currentPageNo - 1));


                    if (restRows > go.paginationPageSize) {
                        rowCount = go.paginationPageSize;
                    }
                    else {
                        rowCount = restRows;
                    }

                }
                else {
                    rowCount = gridOptions.data.length;
                };

                height = ((rowCount * rowHeight) + headerHeight) + 30;


                //height = (dataLength * rowHeight) + headerHeight - 20 + "px";

                gridApi.grid.gridHeight = height - 10;


                if (height < gridApi.grid.gridHeight) {
                    height = gridApi.grid.gridHeight;
                }

            };

            if (gridOptions.enablePaginationControls) {

                height = height + 40;
            }

            var tableStyle = {
                height: height + "px"
            };

            return tableStyle;
        };
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
                $scope.tableStyle = getTableStyle($scope.gridOptions, $scope.gridApi);

            });
        };

        $scope.pvGridOptions.onRegisterApi = function (pvGridApi) {

            $scope.pvGridApi = pvGridApi;
            pvGridApi.selection.on.rowSelectionChanged($scope, function (row) {
                var msg = 'row selected ' + row.isSelected;
                $scope.editProductVariant(row.entity.productVariantId);
            });

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

        $scope.onProductCategoryChange = function (e) {

            getProductSubCategories();
        }

        getProductSubCategories = function (subCategoryId) {

            var category = $scope.productCategory;

            $scope.categorySubCategoryMap = {};

            if (category && category.entityId) {

                var scurl = "SubCategory/getSubCategorySelectList/" + category.entityId;
                $scope.apiService.apiGet(scurl, {}, function (result) {

                    $scope.productSubCategories = result.EntityList;

                    if ($scope.productSubCategories && $scope.productSubCategories.length > 0) {

                        $scope.isProductSubCategories = true;

                        if (subCategoryId) {

                            $scope.productSubCategory = getSelectListItem($scope.productSubCategories, subCategoryId);
                            $scope.onProductSubCategoryChange();
                        }
                        else {

                            $scope.isProductSubCategories = false;


                        }

                    }
                });

            }
        }

        $scope.onProductSubCategoryChange = function () {

            var subCategory = $scope.productSubCategory;

            var categoryId = $scope.productCategory.entityId;

            if (subCategory && subCategory.entityId) {

                var url = "SubCategory/getCategorySubCategoryMap/" + categoryId + "/" + subCategory.entityId;

                apiService.apiGet(url, {}, function (result) {
                    if (result) {

                        //$scope.productVM.categorySubCategoryMap = result.entity;
                        $scope.categorySubCategoryMap = result.Entity;
                        $scope.categorySubCategoryMapId = result.Entity.categorySubCategoryMapId;
                    }
                });
            }

        }

        $scope.searchProducts = function (e) {

            e.preventDefault();

            search();

        };

        search = function(){

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
                $scope.isData = true;
                $scope.tableStyle = getTableStyle($scope.gridOptions, $scope.gridApi);

            });

            if ($scope.productListItems && $scope.productListItems.length > 0) {
                $scope.isData = true;
                $scope.tableStyle = getTableStyle($scope.gridOptions, $scope.gridApi);
            }
            else {
                $scope.isData = false;
            }

        };

        $scope.getAttributeList = function () {

            var catSubCatMapId = $scope.categorySubCategoryMapId;

            var url = "productAttribute/getAttributeValues/" + mapId;

            apiService.apiGet(url, {}, function (result) {

                if (result.Entities) {

                    $scope.hasAttribute = true;
                    $scope.attributeValueListCollection = result.Entities;

                }
                else {

                    $scope.hasAttribute = false;

                }
            });

        }

        getAttributeListByMapId = function (mapId, fn) {

            var url = "productAttribute/getAttributeValues/" + mapId;

            apiService.apiGet(url, {}, fn);



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

            var product = $scope.productVM;

            product.categorySubCategoryMap = $scope.categorySubCategoryMap;

            product.categorySubCategoryMapId = $scope.categorySubCategoryMap.categorySubCategoryMapId;

            //product.categoryId = $scope.productCategory.entityId;
            //product.categoryName = $scope.productCategory.entityName;

            //product.subCategoryId = $scope.productSubCategory.entityId;
            //product.subCategoryName = $scope.productSubCategory.entityName;

            product.volumeMeasureId = $scope.volumeMeasure.entityId;
            product.volumeMeasureName = $scope.volumeMeasure.entityName;



            var validateProduct = productService.validateProductBeforeNewPV(product);

            if (!validateProduct) {
                return;
            }


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

                    $scope.productCategory = getSelectListItem($scope.productCategories, $scope.productVM.categorySubCategoryMap.categoryId);

                    getProductSubCategories($scope.productVM.categorySubCategoryMap.subCategoryId);

                    if ($scope.volumeMeasures && $scope.volumeMeasures.length > 0) {
                        $scope.volumeMeasure = getSelectListItem($scope.volumeMeasures, $scope.productVM.volumeMeasureId);
                    }

                    $scope.categorySubCategoryMap = $scope.productVM.categorySubCategoryMap;

                    var categorySubCategoryMapId = $scope.productVM.categorySubCategoryMapId;

                    getAttributeListByMapId(categorySubCategoryMapId, function (result) {

                        if (result.Entities) {

                            $scope.hasAttribute = true;
                            $scope.attributeValueListCollection = result.Entities;

                        }
                        else {

                            $scope.hasAttribute = false;

                        }

                        var attributeValueString = "";
                        

                        $scope.pvGridOptions.data = $scope.productVM.productVariantListItems;

                        
                        if ($scope.pvGridOptions.data && $scope.pvGridOptions.data.length > 0) {
                            $scope.isPVData = true;
                            $scope.pvTableStyle = getTableStyle($scope.pvGridOptions, $scope.pvGridApi);
                        }

                        $scope.showProduct = true;
                        $scope.showDelete = true;

                        $scope.formTitle = "Edit Product";

                    });



                }
            });
        }

        getSelectListItem = function (list, id) {

            var result = list.filter(function (item) {

                return item.entityId == id;

            })

            if (result && result.length > 0) {
                return result[0];
            }

            return null;
        }

        $scope.editProductVariant = function (pvId) {

            var productVariant = getProductVariantRow(pvId);

            if (productVariant) {
                $scope.productVariantVM = productVariant;

                $scope.showDeletePV = true;
                $scope.showProductVariant = true;

                if($scope.hasAttribute)
                {
                    var productAttributeVariantValues = productVariant.productVariantAttributeValues;

                    $scope.attributeValueListCollection.forEach(function (attr, key) {

                        var selAttr = productAttributeVariantValues.filter(function (item) {

                            return item.productAttributeId == attr.productAttributeId;

                        });

                        if(selAttr != null && selAttr.length > 0)
                        {
                            var selectedAttributeValue = selAttr[0];

                            var attrValue = {
                                attributeValueListId: selectedAttributeValue.attributeValueListId,
                                attributeValue: selectedAttributeValue.productAttributeValue
                            }

                            attr.selectedAttributeValue = attrValue;
                        }

                    });
                }

                
            };
            

        }

        getProductVariantRow = function (pvId) {



            var productVariants = $scope.productVM.productVariants.filter(function (object) {

                if (object.productVariantId == pvId) {

                    return object;

                }

            });

            if (productVariants && productVariants.length > 0) {

                return productVariants[0];
            };
        }

        $scope.saveProduct = function (e) {

            var product = angular.copy($scope.productVM);
            var isValid = false;
            var errors = [];

            //product.categoryId = $scope.productCategory.entityId;
            //product.categoryName = $scope.productCategory.entityName;

            //product.subCategoryId = $scope.productSubCategory.entityName;
            //product.subCategoryName = $scope.productSubCategory.entityName;

            //product.volumeMeasureId = $scope.volumeMeasure.entityId;
            //product.volumeMeasureShortName = $scope.volumeMeasure.entityName;

            product.categorySubCategoryMap = $scope.categorySubCategoryMap;

            product.categorySubCategoryMapId = $scope.categorySubCategoryMap.categorySubCategoryMapId;


            var validateProduct = productService.validateProduct(product);

            if (!validateProduct) {
                return;
            }

            var url = "product/saveProduct";

            apiService.apiPost(url, product, function (result) {

                if (result.Success) {
                    

                    search();
                }

            });

        }

        clearForm = function () {

            $scope.showProduct = false;

            $scope.showProductVariant = false;
            $scope.showProduct = false;
            $scope.pvGridOptions.data = [];
            $scope.categorySubCategoryMap = null;
            $scope.categorySubCategoryMapId = null;
            $scope.productCategory = null;
            $scope.productSubCategory = null;
            $scope.productSubCategories = [];
            $scope.categoryId = null;
            $scope.volumeMeasure = null;
            $scope.isProdCategorySelected = false;
            $scope.isPVData = false;
            $scope.isSubCategories = false;
            $scope.productvm = {};
            $scope.productVariantVM = {};

        };

        $scope.attributeSelected = function (value, attributeId) {

            var selectedValue = value;
            var attributeId = attributeId;


        }

        $scope.saveProductVariant = function (e) {

            e.preventDefault();
            var hasError = false;
            var errors = [];

            var productVariant = $scope.productVariantVM;

            productVariant.productVariantAttributeValues = [];

            var attributeValueString = "";
            var loop = 0;

            if ($scope.hasAttribute) {

                $scope.attributeValueListCollection.forEach(function (pv, key) {

                    var productVariantAttributeValueModel = new Innoventory.productVariantAttributeValueModel();

                    productVariantAttributeValueModel = {
                        productVariantId: productVariant.productVariantId,
                        productAttributeId: pv.productAttributeId,
                        productAttributeName: pv.attributeName
                    };

                    if (loop > 0) {
                        attributeValueString = attributeValueString.concat("; ");
                    }

                    attributeValueString = attributeValueString.concat(pv.attributeName, ": ");

                    if (pv.selectedAttributeValue && pv.selectedAttributeValue.attributeValueListId) {

                        productVariantAttributeValueModel.attributeValueListId = pv.selectedAttributeValue.attributeValueListId;
                        productVariantAttributeValueModel.productAttributeValue = pv.selectedAttributeValue.attributeValue.trim();
                        attributeValueString = attributeValueString.concat(pv.selectedAttributeValue.attributeValue.trim());

                    } else {

                        productVariantAttributeValueModel.attributeValueListId = Innoventory.emptyGuid;
                        productVariantAttributeValueModel.productAttributeValue = pv.selectedAttributeValue.trim();
                        attributeValueString = attributeValueString.concat(pv.selectedAttributeValue.trim());

                    }


                    productVariant.productVariantAttributeValues.push(productVariantAttributeValueModel);

                    loop = loop + 1;

                });
            }
            else {
                attributeValueString = "No Attributes"
            };

            var isValid = productVariantService.validateProductVariant(productVariant);

            if (!isValid) {
                return;
            }

            var productVariantListItem = null;

            var isNewRow = false;

            if (!productVariant.productVariantId || productVariant.productVariantId == Innoventory.emptyGuid) {
                productVariant.productVariantId = apiService.generateUUID();
                $scope.productVM.productVariants.push(productVariant);

                productVariantListItem = new Innoventory.productVariantListItemModel();
                isNewRow = true;

            }
            else {

                var pvItems = $scope.productVM.productVariants.filter(function (item) {

                    return item.productVariantId == productVariant.productVariantId;


                });

                if (pvItems && pvItems.length > 0) {
                    pvItems[0] = productVariant;

                };

                var pvListItems = $scope.pvGridOptions.data.filter(function (item) {

                    return item.productVariantId == productVariant.productVariantId;

                });

                if (pvListItems && pvListItems.length > 0) {

                    productVariantListItem = pvListItems[0];
                };

            };

            

            

            productVariantListItem.skuCode = productVariant.skuCode;
            productVariantListItem.availableQuantity = productVariant.availableQuantity;
            productVariantListItem.attributeValueString = attributeValueString;

            productVariantListItem.basePrice = productVariant.basePrice;
            productVariantListItem.shelfPrice = productVariant.shelfPrice;

            if (isNewRow) {
                $scope.pvGridOptions.data.push(productVariantListItem);
            };

            $scope.pvTableStyle = getTableStyle($scope.pvGridOptions, $scope.pvGridApi);

            $scope.isPVData = true;

            productVariant = null;

            $scope.productvariantvm = null;

            $scope.showProductVariant = false;

        }



        $scope.onCancelProduct = function (e) {
            e.preventDefault();

            onCancel();
        };

        onCancel = function () {
            clearForm();
                        
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