DROP PROCEDURE IF EXISTS AddProductCategory;
CREATE PROCEDURE AddProductCategory (
    IN p_product_id INT,
    IN p_category_id INT
)
BEGIN
    INSERT INTO ProductCategories (ProductId, CategoryId)
    VALUES (p_product_id, p_category_id);

END;

DROP PROCEDURE IF EXISTS DeleteProductCategories;
CREATE PROCEDURE DeleteProductCategories (
    IN p_productId INT
)
BEGIN
    DELETE FROM ProductCategories WHERE ProductId = p_productId;
END ;

DROP PROCEDURE IF EXISTS GetProductCategories;
CREATE PROCEDURE GetProductCategories (
    IN p_productId INT
)
BEGIN
    SELECT c.Name AS CategoryName
    FROM Categories c
    INNER JOIN ProductCategories pc ON c.Id = pc.CategoryId
    WHERE pc.ProductId = p_productId;
END;

DROP PROCEDURE IF EXISTS GetAllProductCategories;
CREATE PROCEDURE GetAllProductCategories()
BEGIN
    SELECT 
        pc.ProductId,
        c.Id as CategoryId,
        c.Name as CategoryName
    FROM 
        ProductCategories pc
    JOIN 
        Categories c ON pc.CategoryId = c.Id;
END;
