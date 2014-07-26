NavigationIdentity2
===================

An implementation of Microsoft's Identity 2 for WebForms using model binding and the Navigation for ASP.NET routing library.

WHAT IS IT?
At its heart, the project is an implementation of Microsoft's standard Identity version 2.0 for WebForms but with some refactoring to try and make the code easier to understand for developers picking up Identity for the first time.

The biggest change is in the use of the Web Forms model binding architecture and the use of the Navigation for ASP.NET URL and routing library (see https://navigation.codeplex.com/).  The combination of these two technologies provides a clean, almost MVC like implementation.

PROJECT HIGHLIGHTS
* Simple Web.config configuration of Two-Factor Authentication including email, SMS and external authentication providers (Facebook, Twitter, Microsoft and Google)

* Demonstrates simple application user data extension (first name, last name etc.) by extending the user model classes (POCOs) and Entity Framework

* Ability to force email authentication - even for externally authenticated accounts
