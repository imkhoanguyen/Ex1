CREATE PROCEDURE sp_FilterBooks
    @SearchKey NVARCHAR(200),
    @AuthorId INT = NULL,
    @FromDate DATETIME = NULL,
    @ToDate DATETIME = NULL,
    @PageSize INT,  
    @PageIndex INT 
AS
BEGIN
    SET NOCOUNT ON;
   
    SELECT * 
    FROM Books
    WHERE
        (@SearchKey IS NULL OR Title LIKE '%' + @SearchKey + '%') 
        AND (@AuthorId IS NULL OR AuthorId = @AuthorId)           
        AND (@FromDate IS NULL OR PublishedDate >= @FromDate)     
        AND (@ToDate IS NULL OR PublishedDate <= @ToDate)          
    ORDER BY BookId DESC 
    OFFSET (@PageIndex - 1) * @PageSize ROWS  
    FETCH NEXT @PageSize ROWS ONLY;
END;
