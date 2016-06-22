CREATE TABLE [dbo].[Log]
(
	   [log_id] [bigint] IDENTITY(1,1) NOT NULL,
       [log_date] [datetime] NOT NULL,
       [log_level] [varchar](10) NOT NULL,
       [log_message] [nvarchar](max) NOT NULL,
       [host] [nvarchar](63) NULL,
       [reference_id] [uniqueidentifier] NOT NULL,
       [inputs] [nvarchar](max) NULL,
       [exception] [nvarchar](max) NULL,
)
