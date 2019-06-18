-- Creer une proc qui prend une liste en param et qui va incrementer le semestre de tous les élèves qui ne sont pas dans cette liste. Elle retournera les élèves qui on dépassé le S10 avant de les delete
use itiSchoolDB
GO
DROP PROC IF EXISTS UpStudent
GO
DROP TYPE IF EXISTS StudentList
GO
CREATE TYPE StudentList AS TABLE ( Name Varchar(50) );
GO
CREATE PROCEDURE UpStudent
@Students StudentList READONLY
AS
BEGIN
UPDATE Student SET Semestre = Semestre + 1 WHERE Name NOT IN (Select Name FROM @Students)
SELECT * FROM Student WHERE Semestre > 10
DELETE Student WHERE Semestre > 10
END