CREATE PROCEDURE sp_GetAuthorById
    @id INT
AS
BEGIN
    SELECT * FROM Authors WHERE AuthorId = @id
END