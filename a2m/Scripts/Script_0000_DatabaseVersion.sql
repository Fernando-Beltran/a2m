USE [a2m]
GO
-- Test autoupdate
UPDATE [dbo].[DatabaseVersion] ([Version]) VALUES (N'0.0.1') WHERE 'N' = 'N'
