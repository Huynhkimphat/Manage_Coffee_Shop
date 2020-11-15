-- USE MASTER
-- DROP DATABASE COFFEE_MANAGE
-- CREATE DATABASE COFFEE_MANAGE

-- USE COFFEE_MANAGE

-- GO
-- --FOOD
-- --TABLE
-- --FOOD CATEGORY
-- --ACCOUNT
-- --BILL
-- --BILLINFO
-- DROP TABLE TABLEFOOD
-- CREATE TABLE TABLEFOOD
-- (
--     id     INT           IDENTITY PRIMARY KEY,
--     name   NVARCHAR(100) NOT NULL DEFAULT N'Unknown Table',
--     status NVARCHAR(100) NOT NULL DEFAULT 'Empty',-- Empty|| Already
-- )
-- GO
-- CREATE TABLE ACCOUNT
-- (
--     UserName    NVARCHAR(100)  PRIMARY KEY,
--     DisplayName NVARCHAR(100)  NOT NULL DEFAULT N'HKP',
--     Password    NVARCHAR(1000) NOT NULL DEFAULT 0,
--     Type        INT            NOT NULL DEFAULT 0,-- 1:Admin|| 0: Staff
-- )
-- GO
-- CREATE TABLE FOODCATEGORY
-- (
--     id   INT           IDENTITY PRIMARY KEY,
--     name NVARCHAR(100) NOT NULL DEFAULT N'Unknown Foodcategory'
-- )
-- GO
-- CREATE TABLE FOOD
-- (
--     id         INT           IDENTITY PRIMARY KEY,
--     name       NVARCHAR(100) NOT NULL DEFAULT N'Unknown Food',
--     idCategory int           NOT NULL,
--     price      float         NOT NULL DEFAULT 0,
--     FOREIGN KEY(idCategory) REFERENCES FOODCATEGORY(id)
-- )
-- GO
-- CREATE TABLE BILL
-- (
--     id           INT  IDENTITY PRIMARY KEY,
--     DateCheckIn  DATE NOT NULL DEFAULT GETDATE(),
--     DateCheckOut DATE,
--     idTable      INT  NOT NULL,
--     status       INT  NOT NULL DEFAULT 0,
--     -- 1:Paid||0:Not Paid Yet 
--     FOREIGN KEY (idTable) REFERENCES TABLEFOOD(id)
-- )
-- ALTER TABLE BILL
-- ADD FOREIGN KEY(idTable) REFERENCES TABLEFOOD(id)
-- GO

-- EXEC sp_fkeys 'TABLEFOOD'
-- ALTER TABLE BILL
-- DROP CONSTRAINT FK__BILL__idTable__6A30C649;




-- CREATE TABLE BILLINFO
-- (
--     id     INT IDENTITY PRIMARY KEY,
--     idBill INT NOT NULL,
--     idFood INT NOT NULL,
--     count  int NOT NULL DEFAULT 0,
--     FOREIGN KEY (idBill) REFERENCES BILL(id),
--     FOREIGN KEY (idFood) REFERENCES FOOD(id),
-- )
-- GO
-- USE COFFEE_MANAGE

-- INSERT INTO ACCOUNT
-- VALUES('hkimphat', 'huynhkimphat', 'kimphat2001', 1)

-- INSERT INTO ACCOUNT
-- VALUES('staff', 'staff', '1', 0)

-- INSERT INTO ACCOUNT
-- VALUES('1', 'admin', '1', 1)
-- SELECT *
-- FROM ACCOUNT


-- CREATE PROC USP_GetAccountByUserName
--     @userName nvarchar(100)
-- AS
-- BEGIN
--     SELECT *
--     FROM ACCOUNT
--     WHERE UserName=@userName
-- END
-- GO

-- EXEC USP_GetAccountByUserName @userName="hkimphat"


-- SELECT *
-- FROM ACCOUNT
-- WHERE UserName='hkimphat' AND Password='kimphat2001'



-- CREATE PROC USP_Login
--     @userName nvarchar(100),
--     @password nvarchar(1000)
-- AS
-- BEGIN
--     SELECT *
--     FROM ACCOUNT
--     WHERE UserName=@userName AND Password=@password
-- END
-- GO


-- EXEC USP_Login @userName="staff",@password="1"

-- DROP TABLE TABLEFOOD
-- USE COFFEE_MANAGE

-- --Loop to insert faster than each statement
-- --Add table
-- DECLARE @i INT=1
-- WHILE @i <=10
-- BEGIN
--     INSERT INTO TABLEFOOD
--         (name)
--     VALUES('Table'+cast(@i AS nvarchar(100)))
--     SET @i=@i+1
-- END


-- SELECT *
-- FROM TABLEFOOD
-- WHERE id=1

-- CREATE PROC USP_GETTABLELIST
-- AS
-- SELECT *
-- FROM TABLEFOOD
-- GO

-- EXEC USP_GETTABLELIST

-- UPDATE TABLEFOOD
-- SET [status] ='Not Empty'
-- WHERE [id]=8



-- --Add category food
-- INSERT FOODCATEGORY
--     (name)
-- VALUES('Coffee')
-- INSERT FOODCATEGORY
--     (name)
-- VALUES('Ice Blended')
-- INSERT FOODCATEGORY
--     (name)
-- VALUES('Macchiato')
-- INSERT FOODCATEGORY
--     (name)
-- VALUES('Fruit Juice')
-- INSERT FOODCATEGORY
--     (name)
-- VALUES('Chocolate')
-- INSERT FOODCATEGORY
--     (name)
-- VALUES('Breakfast')

-- SELECT *
-- FROM FOODCATEGORY
-- -- ADD FOOD
-- --Coffee
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Traditional Coffee', 1, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Traditional Milk-Coffee', 1, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Cappucino', 1, 40000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Espresso', 1, 40000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Latte', 1, 40000)
-- --Iced Blended
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Traditional Ice Blended', 2, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Traditional Mix Ice Blended', 2, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Ice Blended with Oreo', 2, 40000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Ice Blended with Cake', 2, 40000)
-- UPDATE FOOD SET price =40000 WHERE idCategory=2

-- -- Macchiato
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Matcha Macchiato', 3, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Chocolate Macchiato', 3, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Spring Macchiato', 3, 40000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Winter Macchiato', 3, 40000)

-- -- Fruit Juice
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Apple Juice', 4, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Orange Juice', 4, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Banana Juice', 4, 30000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Orange Juice', 4, 30000)
-- -- Chocolate
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Hot Chocolate', 5, 35000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Cold Chocolate', 5, 35000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Chocolate Bar', 5, 10)

-- -- Breakfast
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Sandwich', 6, 15000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Bread', 6, 12000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Egg', 6, 10000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Toast', 6, 15000)
-- INSERT FOOD
--     (name,idCategory,price)
-- VALUES('Noodle', 6, 15000)

-- SELECT food.name, foodcategory.name
-- FROM FOOD, foodcategory
-- WHERE food.idcategory=foodcategory.id



-- SELECT *
-- FROM ACCOUNT
-- SELECT *
-- FROM TABLEFOOD
-- --ADD BILL
-- INSERT Bill
--     ( DateCheckIn ,DateCheckOut ,idTable ,status)
-- VALUES
--     ( GETDATE() , -- DateCheckIn - date
--         NULL , -- DateCheckOut - date
--         1 , -- idTable - int
--         0  -- status - int
--         )

-- INSERT Bill
--     ( DateCheckIn ,DateCheckOut ,idTable ,status)
-- VALUES
--     ( GETDATE() , -- DateCheckIn - date
--         GETDATE() , -- DateCheckOut - date
--         2 , -- idTable - int
--         1  -- status - int
--         )

-- INSERT Bill
--     ( DateCheckIn ,DateCheckOut ,idTable ,status)
-- VALUES
--     ( GETDATE() , -- DateCheckIn - date
--         NULL , -- DateCheckOut - date
--         3 , -- idTable - int
--         0  -- status - int
--         )

-- SELECT *
-- FROM BILL
-- SELECT *
-- FROM food
-- -- ADD BILL INFO
-- INSERT	BillInfo
--     ( idBill, idFood, count )
-- VALUES
--     ( 1, -- idBill - int
--         1, -- idFood - int
--         2  -- count - int
--           )
-- INSERT	BillInfo
--     ( idBill, idFood, count )
-- VALUES
--     ( 1, -- idBill - int
--         3, -- idFood - int
--         4  -- count - int
--           )
-- INSERT	BillInfo
--     ( idBill, idFood, count )
-- VALUES
--     ( 1, -- idBill - int
--         5, -- idFood - int
--         1  -- count - int
--           )
-- INSERT	BillInfo
--     ( idBill, idFood, count )
-- VALUES
--     ( 2, -- idBill - int
--         1, -- idFood - int
--         2  -- count - int
--           )
-- INSERT	BillInfo
--     ( idBill, idFood, count )
-- VALUES
--     ( 2, -- idBill - int
--         6, -- idFood - int
--         2  -- count - int
--           )
-- INSERT	BillInfo
--     ( idBill, idFood, count )
-- VALUES
--     ( 3, -- idBill - int
--         5, -- idFood - int
--         2  -- count - int
--           )
-- SELECT *
-- FROM BILLINFO


-- SELECT *
-- FROM BILL
-- WHERE BILL.idTable=3 AND Bill.[status]=0


-- SELECT *
-- FROM BILLINFO
-- WHERE idBill=3


-- SELECT f.name AS Name, bi.[count] AS count, f.price AS price, f.price*bi.[count] AS total
-- FROM BILLINFO AS bi, BILL AS b, Food AS f
-- WHERE bi.idBill=b.id AND bi.idFood=f.id AND b.idTable='1'

-- USE COFFEE_MANAGE
-- GO

-- ALTER PROC USP_INSERTBILL
--     @idTable INT
-- AS
-- BEGIN
--     INSERT BILL
--         (idTable,DISCOUNT)
--     VALUES(@idTable, 0)
-- END
-- GO

-- CREATE PROC USP_INSERTBILLINFO
--     @idBill INT,
--     @iDFood INT,
--     @count INT
-- AS
-- BEGIN
--     INSERT	BillInfo
--         ( idBill, idFood, count )
--     VALUES
--         ( @idBill, @iDFood, @count  )
-- END
-- GO

-- SELECT MAX(id)
-- FROM Bill

-- GO


-- USE COFFEE_MANAGE
-- GO
-- ALTER PROC USP_INSERTBILLINFO
--     @idBill INT,
--     @iDFood INT,
--     @count INT
-- AS
-- BEGIN
--     DECLARE @isExistBillInfo INT
--     DECLARE @foodCount INT = 1
--     SELECT @isExistBillInfo =id, @foodCount=bi.count
--     FROM billinfo AS bi
--     WHERE idBill = @idBill
--         AND idFood=@idFood

--     IF (@isExistBillInfo>0)
--     BEGIN
--         DECLARE @newCount INT =@foodCount+@count
--         IF (@newCount>0)
--             UPDATE billinfo SET count=@foodCount+@count WHERE idFood=@idFood AND idBill=@idBill
--         ELSE
--             DELETE BILLINFO WHERE idBill=@idBill AND idFood=@iDFood
--     END
--     ELSE 
--     BEGIN
--         INSERT	BillInfo
--             ( idBill, idFood, count )
--         VALUES
--             ( @idBill, @iDFood, @count  )
--     END

-- END
-- GO


-- UPDATE bill SET bill.[status]=0 WHERE id=1

-- SELECT *
-- FROM bill


-- USE COFFEE_MANAGE
-- GO
ALTER TRIGGER UTG_UPDATEBILLINFO 
ON BILLINFO 
FOR INSERT, UPDATE
AS 
BEGIN
    DECLARE @idBill INT

    SELECT @idBill=idBill
    FROM Inserted

    DECLARE @idTable INT

    SELECT @idTable=idTable
    FROM Bill
    WHERE id=@idBill AND bill.[status]=0

    DECLARE @count int

    SELECT @count=count(*)
    FROM billinfo
    WHERE idBill=@idBill

    IF @count>0
        UPDATE TABLEFOOD SET TABLEFOOD.[status]='Not Empty' WHERE id=@idTable
    ELSE
        UPDATE TABLEFOOD SET TABLEFOOD.[status]='Empty' WHERE id=@idTable
END
GO


-- ALTER TRIGGER UTG_UPDATEBILL
-- ON BILL
-- FOR UPDATE
-- AS
-- BEGIN
--     DECLARE @idBill INT

--     SELECT @idBill=id
--     FROM Inserted

--     DECLARE @idTable INT

--     SELECT @idTable=idTable
--     FROM Bill
--     WHERE id=@idBill


--     DECLARE @count INT = 0

--     SELECT @count=count(*)
--     FROM bill
--     WHERE idTable=@idTable AND bill.[status]=0

--     IF(@count=0)
--         UPDATE TABLEFOOD SET TABLEFOOD.[status]='Empty' WHERE id=@idTable
-- END
-- GO


-- SELECT *
-- FROM TABLEFOOD


-- ALTER TABLE BILL ADD DISCOUNT INT


-- UPDATE BILL SET DISCOUNT=0

-- SELECT *
-- FROM BILL   


GO
ALTER PROC USP_SWITCHTABLE
    @idTable1 INT,
    @idTable2 INT
AS
BEGIN

    DECLARE @idFirstBill int
    DECLARE @idSecondBill int

    DECLARE @isFirstTableEmpty int =1
    DECLARE @isSecondTableEmpty int =1

    SELECT @idFirstBill=id
    FROM Bill
    WHERE idTable=@idTable1 AND Bill.[status]=0

    SELECT @idSecondBill=id
    FROM Bill
    WHERE idTable=@idTable2 AND Bill.[status]=0


    IF(@idFirstBill IS NULL)
    BEGIN
        INSERT INTO bill
            (idTable,status)
        VALUES
            (@idTable1, 0)


        SELECT @idFirstBill=max(id)
        FROM bill
        WHERE idTable=@idTable1 AND Bill.[status]=0

        SET @isFirstTableEmpty=1
    END

    SELECT @isFirstTableEmpty=count(*)
    FROM billinfo
    WHERE idBill=@idFirstBill

    IF(@idSecondBill IS NULL)
    BEGIN
        INSERT INTO bill
            (idTable,status)
        VALUES
            (@idTable2, 0)


        SELECT @idSecondBill=max(id)
        FROM bill
        WHERE idTable=@idTable2 AND Bill.[status]=0

        SET @isSecondTableEmpty=1
    END

    SELECT @isSecondTableEmpty=count(*)
    FROM billinfo
    WHERE idBill=@idSecondBill

    SELECT id
    INTO IDBillInfoTable
    FROM BILLINFO
    WHERE idBill=@idSecondBill

    UPDATE BILLINFO SET idBill=@idSecondBill WHERE idBill=@idFirstBill

    UPDATE BILLINFO SET idBill=@idFirstBill WHERE id IN(
        SELECT *
    FROM IDBillInfoTable)

    DROP TABLE IDBillInfoTable

    IF(@isFirstTableEmpty=0)
        UPDATE TABLEFOOD SET tablefood.[status]='Empty' WHERE id=@idTable2
    IF(@isSecondTableEmpty=0)
        UPDATE TABLEFOOD SET tablefood.[status]='Empty' WHERE id=@idTable1

END
GO

DELETE FROM BILL

ALTER TABLE BILL ADD totalPrice FLOAT

DELETE BILL

SELECT *
FROM bill

UPDATE TABLEFOOD SET tablefood.[status]='Empty'

GO

USE COFFEE_MANAGE
GO

ALTER PROC USP_GETLISTVIEWBYDATE
    @checkin DATE,
    @checkout DATE
AS
BEGIN
    SELECT tf.Name AS [Table], b.DateCheckOut, b.DateCheckOut, b.DISCOUNT AS Discount, b.totalPrice AS [TotalPrice(.000 VND)]
    FROM BILL b, TABLEFOOD tf
    WHERE DateCheckIn >=@checkin
        AND DateCheckOut<=@checkout
        AND b.[status]=1
        AND b.idTable=tf.id
END
GO


CREATE PROC USP_UpdataAccount
    @username NVARCHAR(100),
    @DisplayName NVARCHAR(100),
    @password NVARCHAR(100),
    @newPassword NVARCHAR(100)
AS
BEGIN
    DECLARE @isRightPass INT = 1
    SELECT @isRightPass =COUNT(*)
    FROM ACCOUNT
    WHERE username = @username AND password = @password
    IF(@isRightPass=1)
        BEGIN
        IF(@newPassword IS NULL OR @newPassword='')
        BEGIN
            UPDATE ACCOUNT SET DisplayName=@DisplayName WHERE UserName=@userName
        END
        ELSE
            UPDATE ACCOUNT SET Account.DisplayName=@DisplayName, Account.[Password]=@newPassword WHERE Account.UserName=@userName
    END
END


GO
CREATE TRIGGER UTG_DELETEBILLINFO
ON BILLINFO FOR DELETE
AS 
BEGIN
    DECLARE @idBillInfo int
    DECLARE @idBill int
    SELECT @idBillInfo=id, @idBill=deleted.idBill
    FROM deleted

    DECLARE @idTable int
    SELECT @idTable=idTable
    FROM bill
    WHERE id=@idBill

    DECLARE @count int=0
    SELECT @count=count(*)
    FROM billinfo AS bi, bill AS b
    WHERE b.id=bi.idBill AND b.id=@idBill AND b.[status]=0

    IF (@count=0)
        UPDATE TABLEFOOD SET tablefood.[status]='Empty' WHERE id=@idTable
END
GO

SELECT *
FROM FOODCATEGORY

SELECT *
FROM FOOD

DELETE food WHERE id=4

SELECT id
FROM food
WHERE idCategory=5

USE COFFEE_MANAGE
SELECT DISTINCT status
FROM TABLEFOOD



