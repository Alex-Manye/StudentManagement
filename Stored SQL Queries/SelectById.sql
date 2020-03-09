CREATE PROCEDURE GetProductDesc_withparameters
(@sID INT)
AS
BEGIN
SET NOCOUNT ON
 
SELECT s.Studentid,s.Name,s.Surname, s.Birthday  FROM 
Student s
WHERE s.Studentid=@sID
 
END
