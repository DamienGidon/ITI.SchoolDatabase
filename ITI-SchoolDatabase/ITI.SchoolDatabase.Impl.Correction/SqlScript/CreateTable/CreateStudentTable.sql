USE [itiSchoolDB]

CREATE TABLE [dbo].[Student](
	[Guid] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](150) NOT NULL,
	[Semestre] [int] NOT NULL,
	[Orientation] [nvarchar](2) NULL,
	[BirthDate] [date] NOT NULL,
	[MainTeacher] [uniqueidentifier] NULL FOREIGN KEY REFERENCES Teacher(Guid)
	);



