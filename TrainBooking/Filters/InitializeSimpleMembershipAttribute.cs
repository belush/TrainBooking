using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using TrainBooking.DAL;
using WebMatrix.WebData;
using TrainBooking.Models;

namespace TrainBooking.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            readonly SimpleRoleProvider _roles = (SimpleRoleProvider)Roles.Provider;
            SimpleMembershipProvider _membership = (SimpleMembershipProvider)Membership.Provider;

            public SimpleMembershipInitializer()
            {
                //Database.SetInitializer<UsersContext>(null);
                Database.SetInitializer<TrainBookingContext>(null);

                try
                {
                    using (var context = new TrainBookingContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("TrainBookingContext", "User", "UserId", "UserName",
                        autoCreateTables: true);

                    if (!_roles.RoleExists("Admin"))
                    {
                        _roles.CreateRole("Admin");
                    }
                    if (!_roles.RoleExists("User"))
                    {
                        _roles.CreateRole("User");
                    }

                    if (_membership.GetUser("admin1", false) == null)
                    {
                        WebSecurity.CreateUserAndAccount("admin1", "123456",
                            new
                            {
                                FirstName = "admin",
                                MidName = "admin",
                                LastName = "admin",
                                BirthDate = 01 / 01 / 1985
                            });
                        _roles.AddUsersToRoles(new[] { "admin1" }, new[] { "Admin" });
                    }

                    if (_membership.GetUser("user", false) == null)
                    {
                        WebSecurity.CreateUserAndAccount("user", "123456",
                            new
                            {
                                FirstName = "user",
                                MidName = "user",
                                LastName = "user",
                                BirthDate = 01 / 01 / 1985
                            });
                        _roles.AddUsersToRoles(new[] { "user" }, new[] { "User" });
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
