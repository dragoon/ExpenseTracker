This is a very basic expense tracking application, with just 2 pages: first page list all the expenses and allows to add a new one, and then an extra page to confirm the deletion.

I have made a number of shortcuts in order to save some time and keep the project small, which I would otherwise not do:
* There is not REST API at the moment, the app is based on .NET Razor pages
* I have used expense model as both db and a view model. Normally a separate class should be used for a view model to separate validation logic and, for example, virtual fields.
* I haven't used repository/service pattern to keep the db logic in repositories and business logic in services. That would allow for a proper unit testing. Here the db logic lives directly in page models


Possible next steps:
* Allow creation of ExpenseTypes, ideally directly from the add expenses form.
* List of expenses can be paged or include a search field for a specific date/range
* Adding receipt attachments
* User should be selected as the currently logged in, but possibility to specify a different one should be kept, e.g. for entering for someone else (assistant)
* Users should be read from a LDAP directory or other source