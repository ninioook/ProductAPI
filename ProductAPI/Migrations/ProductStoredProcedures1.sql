DROP PROCEDURE IF EXISTS AddProduct;
CREATE PROCEDURE AddProduct (
    IN p_name VARCHAR(255),
    IN p_price DECIMAL(10, 2),
    IN p_image_url VARCHAR(255)
)
BEGIN
    INSERT INTO Products (Name, Price, Image)
    VALUES (p_name, p_price, p_image_url);
    
    SELECT LAST_INSERT_ID() AS new_product_id;
END;

DROP PROCEDURE IF EXISTS UpdateProduct;
CREATE PROCEDURE UpdateProduct (
    IN p_productId INT,
    IN p_name VARCHAR(255),
    IN p_price DECIMAL(10, 2),
    IN p_image_url VARCHAR(255)
)
BEGIN
    UPDATE Products
    SET Name = p_name,
        Price = p_price,
        Image = p_image_url
    WHERE Id = p_productId;
END ;

DROP PROCEDURE IF EXISTS DeleteProduct;
CREATE PROCEDURE DeleteProduct (
    IN p_productId INT
)
BEGIN
    DELETE FROM Products WHERE Id = p_productId;
END ;

DROP PROCEDURE IF EXISTS GetProducts;
CREATE PROCEDURE GetProducts()
BEGIN
    SELECT Id, Name, Price, Image
    FROM Products;
END;

DROP PROCEDURE IF EXISTS GetProductById;
CREATE PROCEDURE GetProductById (
IN p_productId INT
)
BEGIN
    SELECT Id, Name, Price, Image
    FROM Products
    WHERE Id = p_productId;
END;

DROP PROCEDURE IF EXISTS GetAllProducts;
CREATE PROCEDURE GetAllProducts()
BEGIN
    SELECT 
        Id,
        Name,
        Price,
        Image
    FROM 
        Products;
END;