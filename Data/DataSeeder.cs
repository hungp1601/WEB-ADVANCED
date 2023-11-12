using btl_web.Models;

namespace btl_web.Data
{
    public static class DataSeeder
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<BtlWebContext>();

                try
                {
                    context.Database.EnsureCreated();

                    var roles = context.Roles.FirstOrDefault();
                    if(roles == null)
                    {
                        context.Roles.AddRange(
                            new Role{ Name = "Admin"}
                        );
                        context.Roles.AddRange(
                            new Role { Name = "Student" }
                        );
                        context.Roles.AddRange(
                           new Role { Name = "Teacher" }
                       );
                    }
                    context.SaveChanges();

                    var users = context.Roles.FirstOrDefault();
                    if (users == null)
                    {

                        context.Users.AddRange(
                           new User { FullName = "Admin", Password = "123456", Email = "test@gmail.com", Status = "studying", RoleId = 1 }
                       );
                    }


                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw;
                }
                return app;
            }
        }
    }
}
