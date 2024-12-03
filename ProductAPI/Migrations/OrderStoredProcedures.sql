DROP PROCEDURE IF EXISTS AddOrder;
CREATE PROCEDURE AddOrder (
    IN p_productId INT,
    IN p_price DECIMAL(10, 2),
    IN p_quantity INT,
    IN p_amount DECIMAL(10, 2),
    IN p_create_date DATETIME
)
BEGIN

    INSERT INTO Orders (ProductId, Price, Quantity, Amount, CreateDate)
    VALUES (p_productId, p_price, p_quantity, p_amount,p_create_date);

END;

DROP PROCEDURE IF EXISTS DecreaseStock;
CREATE PROCEDURE DecreaseStock (
    IN p_productId INT,
    IN p_newStock INT
)
BEGIN
 
    UPDATE Stocks 
    SET Stock =Stock - p_newStock
    WHERE ProductId = p_productId;
END;

DROP PROCEDURE IF EXISTS GetStock;
CREATE PROCEDURE GetStock (
	IN p_productId INT
)
BEGIN
	SELECT Stock
	FROM Stocks
	WHERE ProductId = p_productId;
END;
