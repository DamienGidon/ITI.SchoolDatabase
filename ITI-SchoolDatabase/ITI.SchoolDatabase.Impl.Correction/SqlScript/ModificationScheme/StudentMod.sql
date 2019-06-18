-- Créer les colonnes Firstname, Lastname dans la table Student
USE itiSchoolDB
ALTER TABLE Student
ADD Firstname VARCHAR(255), Lastname VARCHAR(255);
GO
-- Remplir Firstname Lastname à partir du name
 UPDATE Student 
 SET Firstname = (Select SUBSTRING([Name], 1, CHARINDEX(' ', [Name]) - 1)), 
 Lastname = (SUBSTRING([Name], CHARINDEX(' ', [Name]) + 1, LEN([Name]) - CHARINDEX(' ', [Name])))
