USE [a2m]
GO
-- Test autoupdate
UPDATE [dbo].[DatabaseVersion]  SET [Version] = N'0.0.0' WHERE 'N' = 'N'
GO