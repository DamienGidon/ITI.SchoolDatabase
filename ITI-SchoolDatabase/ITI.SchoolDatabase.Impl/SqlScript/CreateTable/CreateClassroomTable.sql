USE [itiSchoolDB]

CREATE TABLE [dbo].[Classroom](
	[Guid] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](4) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Projector] [bit] NOT NULL,
	[Teacher] [uniqueidentifier] NULL FOREIGN KEY REFERENCES Teacher(Guid)
);



