# 1, Create .NET Core application using MVC template.

# 2, Install the below nugget packages
-      1,  Microsoft.EntityFrameworkCore
-      2,  Microsoft.EntityFrameworkCore.Sqlserver 
-      3,  Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
-      3,  Microsoft.EntityFrameworkCore.Tools
-      4,  Microsoft.Extension.configuration

# 3, Generate DbContext using scaffold command
     Scaffold-DbContext "connectionstring" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

# 4, Update DbContext object
    Scaffold-DbContext "Connectionstring" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -t tablename -f