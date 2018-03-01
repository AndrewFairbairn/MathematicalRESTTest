# MathematicalRESTTest
Providing and grading mathematical problems using REST

This project consists of an angular web page to allow users to request, answer and score a set of mathematical questions through a C# RESTful service.

The RESTful API is located at _api/Maths_ and is interacted with via __GET__ and __PUT__ requests.

A __GET__ request with no ID generate a new _QuestionSet_ with an ID and a collection of _Question_ objects.
A __GET__ request with an ID (_api/Maths/{id}_) will return an existing _QuestionSet_ or a __NOTFOUND__.
A __PUT__ request expects a _QuestionSet_ with a collection of _Question_ objects to score. It will return the supplied _QuestionSet_ with updated _Question_ objects to indicate whether the supplied answers were correct or not.

A _QuestionSet_ consists of a string __Id__ and a collection of _Question_ objects

A _Question_ object consists of:

* FirstNumber - an integer
* SecondNumber - an integer
* Answer - a nullable decimal
* Remainder - a nullable decimal
* QuestionState - an enum indication whether the question is NotScored/Correct/Incorrect
* QuestionType - an enum indicating whether the question is a Multiplication/Division/DivisionWithRemainder