using DALC;
using Entities;

namespace BLC
{
    public class BLC
    {
        public DALC.DALC _dalc = new DALC.DALC();
        public User get_user_by_email_address(Params_Get_Person_By_EMAIL_ADDRESS params_Get_Person_By_EMAIL_ADDRESS)
        {
            return _dalc.Get_User_By_Email_Address(params_Get_Person_By_EMAIL_ADDRESS.EMAIL_ADDRESS);
        }


        public List<todo> get_tasks_by_user_id(Params_Get_Todo_By_USER_ID params_Get_Todo_By_USER_ID)
        {

            return _dalc.Get_Tasks_By_User_Id(params_Get_Todo_By_USER_ID.USER_ID);
        }
        public void Edit_Task(todo t)
        {
            
            _dalc.Edit_Task(t.todo_id, t.description, t.status, t.importance, t.estimate, t.due_date, t.user_id,t.category_name);
            
        }

    }

    
}