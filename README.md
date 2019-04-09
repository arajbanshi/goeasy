# goeasy
This is an api application that returns metrics for commuting between 2 NYC boroughs. You can use this api in conjunction with the Angular ui application found at https://github.com/arajbanshi/easygoui.git. This application is written in C# using .net core 2.1. Make sure you have .net core 2.1 installed before running this application. The DatabaseScripts folder contains the scripts to create the tables, stored procedures and indexes needed for this application to run. The AzureScripts folder container ARM templates to create the datafactory and the pipelines to migrate data from the csv files to the Azure database. This solution used Azure SQL database and datafactory to migrate the data from the csv files. You don't have to use Azure SQL. You can use locahost and bcp to migrate the data. Follow these steps to run the application.

1. clone the repository.
2. make sure the application runs.
3. create the database.
4. run the database scripts to create the database objects in the following order.
    a. Tables
    b. index
    c. stored procedures
5. download the csv files from NYC TLC site.
6. migrate the data using datafactory or bcp tool.
7. if you want to use datafactory, run the ARM template first to create the datafactory and the pipelines.
8. Update the connection string in appsetting.json
9. run the application.
10. Once the application is running, you can test it using tools like postman or the following powershell script.
    Invoke-WebRequest -Uri "https://localhost:44381/api/FhvTripDatas?from=20&to=81&date=" -Method POST
 
TODO:
1. setup CI/CD pipeline so that scripts can't be accidentally changed for the production build.
2. make the stored procedure calls using EF Core instead of ADO apis.
3. write unit tests.
