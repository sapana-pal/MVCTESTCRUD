CREATE TABLE [dbo].[tblCust]  
(  
[CustomerID] [int] NOT NULL Primary key identity(1,1),  
[Name] [varchar](100) NULL,  
[Active] [bit] NULL,  
[date] [datetime] NULL,  
)



--================================SP======================================


USE [CustomerDB]  
GO  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
--CREATE PROCEDURE [dbo].[Usp_InsertUpdateDelete_Customer]
ALTER PROCEDURE [dbo].[Usp_InsertUpdateDelete_Customer]  
@CustomerID INT = NULL  
,@Name NVARCHAR(100) = NULL  
,@Active bit = 0  
,@date DATETIME = NULL  
,@Query INT  
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  

INSERT INTO tblCust(  
NAME  
,Active 
,date  
)  
VALUES (  
@Name  
,@Active  
,@date  
)  
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END  
IF (@Query = 2)  
BEGIN  
UPDATE tblCust  
SET NAME = @Name  
,Active = @Active  
,date = @date  
WHERE tblCust.CustomerID = @CustomerID  
SELECT 'Update'  
END  
IF (@Query = 3)  
BEGIN  
DELETE  
FROM tblCust  
WHERE tblCust.CustomerID = @CustomerID  
SELECT 'Deleted'  
END  
IF (@Query = 4)  
BEGIN  
SELECT *  
FROM tblCust  
END  
END  
IF (@Query = 5)  
BEGIN  
SELECT *  
FROM tblCust  
WHERE tblCust.CustomerID = @CustomerID  
END 
IF (@Query = 6)  
BEGIN  
SELECT *  
FROM tblCust  
WHERE Active=1 
END 



--==============================get all active data==========
CREATE PROCEDURE [GetActiveData]
@CustomerID uniqueidentifier,
@Active bit
AS
BEGIN
SELECT 
*
FROM tblCust
WHERE CustomerID=@CustomerID and Active= @Active 
END
GO


select * from tblCust where Active=1