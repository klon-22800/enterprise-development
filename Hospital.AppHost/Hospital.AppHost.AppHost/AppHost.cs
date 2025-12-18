var builder = DistributedApplication.CreateBuilder(args);


var sql = builder.AddSqlServer("sql")
    .WithPassword(builder.AddParameter("sql-password", "StrongPass-123"))
    .WithEnvironment("ACCEPT_EULA", "Y");


var db = sql.AddDatabase("HospitalDb");


var api = builder.AddProject<Projects.Hospital_WebApplication>("hospital-api")
    .WithReference(db)    
    .WaitFor(db);         


builder.AddProject<Projects.Hospital_Generation_GrpcServer>("hospital-generation-grpcserver");





builder.Build().Run();
