using UserManagementApi_EntityFrmwk.Model;
using UserManagementApi_EntityFrmwk.DBContext;

namespace UserManagementApi_EntityFrmwk.DAL;

public class UsersDataAccess {
    public static void DeleteOneUser(int id)
    {
        using(var context = new UserDbContext())
        {
            context.Users.Remove(context.Users.Find(id));
            context.SaveChanges();
        }
    }

    public static List<User> GetAllUsers()
    {
        using (var context = new UserDbContext())
        {
            var users=from user in context.Users select user;
            return users.ToList<User>();
        }
    }

    public static void InsertNewUser(User user)
    {
        using (var context = new UserDbContext())
        {
            context.Users.Add(user);
            context.SaveChanges();  
        }
    }

    public static void UpdateUser(User user)
    {
        using (var context = new UserDbContext())
        {
            var theUser = context.Users.Find(user.userid);
            theUser.username =user.username;
            theUser.course=user.course;
            theUser.purchasedate=user.purchasedate;
            context.SaveChanges();
        }
    }
}