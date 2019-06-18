USE [itiSchoolDB]
INSERT INTO Student (Guid, Name,Semestre,Orientation,BirthDate, MainTeacher )
 VALUES
 (NEWID(), 'Thibault Cam',10,'IL', '1994-02-21', (select guid from Teacher where name = 'Olivier Spinelli')),
 (NEWID(), 'Thibaud Duval',9,'IL', '1999-07-12', (select guid from Teacher where name = 'Catherine Dorignac')),
 (NEWID(), 'Damien Gidon',10,'IL', '1994-07-02', (select guid from Teacher where name = 'Olivier Spinelli')),
 (NEWID(), 'Pierre Viara',6,'IL', '1995-11-12', (select guid from Teacher where name = 'Antoine Raquillet')),
 (NEWID(), 'Jujou Ani',5,'IL', '1857-8-9', (select guid from Teacher where name = 'Antoine Raquillet')),
 (NEWID(), 'Rodolf Vechter',6,'SR', '1950-01-17', (select guid from Teacher where name = 'Erico Lalita')),
 (NEWID(), 'Kouinox Punchy',3,'SR', '2000-05-07', (select guid from Teacher where name = 'Erico Lalita')),
 (NEWID(), 'Julie Laconépa',9,'IL', '1998-04-08', null),
 (NEWID(), 'Vin Diesel',1,'SR', '1975-08-22', (select guid from Teacher where name = 'Olivier Spinelli')),
 (NEWID(), 'Floriant Dugat',5,'IL', '1922-06-03', null),
 (NEWID(), 'Monique Monrade',1,'IL', '1995-06-03', (select guid from Teacher where name = 'Michèle Talavéra'));