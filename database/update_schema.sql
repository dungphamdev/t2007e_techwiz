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


select * from Restaurants