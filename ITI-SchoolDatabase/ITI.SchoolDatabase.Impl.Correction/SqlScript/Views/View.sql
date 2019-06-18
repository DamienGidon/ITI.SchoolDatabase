-- Vue qui doit renvoyer la liste de tous les élèves en affichant Le nom de l'élève en tant que 'StudentName', le semestre, l'orientation, le nom de son Prof principal en tant que 'TeacherName'
-- Ainsi que la salle en tant que 'RoomName'
use itiSchoolDB
GO
DROP VIEW IF EXISTS StudentsView
GO
CREATE VIEW StudentsView AS
Select S.Name as StudentName, S.Semestre, S.Orientation, T.Name as TeacherName, C.Name as RoomName FROM Student S
LEFT JOIN Teacher T on t.Guid = S.MainTeacher
LEFT JOIN Classroom C on C.Teacher = T.Guid