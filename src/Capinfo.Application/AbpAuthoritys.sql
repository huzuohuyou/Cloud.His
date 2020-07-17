USE [CapinfoDb]
GO

SELECT [Id]
      ,[MoudleName]
      ,[Father]
      ,[Path]
      ,[MenuIcon]
      ,[Title]
      ,[ComponentName]
      ,[Component]
      ,[Permission]
      ,[CreationTime]
      ,[CreatorUserId]
      ,[DeleterUserId]
      ,[DeletionTime]
      ,[DisplayName]
      ,[IsDeleted]
      ,[LastModificationTime]
      ,[LastModifierUserId]
  FROM [dbo].[AbpAuthoritys]
GO

