-- Créer les colonnes Firstname, Lastname dans la table Teacher et les remplir uniquement pour les profs nés après 1975
USE itiSchoolDB
ALTER TABLE Teacher
ADD Firstname VARCHAR(255), Lastname VARCHAR(255);
GO
 UPDATE Teacher 
 SET Firstname = (Select SUBSTRING([Name], 1, CHARINDEX(' ', [Name]) - 1)), 
 Lastname = (SUBSTRING([Name], CHARINDEX(' ', [Name]) + 1, LEN([Name]) - CHARINDEX(' ', [Name])))
 WHERE BirthDate > Convert(date, '1975-12-12' )
