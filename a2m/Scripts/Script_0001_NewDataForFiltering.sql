USE [a2m]
GO
SET IDENTITY_INSERT [dbo].[Business] ON 

INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (15, N'Burguer la Isla2                                   ', N'918134340   ', NULL, 2, N'Plaza de España                                                                                                                                                                                         ', 1, N'burguer_laisla@a2m.com                            ', N'www.facebook.com/burguer.laisla                   ', 10.0000, 0, 0, 1.0000, 0, 1, 200.0000, CAST(0x0000A4D700000000 AS DateTime), N'1ffe630a35c9ed590c4592e50a6077c3157878a9', 0, 0, NULL, NULL, NULL, NULL)

INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (16, N'El Torito Pizzeria2                                ', N'658238091   ', NULL, 7, N'C/Sevillanos, 18. Local A                                                                                                                                                                               ', 1, N'burguer_laisla@a2m.com                            ', NULL, 15.0000, 1, 1, 0.0000, 1, 1, 200.0000, CAST(0x0000A4CE0107AC00 AS DateTime), N'7322b29613137680ef62fc081da96a77beb23d57', 1, 0, NULL, NULL, NULL, NULL)

INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (17, N'Burguer la Isla3                                   ', N'918134340   ', NULL, 2, N'Plaza de España                                                                                                                                                                                         ', 1, N'burguer_laisla@a2m.com                            ', N'www.facebook.com/burguer.laisla                   ', 10.0000, 0, 1, 1.0000, 0, 1, 200.0000, CAST(0x0000A4D700000000 AS DateTime), N'1ffe630a35c9ed590c4592e50a6077c3157878a9', 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (18, N'El Torito Pizzeria3                                ', N'658238091   ', NULL, 7, N'C/Sevillanos, 18. Local A                                                                                                                                                                               ', 1, N'burguer_laisla@a2m.com                            ', NULL, 15.0000, 1, 1, 0.0000, 1, 1, 200.0000, CAST(0x0000A4CE0107AC00 AS DateTime), N'7322b29613137680ef62fc081da96a77beb23d57', 0, 1, NULL, NULL, NULL, NULL)

INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (19, N'El Torito Pizzeria4                                ', N'658238091   ', NULL, 7, N'C/Sevillanos, 18. Local A                                                                                                                                                                               ', 1, N'burguer_laisla@a2m.com                            ', NULL, 15.0000, 1, 1, 0.0000, 1, 1, 200.0000, CAST(0x0000A4CE0107AC00 AS DateTime), N'7322b29613137680ef62fc081da96a77beb23d57', 0, 1, NULL, NULL, NULL, NULL)



INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (20, N'El Torito Pizzeria5                                ', N'658238091   ', NULL, 7, N'C/Sevillanos, 18. Local A                                                                                                                                                                               ', 1, N'burguer_laisla@a2m.com                            ', NULL, 15.0000, 0, 1, 0.0000, 1, 1, 200.0000, CAST(0x0000A4CE0107AC00 AS DateTime), N'7322b29613137680ef62fc081da96a77beb23d57', 0, 0, NULL, NULL, NULL, NULL)


SET IDENTITY_INSERT [dbo].[Business] OFF

GO

-- Test autoupdate
UPDATE [dbo].[DatabaseVersion]  SET [Version] = N'0.0.1' WHERE 'N' = 'N'
GO

