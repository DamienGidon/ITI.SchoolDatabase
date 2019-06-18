-- DO NOT TOUCH
USE [itiSchoolDB]
INSERT INTO Teacher (Guid, Name, Course, Orientation,BirthDate, IsInternal)
 VALUES
 (NEWID(), 'Olivier Spinelli','Programmation','IL', '1973-11-17',1),
 (NEWID(), 'Antoine Raquillet','Programmation','IL', '1964-04-12',1),
 (NEWID(), 'Catherine Dorignac','PFH',null, '1877-09-12',1),
 (NEWID(), 'Laurent Huet','Portfolio',null, '2000-01-01',1),
 (NEWID(), 'Liam Francheski','Communication',null, '1952-06-07',0),
 (NEWID(), 'Audite Camara','Java','IL', '1983-12-16',0),
 (NEWID(), 'Erico Lalita','Ex-Dirlo <3','SR', '1976-02-22',1), 
 (NEWID(), 'King Zaman','JavaScript','IL', '1992-02-22',1), 
 (NEWID(), 'Michèle Talavéra','Antiquaire','JC', '0001-01-01',1); 