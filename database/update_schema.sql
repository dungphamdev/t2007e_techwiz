IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Restaurants]') 
         AND name = 'ImagePath'
)
BEGIN
	ALTER TABLE Restaurants
	ADD ImagePath nvarchar(255);
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Restaurants]') 
         AND name = 'ImageType'
)
BEGIN
	ALTER TABLE Restaurants
	ADD ImageType nvarchar(255);
END

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[OrderDetails]') 
         AND name = 'OrderDetailId'
)
BEGIN
	ALTER TABLE OrderDetails
	ADD OrderDetailId  int identity(1,1) PRIMARY KEY
END
GO

IF EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[OrderDetails]') 
         AND name = 'OrderItemQty'
)
BEGIN
	ALTER TABLE OrderDetails
	DROP COLUMN OrderItemQty;
END
GO

IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[OrderDetails]') 
         AND name = 'OrderItemQty'
)
BEGIN
	ALTER TABLE OrderDetails
	ADD OrderItemQty int;
END
GO

