namespace Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }
        public string url { get; set; }
    }
    public class todo
    {
        public int todo_id { get; set; }
        public string description{ get; set; }
       public string category_name{ get; set; }
        public DateTime due_date { get; set; }
        public string estimate { get; set; }
        public int user_id { get; set; }
        public string importance{ get; set; }
        public string status { get; set; }
    }
    
}