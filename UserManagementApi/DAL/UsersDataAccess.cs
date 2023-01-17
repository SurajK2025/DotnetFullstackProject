namespace UserManagementApi.DAL;

using UserManagementApi.Model;
using System.Data;
using MySql.Data.MySqlClient;

public class UsersDataAccess
{
    public static string conString = @"server=localhost; port=3306; user=root; password=root; database=userinfo";
    public static List<User> GetAllUsers()
    {
        List<User> allNotes = new List<User>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from users";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                User user = new User
                {
                    userid = int.Parse(row["userid"].ToString()),
                    username = row["username"].ToString(),
                    course = row["course"].ToString(),
                    purchasedate = row["purchasedate"].ToString()
                };
                allNotes.Add(user);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }

    public static void SaveNewUser(User user)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"insert into users(username, course, purchasedate) values('{user.username}', '{user.course}', '{user.purchasedate}')";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeleteUserById(int id)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "delete from users where userid =" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void UpdateUser(int id, User user)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = $"update users set username='{user.username}', course='{user.course}', purchasedate='{user.purchasedate}' where userid={id}";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }
}