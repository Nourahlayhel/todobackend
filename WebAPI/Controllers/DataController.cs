using Entities;
using BLC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IConfiguration _config;
        public BLC.BLC _blc = new BLC.BLC();


        [Route("get_user")]
        [HttpPost]
        public User get_user_by_email_address(Params_Get_Person_By_EMAIL_ADDRESS params_Get_Person_By_EMAIL_ADDRESS)
        {
            return _blc.get_user_by_email_address(params_Get_Person_By_EMAIL_ADDRESS);
        }
        [Route("get_tasks")]
        [HttpPost]
        public List<todo> get_tasks_by_user_id(Params_Get_Todo_By_USER_ID params_Get_Todo_By_user_id)
        {
            return _blc.get_tasks_by_user_id(params_Get_Todo_By_user_id);
        }
        [Route("Edit_Task")]
        [HttpPost]
        public void Edit_Task(todo t)
        {
            /* todo to = JsonConvert.DeserializeObject<todo>(t)*/
            ;

            _blc.Edit_Task(t);
        }




    }
}
