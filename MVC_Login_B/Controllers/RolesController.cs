using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;



namespace MVC_Login_B.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRoles());
        }

        public async Task<ActionResult> GetDataRoles()
        {
            var result = await sqlConnection.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role");
            return Json(new { data = result },
                JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_Insert_Role");
            return Json(new { data = affectedRows}, JsonRequestBehavior.AllowGet);
        }
    }
}