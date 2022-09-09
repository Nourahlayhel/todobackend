using Entities;
using System.Data;
using System.Data.SqlClient;
namespace DALC
   
{
    public class DALC
    {
        string connString = @"Data Source=DESKTOP-4ED4RMM\INSTANCE_2K19_01;Database=todoDB;User ID=sa;Password=#sapassword@2022";
       
        SqlCommand _cmd;
        public void Edit_Task(int todo_id,string description, string status, string importance,string estimate, DateTime due_date, int user_id, string category_name)
        {

            using (SqlConnection _con = new SqlConnection(connString))
            {
                _con.Open();


                using (_cmd = new SqlCommand("UPG_EDIT_TODO", _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;

                    _cmd.Parameters.AddWithValue("@P__TASK_ID", todo_id);

                    _cmd.Parameters.AddWithValue("@P__DESCRIPTION", description);
                   
                    _cmd.Parameters.AddWithValue("@P__CATEGORY_NAME", category_name);
                    if (due_date!=null)
                        _cmd.Parameters.AddWithValue("@P__DUE_DATE", due_date);
                     else _cmd.Parameters.AddWithValue("@P__DUE_DATE", DBNull.Value);
                    if (estimate!="")
                        _cmd.Parameters.AddWithValue("@P__ESTIMATE", estimate);
                    else
                    _cmd.Parameters.AddWithValue("@P__ESTIMATE", (object)estimate ?? DBNull.Value);
                    _cmd.Parameters.AddWithValue("@P__USER_ID", user_id);
                    if(importance!="")
                    _cmd.Parameters.AddWithValue("@P__IMPORTANCE", importance);
                    else 
                    _cmd.Parameters.AddWithValue("@P__IMPORTANCE", (object)importance?? DBNull.Value);
                    _cmd.Parameters.AddWithValue("@P__STATUS", status);
                    _cmd.ExecuteNonQuery();
                       
                }
            }

        }
        public User Get_User_By_Email_Address(string email_address)
        
        {
            User u = new User();
           
            using (SqlConnection _con = new SqlConnection(connString))
            {
                _con.Open();
               

                using (_cmd = new SqlCommand("UPG_GET_USER_BY_EMAIL", _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@P__EMAIL_ADDRESS",email_address);
                    //_cmd.ExecuteNonQuery();
            
                    SqlDataReader reader = _cmd.ExecuteReader();
                   while(reader.Read())
                    {
                    u.user_id =reader.GetInt32("user_id");
                     u.name = reader.GetString("name");
                     u.email_address = reader.GetString("email_address"); ;
                      u.password = reader.GetString("password"); ;
                       u.url = reader.GetString("image_url"); 

                    }
                    reader.Close();
                    _con.Close();
                }
            }
            return u;
        }


        public List<todo> Get_Tasks_By_User_Id(int user_id)
        {
            List<todo> todos = new List<todo>();
    
          

                using (SqlConnection _con = new SqlConnection(connString))
                {
                    _con.Open();


                    using ( _cmd = new SqlCommand("UPG_GET_TASKS_BY_USER_ID", _con))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@P__USER_ID",user_id);
                        
                        SqlDataReader reader = _cmd.ExecuteReader();
                        while (reader.Read())
                        {
                        todo t = new Entities.todo();
                        t.todo_id = reader.GetInt32("task_id");  
                        t.description=reader.GetString("description");
                        if (!reader.IsDBNull("categ_name"))
                            t.category_name=reader.GetString("categ_name");
                      
                        if (!reader.IsDBNull("due_date"))
                            t.due_date = reader.GetDateTime("due_date");
                       
                        if (!reader.IsDBNull("estimate"))
                            t.estimate = reader.GetString("estimate");
                     
                        t.user_id = reader.GetInt32("user_id");
                        if (!reader.IsDBNull("importance"))
                            t.importance = reader.GetString("importance");
                       
                        t.status = reader.GetString("status");
                        todos.Add(t);
                        Console.WriteLine(t.description);
                        }
                    reader.Close();
                        
                    }
                _con.Close();
            }

            return todos;
            }
        public int AddCategory(string name)
        {
            int id;
            using (SqlConnection _con = new SqlConnection(connString))
            {
                _con.Open();


                using (_cmd = new SqlCommand("UPG_ADD_CATEGORY", _con))
                {
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.AddWithValue("@P__NAME", name);
                    SqlDataReader reader = _cmd.ExecuteReader();
                    id = reader.GetInt32("category_id");
                    reader.Close();
                }
                _con.Close();
            }
            return id;  
        }
           
        }
       
    }
