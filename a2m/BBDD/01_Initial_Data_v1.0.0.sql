USE [a2m]
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([Pk_Schedule], [Day_Week], [Time_Mask], [Fk_Business]) VALUES (2, N'1111111', N'1111111111111111111111111111111111111111111111  ', 1)
INSERT [dbo].[Schedule] ([Pk_Schedule], [Day_Week], [Time_Mask], [Fk_Business]) VALUES (7, N'1111111', N'11111111111111111111111111111111111111111111111 ', 12)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
INSERT [dbo].[Business_Status] ([Pk_Business_Status], [Name]) VALUES (1, N'Activo              ')
INSERT [dbo].[Business_Status] ([Pk_Business_Status], [Name]) VALUES (2, N'Inactivo            ')
INSERT [dbo].[Business_Status] ([Pk_Business_Status], [Name]) VALUES (3, N'Pendiente           ')
INSERT [dbo].[Business_Status] ([Pk_Business_Status], [Name]) VALUES (4, N'Bloqueado           ')
SET IDENTITY_INSERT [dbo].[Municipality_Status] ON 

INSERT [dbo].[Municipality_Status] ([Pk_Municipality_Status], [Name]) VALUES (1, N'Activo              ')
INSERT [dbo].[Municipality_Status] ([Pk_Municipality_Status], [Name]) VALUES (2, N'Inactivo            ')
SET IDENTITY_INSERT [dbo].[Municipality_Status] OFF
SET IDENTITY_INSERT [dbo].[Municipality] ON 

INSERT [dbo].[Municipality] ([Pk_Municipality], [Name], [Postal_Code], [Fk_Municipality_Status]) VALUES (1, N'Sevilla la Nueva                                  ', N'28609', 1)
SET IDENTITY_INSERT [dbo].[Municipality] OFF
SET IDENTITY_INSERT [dbo].[Business] ON 

INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (6, N'Burguer la Isla                                   ', N'918134340   ', NULL, 2, N'Plaza de España                                                                                                                                                                                         ', 1, N'burguer_laisla@a2m.com                            ', N'www.facebook.com/burguer.laisla                   ', 10.0000, 1, 1, 1.0000, 1, 1, 200.0000, CAST(0x0000A4D700000000 AS DateTime), N'1ffe630a35c9ed590c4592e50a6077c3157878a9', 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Business] ([Pk_Business], [Name], [Phone], [Alternate_Phone], [Fk_Schedule], [Address], [Fk_Municipality], [Email], [Webpage], [Min_Price_For_Shipping], [Allow_Shipping], [Allow_PickUp], [Shipping_Cost_If_Not_Min_Price], [Allow_Shipping_Not_Enougth_Amount], [Fk_Business_Status], [Max_Order_Price_Allowed], [Creation_Date], [Password], [Is_A2M], [Has_Pdf], [Pdf_Last_Update], [Lat], [Lon], [Description]) VALUES (12, N'El Torito Pizzeria                                ', N'658238091   ', NULL, 7, N'C/Sevillanos, 18. Local A                                                                                                                                                                               ', 1, NULL, NULL, 15.0000, 1, 1, 0.0000, 1, 1, 200.0000, CAST(0x0000A4CE0107AC00 AS DateTime), N'7322b29613137680ef62fc081da96a77beb23d57', 1, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Business] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (1, N'Bebidas                                           ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (2, N'Entrantes                                         ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (3, N'Para picar                                        ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (4, N'Menús                                             ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (5, N'Pizzas                                            ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (6, N'Bocadillos                                        ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (7, N'Platos combinados                                 ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (8, N'Perritos calientes                                ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (9, N'Arroces                                           ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (10, N'Hamburguesas                                      ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (11, N'Sandwiches                                        ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (12, N'Raciones                                          ', NULL)
INSERT [dbo].[Categories] ([Pk_Product_Category], [Name], [Fk_Business]) VALUES (13, N'Postres                                           ', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Order_Status] ON 

INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (1, N'Nuevo               ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (2, N'Recibido            ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (3, N'Procesando          ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (4, N'Enviado             ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (5, N'Finalizado          ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (6, N'Erro                ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (7, N'Anulado             ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (8, N'Moroso              ')
INSERT [dbo].[Order_Status] ([Pk_Order_Status], [Name]) VALUES (9, N'Rechazado           ')

SET IDENTITY_INSERT [dbo].[Order_Status] OFF
SET IDENTITY_INSERT [dbo].[Customer_Status] ON 

INSERT [dbo].[Customer_Status] ([Pk_Status], [Name]) VALUES (1, N'Activo              ')
INSERT [dbo].[Customer_Status] ([Pk_Status], [Name]) VALUES (2, N'Inactivo            ')
INSERT [dbo].[Customer_Status] ([Pk_Status], [Name]) VALUES (3, N'Pendiente           ')
INSERT [dbo].[Customer_Status] ([Pk_Status], [Name]) VALUES (4, N'Bloqueado           ')
SET IDENTITY_INSERT [dbo].[Customer_Status] OFF
SET IDENTITY_INSERT [dbo].[Special_Food_Categories] ON 

INSERT [dbo].[Special_Food_Categories] ([Pk_Special_Food], [Name]) VALUES (1, N'Apta para Celíacos                                ')
INSERT [dbo].[Special_Food_Categories] ([Pk_Special_Food], [Name]) VALUES (2, N'Vegana                                            ')
INSERT [dbo].[Special_Food_Categories] ([Pk_Special_Food], [Name]) VALUES (3, N'Vegetariana                                       ')
INSERT [dbo].[Special_Food_Categories] ([Pk_Special_Food], [Name]) VALUES (4, N'Picante                                           ')
INSERT [dbo].[Special_Food_Categories] ([Pk_Special_Food], [Name]) VALUES (5, N'Niños                                             ')
INSERT [dbo].[Special_Food_Categories] ([Pk_Special_Food], [Name]) VALUES (6, N'Alcohol                                           ')
SET IDENTITY_INSERT [dbo].[Special_Food_Categories] OFF
INSERT [dbo].[DatabaseVersion] ([Version]) VALUES (N'0.0.0')
