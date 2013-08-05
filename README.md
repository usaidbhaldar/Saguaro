Saguaro
=======

An ASP.NET MVC4 starter project for Azure Websites & SQLAzure.

######Features include:

* Admin area with user management (using SimpleMembership)
* Activity &amp; Error Logging (per Environment using Azure Table Storage)
* C# Async & Parallel Library
* Simple Environment Management
* SendGrid integration.



Settings
========



####Data Seeding:

Admin account is seeded during first App_Start inside of: `InitConfig.InitializeData`

    WebSecurity.CreateUserAndAccount("admin", "adminPassword");

UserProfile table is generated inside of `InitConfig.InitializeData` here:

    Sql.SeedStatements.CreateUserProfileTableTask();


####SQL:

All SQL Statements are run from the `Saguaro.Sql` namespace

####Activity Logs:

Activity logs can store all actions and log types by:
* username
* ip
* time
* activity

You can create more LogTypes/ActivityTypes inside `Saguaro.Logging.Types`

Default types include _platform_ & _activity_.

Logs are also appended with the name of the current environment being used during the logging activity: (debug/production).

Example Log Table Names:
* *platformlogbyipdebug* _(platform log by ip debug)_
* *platformlogbyipproduction* _(platform log by ip production)_
* *platformlogbyuserdebug* _(activity log by user debug)_
* *platformlogbyuserproduction* _(activity log by user production)_
* etc....

####Configuration

Environment Name & Storage account information is updated inside `Web.Config`. Configuration is accessed using the `Saguaro.EnvironmentSettings` class.

All logging code is within the `Saguaro.Logging` namespace.




####Send Grid & Email Messaging System:


Sendgrid account information is updated inside `Web.Config`.

Configuration is accessed using the `Saguaro.EnvironmentSettings` class.

All email messagng code is within the `Saguaro.Messaging` namespace.

Email variables can be adjusted in the `Saguaro.ProjectSettings` class

===============================================================
