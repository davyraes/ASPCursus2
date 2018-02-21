using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Security.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC_Security.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Userbeheer()
        {
            IDbSet<ApplicationUser> AlleUsers = context.Users;
            return View(AlleUsers);
        }
        public ActionResult Rolebeheer()
        {
            IDbSet<IdentityRole> AlleRoles = context.Roles;
            return View(AlleRoles);
        }
        public ActionResult VerwijderUser(string id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult VerwijderUserDoorvoeren(string id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("Userbeheer");
        }
        public ActionResult UserDetail(string id)
        {
            var user = context.Users.Find(id);
            ViewBag.userid = id;
            ViewBag.usernaam = user.UserName;
            var rolesVoorUser = new List<IdentityRole>();
            foreach (var role in user.Roles)
                rolesVoorUser.Add(context.Roles.Find(role.RoleId));
            return View(rolesVoorUser);
        }
        public ActionResult VerwijderRoleForMember(string userid,string roleid)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userid);
            var role = context.Roles.FirstOrDefault(r => r.Id == roleid);
            if(user!=null&&role!=null)
            {
                IdentityUserRole userrole = user.Roles.SingleOrDefault(ur => (ur.UserId == userid && ur.RoleId == roleid));
                user.Roles.Remove(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("UserDetail", "User", new { id = userid });
        }
        public ActionResult VerwijderRole(string id)
        {
            var role = context.Roles.Find(id);
            return View(role);
        }
        [HttpPost]
        public ActionResult VerwijderRoleDoorvoeren(string id)
        {
            var role = context.Roles.FirstOrDefault(r => r.Id == id);
            if(role!=null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
            }
            return RedirectToAction("Rolebeheer");
        }
        public ActionResult RoleDetail(string id)
        {
            var role = context.Roles.Find(id);
            RoleDetailViewModel vm = new RoleDetailViewModel();
            vm.RoleName = role.Name;
            vm.RoleId = role.Id;
            vm.UsersUitRole = new List<ApplicationUser>();
            foreach(var userrole in role.Users)
            {
                vm.UsersUitRole.Add(context.Users.Find(userrole.UserId));
            }
            vm.SelectUser = new List<SelectListItem>();
            foreach(var user in context.Users)
            {
                if(!vm.UsersUitRole.Contains(user))
                {
                    vm.SelectUser.Add(new SelectListItem { Text = user.UserName, Value = user.Id });
                }
            }
            return View(vm);
        }
        public ActionResult VerwijderUserForRole(string roleid,string userid)
        {
            var role = context.Roles.FirstOrDefault(r => r.Id == roleid);
            var user = context.Users.FirstOrDefault(u => u.Id == userid);
            if(user!=null&&role!=null)
            {
                IdentityUserRole userrole = role.Users.SingleOrDefault(ur => (ur.UserId == userid && ur.RoleId == roleid));
                role.Users.Remove(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("RoleDetail", "user", new { id = roleid });
        }
        [HttpPost]
        public ActionResult MemberToevoegen(string Roleid,string SelectUser)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == SelectUser);
            var role = context.Roles.FirstOrDefault(r => r.Id == Roleid);
            if(user!=null&&role!=null)
            {
                IdentityUserRole userrole = new IdentityUserRole();
                userrole.RoleId = Roleid;
                userrole.UserId = SelectUser;
                user.Roles.Add(userrole);
                context.SaveChanges();
            }
            return RedirectToAction("RoleDetail", "User", new { id = Roleid });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}