USE [itiSchoolDB]
CREATE TABLE [dbo].[Teacher](
	[Guid] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](150) NOT NULL,
	[Course] [nvarchar](100) NOT NULL,
	[Orientation] [nvarchar](2) NULL,
	[BirthDate] [date] NOT NULL,
	[IsInternal] [bit] NOT NULL,
);

