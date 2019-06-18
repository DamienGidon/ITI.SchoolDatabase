-- Find all people whose teacher is born in 1973-11-17
use itiSchoolDB
SELECT S.Name
FROM [dbo].[Student] S
INNER JOIN [dbo].[Teacher] T on T.[Guid] = S.MainTeacher
where T.BirthDate = '1973-11-17';

-- Return classroom where you can find Student whose name starts with "Thibau" when they are with their MainTeacher
GO
use itiSchoolDB
SELECT C.Name
FROM Classroom C
INNER JOIN Teacher T on T.[Guid] = C.Teacher
INNER JOIN Student S on S.MainTeacher = T.[Guid]
WHERE S.Name Like 'Thibau%'

-- Return Teachers's courses Who Have At Least One Student
GO
use itiSchoolDB
select T.Course from  Teacher T
where T.[Guid] in 
(select MainTeacher from Student) 

-- Get all Classroom with a projector and with a teacher in IL in alphabetical order
GO
use itiSchoolDB
Select C.* from Classroom C
INNER JOIN Teacher T on T.Guid = C.Teacher
where C.Projector = 1 AND T.Orientation = 'IL'
order by Name ASC

