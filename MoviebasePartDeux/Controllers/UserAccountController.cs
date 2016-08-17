using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoviebasePartDeux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviebasePartDeux.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserAccountController : Controller
    {
        // GET: UserAccount
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            // get list of admins
            var roleManagerAdmins = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var roleAdmins = roleManagerAdmins.FindByName("Administrator").Users.First();
            var adminsInRole = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(roleAdmins.RoleId)).ToList();

            return View(adminsInRole);
        }

        public ActionResult Delete(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();


            return View(db.Users.Where(u => u.Id.Contains(id)).ToList());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            ApplicationDbContext db = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var userToDelete = db.Users.Count(m => m.Id == id);

            string currentUser = User.Identity.GetUserId();

            if (currentUser == id )
            {
                return RedirectToAction("Index");
            }
            else
            {
                ApplicationUser user = db.Users.Find(id);
                var deleteUser = UserManager.FindById(user.Id);

                string Arole = "Administrator";

                UserManager.RemoveFromRole(deleteUser.Id, Arole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Add()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ViewBag.UserList = db.Users.ToList();
            return View();

        }
        [HttpPost, ActionName("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult AddConfirmed(string UserID)
        {


            ApplicationDbContext db = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            string Arole = "Administrator";
            ApplicationUser user = db.Users.Find(UserID);
            var currentUser = UserManager.FindById(user.Id);

            UserManager.AddToRole(currentUser.Id, Arole);
            db.SaveChanges();
            return RedirectToAction("Index");
            

        }


        public ActionResult Edit() {
            return View();
        }
    }
}