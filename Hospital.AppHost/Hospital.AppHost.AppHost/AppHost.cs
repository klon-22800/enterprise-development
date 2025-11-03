using Aspire.Hosting;
using Microsoft.AspNetCore.DataProtection;

var builder = DistributedApplication.CreateBuilder(args);


var sql = builder.AddSqlServer("sql")
    .WithDataVolume("hospital_sql_data")
    .WithPassword(builder.AddParameter("sql-password", "StrongPass-123"))
    .WithEnvironment("ACCEPT_EULA", "Y");


var db = sql.AddDatabase("HospitalDb");


var api = builder.AddProject<Projects.Hospital_WebApplication>("hospital-api")
    .WithReference(db)    
    .WaitFor(db);         


builder.Build().Run();
