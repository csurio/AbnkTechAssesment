---------------
-- CATEGORIES
---------------
INSERT INTO abnk_inventory.category
            (id, name     , description)
     VALUES (1 , 'General','Productos Generales');
	 
---------------
-- ORDER TYPES
---------------
INSERT INTO abnk_inventory.order_type
            (id, description)
	 VALUES (1 , 'Purchase Order');
	 
INSERT INTO abnk_inventory.order_type
            (id, description)
	 VALUES (2 , 'Customer Order');
	 
---------------
-- ODER STATUS
---------------
INSERT INTO abnk_inventory.order_status
            (id, description)
	 VALUES (1 , 'Processed');
	 
INSERT INTO abnk_inventory.order_status
            (id, description)
	 VALUES (2 , 'Canceled');
	 
---------------
-- PRODUCTS
---------------
INSERT INTO abnk_inventory.product
            (id, sku                , name        , description             , createdAt)
	 VALUES (1 , 'SKU-PROD-000-OOO1', 'producto 1', 'descripcion Producto 1', now());
     
INSERT INTO abnk_inventory.product
            (id, sku                , name        , description             , createdAt)
	 VALUES (2 , 'SKU-PROD-000-OOO2', 'producto 2', 'descripcion Producto 2', now());
	 
INSERT INTO abnk_inventory.product
            (id, sku                , name        , description             , createdAt)
	 VALUES (3 , 'SKU-PROD-000-OOO3', 'producto 3', 'descripcion Producto 3', now());
	 
INSERT INTO abnk_inventory.product
            (id, sku                , name        , description             , createdAt)
	 VALUES (4 , 'SKU-PROD-000-OOO4', 'producto 4', 'descripcion Producto 3', now());
	 
INSERT INTO abnk_inventory.product
            (id, sku                , name        , description             , createdAt)
	 VALUES (5 , 'SKU-PROD-000-OOO5', 'producto 5', 'descripcion Producto 5', now());

-------------------------
-- PRODUCT - CATEGORY
-------------------------
INSERT INTO abnk_inventory.product_category
            (productId, categoryId)
	 VALUES (1        , 1);

INSERT INTO abnk_inventory.product_category
            (productId, categoryId)
	 VALUES (2        , 1);

INSERT INTO abnk_inventory.product_category
            (productId, categoryId)
	 VALUES (3        , 1);
	 
INSERT INTO abnk_inventory.product_category
            (productId, categoryId)
	 VALUES (4        , 1);
	 
INSERT INTO abnk_inventory.product_category
            (productId, categoryId)
	 VALUES (5        , 1);

---------------
-- ITEMS
---------------
INSERT INTO abnk_inventory.item
            (id, productId,  price, quantity, createdAt, updatedAt)
     VALUES (1 , 1        ,  11.99, 12     , now()    , null );
     
INSERT INTO abnk_inventory.item
            (id, productId, price, quantity, createdAt, updatedAt)
     VALUES (2 , 2        , 10.50, 24      , now()    , null );
	 
---------------
-- ORDER
---------------
INSERT INTO abnk_inventory.order
            (id, userId, type, status, total, createdAt)
	 VALUES (1 , 1     , 2   , 1     , 0.00,  now()    ); 

---------------	 
-- ORDER DETAIL
---------------     
INSERT INTO abnk_inventory.order_detail
            (id, orderId, productId,  quantity, price, createdAt)
	 VALUES (1 , 1      , 1        ,  12      , 9.99 , now()    );
     
INSERT INTO abnk_inventory.order_detail
            (id, orderId, productId, quantity, price, createdAt)
	 VALUES (2 , 1      , 2        , 24      , 8.75 , now()  );

------------------
-- USER
------------------
INSERT INTO abnk_Inventory.user 
           (id, roleId, firstName      , lastName    , username  , passwordHash                      , registeredAt         , lastLogin) 
    VALUES (1 , 1     , 'Administrador', 'Aplicacion', 'appadmin', '54ffedb5674760ab72d98d1369798d5e', '2021-04-22 10:13:41', '2021-04-23 20:45:11');

