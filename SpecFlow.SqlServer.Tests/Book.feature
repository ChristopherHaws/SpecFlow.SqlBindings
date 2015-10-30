Feature: Book Feature
	As a librarian
	I want to be able to add books to the library
	So that I can keep track of what books the library owns

Scenario: Get Books
	Given I have the following data in the 'dbo.Author' table
    | Id | FirstName | LastName |
    | 1  | J.K.      | Rowling  |
	And I have the following data in the 'dbo.Book' table
	| Title                                    | AuthorId |
	| Harry Potter and the Sorcerer's Stone    | 1        |
	| Harry Potter and the Chamber of Secerets | 1        |
	When I execute 'dbo.GetBooks'
	Then I want ResultSet 1 to be
	| Title                                    | AuthorName   |
	| Harry Potter and the Sorcerer's Stone    | J.K. Rowling |
	| Harry Potter and the Chamber of Secerets | J.K. Rowling |