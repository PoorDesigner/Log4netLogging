# Log4netLogging

This is a shared library where you can use across several applications you have. 
It contains database project with "create table" script and stored procedure. 
Performs logging asynchronously.
You can find the stats for synchronous and asynchronous logging in "Benchmarks" file.
In this project we are just logging few parameters like 'message','reference id','host'. 
You can add more properties to log just as ReferenceID.


These are steps to add an new property to log

1. Add new column in table.(if you want to log that to database)
2. Update stored procedure
3. Add a new property in Interface "ILogger".
4. Update all the appenders in web/app config file of the project in which you are using this logging library.
 
