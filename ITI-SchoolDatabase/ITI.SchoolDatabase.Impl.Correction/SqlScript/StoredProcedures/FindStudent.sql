-- Create Proc FindStudent taking a string in param (ParamString) and return all student whose name contains the string, The proc must be droped if it already exists
use itiSchoolDB
GO
DROP PROC IF EXISTS FindStudent
GO
CREATE PROCEDURE FindStudent
@ParamString nvarchar(50)
AS
SELECT S.Name FROM Student S Where S.Name LIKE '%' + @ParamString + '%'