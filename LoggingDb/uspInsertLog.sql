CREATE PROCEDURE [dbo].[uspInsertLog]
		   @log_date							DATETIME,
           @log_level                           VARCHAR(10),
           @log_message                         NVARCHAR(MAX),
           @host                                NVARCHAR(63),
           @reference_id						UNIQUEIDENTIFIER,
           @inputs                              NVARCHAR(MAX),
           @exception                           NVARCHAR(MAX)
AS
	BEGIN
      
 
       DECLARE @sql NVARCHAR(MAX);
       DECLARE @sql_params NVARCHAR(MAX);
      
      INSERT INTO Log
           (
            [log_date]
           ,[log_level]
           ,[log_message]
           ,[host]
           ,[reference_id]
           ,[inputs]
           ,[exception])
     VALUES(
            @log_date
           ,@log_level
           ,@log_message
           ,@host
           ,@reference_id
           ,@inputs
           ,@exception)
END
 
GO
