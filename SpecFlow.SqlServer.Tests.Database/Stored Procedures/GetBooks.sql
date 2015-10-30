CREATE PROCEDURE [dbo].[GetBooks]
AS
BEGIN
	SELECT
		Book.Title,
		Author.FirstName + ' ' + Author.LastName AS AuthorName
	FROM
		dbo.Book
		INNER JOIN dbo.Author ON Author.AuthorId = Book.AuthorId
END
