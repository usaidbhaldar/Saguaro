saguaro
=======

An ASP.NET MVC4 starter project for Azure Websites & SQLAzure. Features include: an admin area, user management (with SimpleMembership), activity &amp; error logging (using Azure Table Storage), C# Async/Parallels &amp; SendGrid integration.



Settings
========

##Initial Admin Account:

Admin account is created during App_Start inside of: `InitConfig.InitializeData`

WebSecurity.CreateUserAndAccount("admin", "adminPassword");



##Activity Logs:

Activity logs store all actions and log types by: username, ip, time & activity.

Logs are also appended with the name of the current environment being used during the logging activity: (debug/production).

Environment Name & Storage account information is updated inside `Web.Config`. Configuration is accessed using the `EnvironmentSettings` class.

All logging code is within the `Logging` folder and namespace.



##Send Grid & Email Messaging System:


Sendgrid account information is updated inside `Web.Config`.

Configuration is accessed using the `EnvironmentSettings` class.

All email messagng code is within the `Messaging` folder and namespace.

Email variables can be adjusted in the `ProjectSettings` class

===============================================================
