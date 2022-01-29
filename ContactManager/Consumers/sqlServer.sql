/*
File name: C:/Program Files/Intelligent Converters/demos/.sql
Creation date: 01/28/2022
Created by MySQL to MS SQL 7.5 [Demo]
--------------------------------------------------
More conversion tools at http://www.convert-in.com
*/
SET QUOTED_IDENTIFIER ON;
GO

/*
Table structure for table '[dbo].[contact]'
*/

IF OBJECT_ID ('[dbo].[contact]', 'U') IS NOT NULL
DROP TABLE [dbo].[contact];
GO
CREATE TABLE [dbo].[contact] (
	[id] INT IDENTITY NOT NULL,
	[firstName] NVARCHAR(128)  NOT NULL,
	[lastName] NVARCHAR(128) ,
	[email] NVARCHAR(128)  NOT NULL,
	[dateOfBirth] DATETIME2,
	[phone] NVARCHAR(20)  NOT NULL,
	[OwnerNavigationId] INT NOT NULL
)
GO

/*
Dumping data for table '[dbo].[contact]'
*/

ALTER TABLE [dbo].[contact] ADD PRIMARY KEY([id]) 
GO
CREATE INDEX [fk_contact_user_1] ON [dbo].[contact]([OwnerNavigationId]) 
GO

/*
Table structure for table '[dbo].[role]'
*/

IF OBJECT_ID ('[dbo].[role]', 'U') IS NOT NULL
DROP TABLE [dbo].[role];
GO
CREATE TABLE [dbo].[role] (
	[id] INT IDENTITY NOT NULL,
	[description] NVARCHAR(255) ,
	[name] NVARCHAR(255)  NOT NULL
)
GO

/*
Dumping data for table '[dbo].[role]'
*/

SET IDENTITY_INSERT [dbo].[role] ON;
GO
INSERT INTO [dbo].[role] ([id], [description], [name]) VALUES (1, NULL, N'Client'), (3, NULL, N'Manager'), (4, NULL, N'Project Administrator'), (5, NULL, N'Administrator')
GO

SET IDENTITY_INSERT [dbo].[role] OFF;
GO
ALTER TABLE [dbo].[role] ADD PRIMARY KEY([id]) 
GO

/*
Table structure for table '[dbo].[user]'
*/

IF OBJECT_ID ('[dbo].[user]', 'U') IS NOT NULL
DROP TABLE [dbo].[user];
GO
CREATE TABLE [dbo].[user] (
	[id] INT IDENTITY NOT NULL,
	[firstName] NVARCHAR(128)  NOT NULL,
	[lastName] NVARCHAR(128)  NOT NULL,
	[username] NVARCHAR(60)  NOT NULL,
	[password] NVARCHAR(256)  NOT NULL,
	[email] NVARCHAR(128)  NOT NULL
)
GO

/*
Dumping data for table '[dbo].[user]'
*/

SET IDENTITY_INSERT [dbo].[user] ON;
GO
INSERT INTO [dbo].[user] ([id], [firstName], [lastName], [username], [password], [email]) VALUES (55, N'Yuniet', N'Artiles', N'yartiles', N'$2a$08$U7Q0tQhrrdw3EZYf3f/rn.JNBa4Pu8CxPMOEnSJqK6CdSX7uxzJFS', N'yartiles161195@gmail.com'), (56, N'Arletis', N'Abascal', N'arletis', N'$2a$08$CZwnM0wZ7XIn2JATJszmV.TMMCp2hBu05G9s7QNBcYwdjBAqBLYdW', N'aabascal@gmail.com')
GO

SET IDENTITY_INSERT [dbo].[user] OFF;
GO
ALTER TABLE [dbo].[user] ADD PRIMARY KEY([id]) 
GO
CREATE UNIQUE INDEX [email] ON [dbo].[user]([email])  WHERE [email] IS NOT NULL
GO

/*
Table structure for table '[dbo].[userrole]'
*/

IF OBJECT_ID ('[dbo].[userrole]', 'U') IS NOT NULL
DROP TABLE [dbo].[userrole];
GO
CREATE TABLE [dbo].[userrole] (
	[id] INT IDENTITY NOT NULL,
	[UserId] INT NOT NULL,
	[RoleId] INT NOT NULL
)
GO

/*
Dumping data for table '[dbo].[userrole]'
*/

SET IDENTITY_INSERT [dbo].[userrole] ON;
GO
INSERT INTO [dbo].[userrole] ([id], [UserId], [RoleId]) VALUES (11, 55, 1), (12, 56, 1), (14, 55, 3), (15, 55, 4), (16, 55, 5), (17, 56, 3), (18, 56, 4)
GO

SET IDENTITY_INSERT [dbo].[userrole] OFF;
GO
ALTER TABLE [dbo].[userrole] ADD PRIMARY KEY([id]) 
GO
CREATE INDEX [fk_role_user_role_1] ON [dbo].[userrole]([RoleId]) 
GO
CREATE INDEX [fk_user_user_role_1] ON [dbo].[userrole]([UserId]) 
GO
