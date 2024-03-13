using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuggestionSystem.Models;

namespace SuggestionSystem.Controllers
{
    public class PersonProfilesController : Controller
    {
        private StoreDb db = new StoreDb();

        // GET: PersonProfiles
        public ActionResult Index()
        {
            var suggestProfils = db.PersonProfiles.Where(s => s.Isshow == true);


            var model = suggestProfils.Select(p => new SuggestProfilVm()
            {
                Cost = p.SuggestProfils.Select(s => s.Cost).FirstOrDefault(),
                CurrentSituationNote = p.SuggestProfils.Select(s => s.CurrentSituationNote).FirstOrDefault(),
                Result = p.SuggestProfils.Select(s => s.Result).FirstOrDefault(),
                SuggestNote = p.SuggestProfils.Select(s => s.SuggestNote).FirstOrDefault(),
                UnitTypeId = p.SuggestProfils.Select(s => s.UnitTypeId).FirstOrDefault(),
                SuggestTitle = p.SuggestProfils.Select(s => s.SuggestTitle).FirstOrDefault(),
                FullName = p.FullName,

            });
            return View(model.ToList());
        }
        public ActionResult SendSmsSec(int? id)
        {
           
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendSmsSec(SuggestProfilVm svm)
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult SaveDocument()
        {

            string filePath = Server.MapPath("~/content/آيين نامه اجراي نظام پذيرش و بررسي پيشنهادها.pdf");
            string contentType = "application/pdf";
            return File(filePath, contentType, "آيين نامه اجراي نظام پذيرش و بررسي پيشنهادها.pdf");

        }
        [HttpPost]
        public JsonResult IsValid(string NationalCode)
        {
            var Pprof = db.PersonProfiles.Where(s => s.NationalCode == NationalCode).FirstOrDefault();
            if (Pprof != null)
            {
                return Json("کد ملی تکراری است! ", JsonRequestBehavior.AllowGet);
            }
            else
            {
                var _Isvalid = Utility.CheckNation.IsValid(NationalCode);
                if (_Isvalid == true)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else if (_Isvalid == false)
                {
                    return Json("کد ملی نامعتبر است  ! ", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        // GET: PersonProfiles/Details/5
        [HttpPost]
        public JsonResult IsValidN(string NationalCode)
        {
            var Pprof = db.PersonProfiles.Where(s => s.NationalCode == NationalCode).FirstOrDefault();
            var _Isvalid = Utility.CheckNation.IsValid(NationalCode);
            if (_Isvalid == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else if (_Isvalid == false)
            {
                return Json("کد ملی نامعتبر است  ! ", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        // GET: PersonProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                if (!User.Identity.IsAuthenticated)
                {
                    if (null == Session["PersonProfile"])
                    {
                        return RedirectToAction("search");
                    }
                    else
                    {
                        if (Convert.ToString(Session["PersonProfile"]) != id.ToString())
                        {
                            return RedirectToAction("search");
                        }
                    }
                }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var PProfils = db.PersonProfiles.Where(s => s.Isshow == true && s.PersonProfileId == id).FirstOrDefault();
            var SProfile = db.SuggestProfils.Where(s => s.IsShow == true && s.PersonProfileId == id);
            var model = SProfile.Select(p => new SuggestProfilVm()
            {
                Cost = p.Cost,
                CurrentSituationNote = p.CurrentSituationNote,
                Result = p.Result,
                SuggestNote = p.SuggestNote,
                Title_Post = p.PersonProfile.Post.Title,
                PostOrgans = p.PersonProfile.PostOrgans,
                UnitTypeId = p.UnitTypeId,
                SuggTypetId = p.SuggProfile_SuggType_Interface.Select(s => s.ID_SuggTypeRefree).FirstOrDefault(),
                IsEditable = p.SuggProfile_SuggType_Interface.Select(s => s.IsEdited).FirstOrDefault(),
                PersonProfile = p.PersonProfile,
                SuggestTitle = p.SuggestTitle,
                SuggestId = p.SuggestId,
                IsActive = p.SuggProfile_SuggType_Interface.Select(s => s.IsActive).FirstOrDefault(),

                Equipment = p.Equipment,
                Note_Cost = p.Note_Cost,
                Benefits = p.Benefits,
                FullName = p.PersonProfile.FullName,
                Title_MemberType = p.PersonProfile.MemberType.Title,
                Reshte = p.PersonProfile.Reshte,
                PersonProfileId = p.PersonProfileId,
                NationalCode = p.PersonProfile.NationalCode,
                Title_Degree = p.PersonProfile.Degree.Title,
                Mobile = p.PersonProfile.Mobile,
                LetterNumber = p.SuggProfile_SuggType_Interface.Where(s => s.ID_Part == 2).Select(s => s.LetterNumber).FirstOrDefault(),
                Title_SuggestType = p.SuggProfile_SuggType_Interface.Select(s => s.SuggestType.Title).FirstOrDefault(),
                ID_Part = p.SuggProfile_SuggType_Interface.Select(s => s.PartType.Id).FirstOrDefault(),
                Point = p.SuggProfile_SuggType_Interface.Select(s => s.Point).FirstOrDefault(),
                Note_Referee = p.SuggProfile_SuggType_Interface.Where(s => s.ID_Part == 2).Select(s => s.Note_Referee).FirstOrDefault(),
                Note_Secretariate = p.SuggProfile_SuggType_Interface.Where(s => s.ID_Part == 1).Select(s => s.Note_Secretariate).FirstOrDefault(),
                S_SuggType_Inter = p.SuggProfile_SuggType_Interface.ToList(),
                Date_Referee = p.SuggProfile_SuggType_Interface.Select(s => s.Date_Referee).FirstOrDefault(),
                Time_Referee = p.SuggProfile_SuggType_Interface.Select(s => s.Date_Referee).FirstOrDefault(),
                User_Referee = p.SuggProfile_SuggType_Interface.Select(s => s.Date_Referee).FirstOrDefault(),

                Edit_Date_Referee = p.SuggProfile_SuggType_Interface.Select(s => s.Edit_Date_Referee).FirstOrDefault(),
                Edit_Time_Referee = p.SuggProfile_SuggType_Interface.Select(s => s.Edit_Time_Referee).FirstOrDefault(),
                Edit_User_Referee = p.SuggProfile_SuggType_Interface.Select(s => s.Edit_User_Referee).FirstOrDefault(),

                Date_Secretariate = p.SuggProfile_SuggType_Interface.Select(s => s.Date_Secretariate).FirstOrDefault(),
                time_Secretariate = p.SuggProfile_SuggType_Interface.Select(s => s.time_Secretariate).FirstOrDefault(),
                User_Secretariate = p.SuggProfile_SuggType_Interface.Select(s => s.User_Secretariate).FirstOrDefault(),

                Edit_Date_Secretariate = p.SuggProfile_SuggType_Interface.Select(s => s.Edit_Date_Secretariate).FirstOrDefault(),
                Edit_Time_Secretariate = p.SuggProfile_SuggType_Interface.Select(s => s.Edit_Time_Secretariate).FirstOrDefault(),
                Edit_User_Secretariate = p.SuggProfile_SuggType_Interface.Select(s => s.Edit_User_Secretariate).FirstOrDefault(),
            });
            ViewBag.PersonProfile = PProfils;
            ViewBag.SuggestProfile = SProfile;
            var ff = model.ToList();
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult SendCode()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendCode(Search search)
        {
            if (ModelState.IsValid)
            {
                PersonProfile Pprof = new PersonProfile();
                var NationalCode = Utility.PertionDate.PtoE(search.NationalCode);
                var Mobile = Utility.PertionDate.PtoE(search.Mobile);
                var Code = utility.SmSSender.GenerateString();
                var PerId = db.PersonProfiles.Where(p => p.Isshow == true && p.NationalCode == search.NationalCode).Select(p => p.PersonProfileId).FirstOrDefault();
                var Per = db.PersonProfiles.Where(p => p.PersonProfileId == PerId).FirstOrDefault();
                Per.Password = Code.ToString();
                Per.ConfirmPassword = Code.ToString();
                db.Entry(Per).State = EntityState.Modified;
                db.SaveChanges();
                if (Mobile != null)
                {
                    utility.SmSSender.SendSmS(Mobile, Per.Password);
                    TempData["Message"] = "کلمه عبور برای شماره وارد شده ارسال است.";
                    return RedirectToAction("search");

                }
                else
                {
                    TempData["Message"] = "اطلاعات وارد شده در سیستم ثبت نشده است";

                    return RedirectToAction("search");

                }
            }
            else
            {
                TempData["Message"] = "اطلاعات وارد شده در سیستم ثبت نشده است";
                return RedirectToAction("search");
            }
        }
        [AllowAnonymous]
        public ActionResult Search()
        {
            TempData["Message"] = TempData["Error"];
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Search(Search search)
        {
            if (ModelState.IsValid)
            {
                var NationalCode = Utility.PertionDate.PtoE(search.NationalCode);
                var List2 = db.PersonProfiles.Where(s => s.Isshow == true).ToList();
                foreach (var item in List2)
                {
                    var Nation = Utility.PertionDate.PtoE(item.NationalCode);
                    if (Nation == NationalCode)
                    {
                        if (item.Password == search.Securitycode.Trim())
                        {
                            Session["PersonProfile"] = item.PersonProfileId;
                            Session["Login"] = true;
                            return RedirectToAction("Details", new { id = item.PersonProfileId });
                        }

                    }

                }

                ViewBag.Error = "اطلاعات وارد شده در سیستم ثبت نشده است";
                return View();

            }
            return View();
        }
        // GET: PersonProfiles/Create
        public ActionResult Create()
        {

            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Title");
            ViewBag.ID_PeopleType = new SelectList(db.PeopleTypes, "Id", "Title");
            ViewBag.ID_MemType = new SelectList(db.MemberTypes, "Id", "Title");
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title");
            return View();
        }

        // POST: PersonProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonProfile personProfile)
        {
            if (ModelState.IsValid)
            {
                if (personProfile.ID_MemType == 2)
                {
                    personProfile.PostId = 10;
                }
                personProfile.Isshow = true;
                personProfile.NationalCode = Utility.PertionDate.PtoE(personProfile.NationalCode);
                personProfile.Mobile = Utility.PertionDate.PtoE(personProfile.Mobile);
                db.PersonProfiles.Add(personProfile);
                db.SaveChanges();
                Session["id"] = personProfile.PersonProfileId;
                Session["PersonProfile"] = personProfile.PersonProfileId;
                return RedirectToAction("Details", new { id = personProfile.PersonProfileId, typeId = personProfile.ID_MemType });
            }
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Title", personProfile.DegreeId);
            ViewBag.ID_PeopleType = new SelectList(db.PeopleTypes, "Id", "Title");
            ViewBag.ID_MemType = new SelectList(db.MemberTypes, "Id", "Title", personProfile.ID_MemType);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", personProfile.PostId);
            return View(personProfile);
        }

        // GET: PersonProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (null == Session["PersonProfile"])
                {
                    return RedirectToAction("search");
                }
                else
                {
                    if (Convert.ToString(Session["PersonProfile"]) != id.ToString())
                    {
                        return RedirectToAction("search");
                    }
                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personProfile = db.PersonProfiles.Where(s => s.PersonProfileId == id).ToList();
            var model = personProfile.Select(p => new PersonProfileVmEdit()
            {
                PersonProfileId = p.PersonProfileId,

                FatherName = p.FatherName,
                FullName = p.FullName,
                Mobile = p.Mobile,
                BirthDate = p.BirthDate,
                Image = p.Image,
                Reshte = p.Reshte,
                DateEdit = p.DateEdit,
                DateUpload = p.DateUpload,
                TImeEdit = p.TImeEdit,
                Phone = p.Phone,
                DegreeId = p.DegreeId,
                PostId = p.PostId,
                PostOrgans = p.PostOrgans,
                Email = p.Email,
                Isshow = p.Isshow,

                ID_MemType = p.ID_MemType,
            }).FirstOrDefault();
            if (personProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PeopleType = new SelectList(db.PeopleTypes, "Id", "Title", model.ID_PeopleType);
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Title", model.DegreeId);
            ViewBag.ID_MemType = new SelectList(db.MemberTypes, "Id", "Title", model.ID_MemType);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", model.PostId);
            return View(model);
        }

        // POST: PersonProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]

        public ActionResult EditP(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (null == Session["PersonProfile"])
                {
                    return RedirectToAction("search");
                }
                else
                {
                    if (Convert.ToString(Session["PersonProfile"]) != id.ToString())
                    {
                        return RedirectToAction("search");
                    }
                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personProfile = db.PersonProfiles.Where(s => s.PersonProfileId == id).ToList();
            var model = personProfile.Select(p => new PersonProfileVmEdit()
            {
                PersonProfileId = p.PersonProfileId,
                FatherName = p.FatherName,
                FullName = p.FullName,
                Mobile = p.Mobile,
                BirthDate = p.BirthDate,
                Image = p.Image,
                PostOrgans = p.PostOrgans,
                Reshte = p.Reshte,
                DateEdit = p.DateEdit,
                DateUpload = p.DateUpload,
                TImeEdit = p.TImeEdit,
                Phone = p.Phone,
                DegreeId = p.DegreeId,
                PostId = p.PostId,
                Email = p.Email,
                Isshow = p.Isshow,
                ID_MemType = p.ID_MemType,
            }).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PeopleType = new SelectList(db.PeopleTypes, "Id", "Title", model.ID_PeopleType);
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Title", model.DegreeId);
            ViewBag.ID_MemType = new SelectList(db.MemberTypes, "Id", "Title", model.ID_MemType);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", model.PostId);
            return View(model);
        }
        // POST: PersonProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public  ActionResult EditP(PersonProfileVmEdit personProfile)
        {
            if (!User.Identity.IsAuthenticated)
            {
                if (null == Session["PersonProfile"])
                {
                    return RedirectToAction("search");
                }
                else
                {
                    if (Convert.ToString(Session["PersonProfile"]) != personProfile.PersonProfileId.ToString())
                    {
                        return RedirectToAction("search");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                var Per = db.PersonProfiles.Where(s => s.PersonProfileId == personProfile.PersonProfileId).FirstOrDefault();
                Per.FullName = personProfile.FullName;
                Per.FatherName = personProfile.FatherName;
                Per.ID_MemType = personProfile.ID_MemType;
                Per.OtherMem = personProfile.OtherMem;
                if (personProfile.ID_MemType == 2)
                {
                    personProfile.PostId = 10;
                }
                else
                {
                    Per.PostId = personProfile.PostId;

                }
                Per.Reshte = personProfile.Reshte;
                Per.DegreeId = personProfile.DegreeId;
                Per.Email = personProfile.Email;
                Per.PostOrgans = personProfile.PostOrgans;
                Per.Phone = personProfile.Phone;
                Per.TImeEdit = DateTime.Now.ToShortTimeString();
                Per.DateEdit = Utility.PertionDate.Today();
                Per.BirthDate = personProfile.BirthDate;
                Per.Mobile = personProfile.Mobile;
                db.Entry(Per).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("Details", "PersonProfiles", new { id = Per.PersonProfileId });
            }
            ViewBag.ID_PeopleType = new SelectList(db.PeopleTypes, "Id", "Title", personProfile.ID_PeopleType);
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Title", personProfile.DegreeId);
            ViewBag.ID_MemType = new SelectList(db.MemberTypes, "Id", "Title", personProfile.ID_MemType);
            ViewBag.PostId = new SelectList(db.Posts, "Id", "Title", personProfile.PostId);
            return View(personProfile);
        }

        // GET: PersonProfiles/Delete/5
        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonProfile personProfile =  db.PersonProfiles.Find(id);
            if (personProfile == null)
            {
                return HttpNotFound();
            }
            return View(personProfile);
        }

        // POST: PersonProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult  DeleteConfirmed(int id)
        {
            PersonProfile personProfile =  db.PersonProfiles.Find(id);
            db.PersonProfiles.Remove(personProfile);
             db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}
