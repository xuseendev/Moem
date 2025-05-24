using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;


namespace MoeSystem.Server.Data;

public static partial class Initializer
{
    public static void Initialize(ApplicationDbContext context, IConfiguration _)
    {
        context.Database.Migrate();
        // if (!context.Permissions.Any())
        // {
        //     var permissions = typeof(KnownPermissions).GetFields(BindingFlags.Public | BindingFlags.Static).Select(x => new Permission
        //     {
        //         Id = x?.GetValue(null)?.ToString()!,
        //         // Format name by adding spaces between capital letters
        //         Name = MyRegex().Replace(x?.Name!, " $1").Trim(),
        //         IsEnabled = true
        //     }).ToList();
        //     context.Permissions.AddRange(permissions);
        //     context.SaveChanges();
        // }

        // if (!context.Groups.Any())
        // {
        //     var permissions = context.Permissions.ToList();
        //     var group = new MOHD.Contracts.Data.Identity.Group
        //     {
        //         Name = "Admin",
        //         IsEnabled = true,
        //         IsConstant = true,
        //         GroupPermissions = permissions.Select(x => new GroupPermission
        //         {
        //             PermissionId = x.Id,
        //         }).ToList()
        //     };
        //     context.Groups.Add(group);
        //     context.SaveChanges();
        // }

        // if (!context.Employees.Any(x => x.NormalizedEmail.Equals("admin@system.com".ToUpper())))
        // {
        //     var group = context.Groups.FirstOrDefault(x => x.Name.Equals("Admin"));
        //     var employee = new Employee
        //     {
        //         Name = "Admin",
        //         Email = "admin@system.com",
        //         Active = true,
        //         Description = "System Admin",
        //         SecurityStamp = Guid.NewGuid().ToString(),
        //         IsConstant = true,
        //         EmployeeGroups = new List<EmployeeGroup>() {
        //             new EmployeeGroup {
        //                 GroupId = group!.Id,
        //             }
        //         }
        //     };

        //     employee.NormalizedEmail = employee.Email.ToUpper();
        //     employee.PasswordHash = hash.HashPassword(employee, "Admin@123");
        //     context.Employees.Add(employee);
        //     context.SaveChanges();
        // }

    }
    // public static void InitializeBlock(FileConfig config)
    // {
    //     // FileService.IsValidPath(config.Path);
    //     // FileService.CreateDirectory(config.Path);
    // }

    // [GeneratedRegex("([A-Z])")]
    // private static partial Regex MyRegex();
}