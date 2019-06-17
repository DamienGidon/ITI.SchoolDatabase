USE [itiSchoolDB]
INSERT INTO Classroom (Guid, Name, Capacity, Projector, Teacher)
 VALUES
 (NEWID(), 'E07',30,1,(select guid from Teacher where name = 'Olivier Spinelli')),
 (NEWID(), 'EZ02',50,0,null),
 (NEWID(), 'E01',40,1,(select guid from Teacher where name = 'Antoine Raquillet')),
 (NEWID(), 'EZ05',10,0,(select guid from Teacher where name = 'Laurent Huet')),
 (NEWID(), 'E06',100,0,(select guid from Teacher where name = 'Michèle Talavéra')),
 (NEWID(), 'E03',20,1,(select guid from Teacher where name = 'Catherine Dorignac')),
 (NEWID(), 'E04',20,0,(select guid from Teacher where name = 'King Zaman')),
 (NEWID(), 'E02',200,1,(select guid from Teacher where name = 'King Zaman'));
