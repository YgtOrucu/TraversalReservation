using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Linq.Expressions;
using TraversalReservation.Models;

namespace TraversalReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        #region Constructor
        private readonly IDestinationService _destinationService;
        private readonly ICommentService _commentService;
        private readonly IReservationService _reservationService;
        private readonly IGuideService _guideService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController
            (IDestinationService destinationService,
            ICommentService commentService,
            IReservationService reservationService,
            IGuideService guideService,
            UserManager<AppUser> userManager)

        {
            _destinationService = destinationService;
            _commentService = commentService;
            _userManager = userManager;
            _reservationService = reservationService;
            _guideService = guideService;
        }
        #endregion

        #region DestinationOpereations

        #region List
        public IActionResult Destination()
        {
            var values = _destinationService.TGetAllList();
            return View(values);
        }


        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetAllList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }


        //public static List<GetCityForAjax> cities = new List<GetCityForAjax>()
        //{
        //    new GetCityForAjax
        //    {
        //        CityID = 1,
        //        CityName = "Üsküp",
        //        CityCountry="Makedonya",
        //    },
        //     new GetCityForAjax
        //    {
        //        CityID = 2,
        //        CityName = "Roma",
        //        CityCountry="İtalya",
        //    },
        //      new GetCityForAjax
        //    {
        //        CityID = 3,
        //        CityName = "Londra",
        //        CityCountry="İngiltere",
        //    }
        //}

        #endregion

        #region Add
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination d)
        {
            _destinationService.TInsert(d);
            return RedirectToAction("Destination");
        }
        #endregion

        #region EditAndUpdate
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View("EditDestination", values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination d)
        {
            _destinationService.TUpdate(d);
            return RedirectToAction("Destination");
        }
        #endregion

        #endregion

        #region DashboardOperation

        public IActionResult Dashboard()
        {
            return View();
        }

        #endregion

        #region CommentsOperation

        #region List
        public IActionResult Comments()
        {
            var values = _commentService.TGetCommentsForAdminPage();
            return View(values);
        }
        #endregion

        #region EditAndUpdate
        public IActionResult EditComments(int id)
        {
            var values = _commentService.TGetByID(id);
            return View("EditComments", values);
        }
        [HttpPost]
        public IActionResult UpdateComments(Comment c)
        {
            _commentService.TUpdate(c);
            return RedirectToAction("Comments");
        }
        #endregion



        #endregion

        #region MembersOperation

        #region List

        public IActionResult Members()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        public IActionResult OldReservation(int id)
        {
            var values = _reservationService.TGetOldReservation(id);
            return View(values);
        }
        #endregion

        #endregion

        #region Guide 

        #region List

        public IActionResult Guide()
        {
            var values = _guideService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide g)
        {
            _guideService.TInsert(g);
            return RedirectToAction("Guide");
        }
        #endregion

        #region EditAndUpdate

        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View("EditGuide", values);
        }

        [HttpPost]
        public IActionResult UpdateGuide(Guide g)
        {
            _guideService.TUpdate(g);
            return RedirectToAction("Guide");
        }

        #endregion

        #endregion

        #region MailOperation
        [HttpGet]
        public IActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Mail(MailRequest mail)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailbox = new MailboxAddress("Admin", mail.SenderMail); //Admin isminde gönderen mail adresi

            mimeMessage.From.Add(mailbox);
            MailboxAddress mailboxAddress = new MailboxAddress("User", mail.ReceiveMail); // User isminde alıcı mail adresi

            mimeMessage.To.Add(mailboxAddress); //Alıcı maili ekledik

            var bodyBuilder = new BodyBuilder(); //Description alanını ekledık
            bodyBuilder.TextBody = mail.Description;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mail.Subject; // Gönderen maili ekledik

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate(mail.SenderMail, "O şifre buraya gelecek."); //Gönderilecek mail adresine ait şifreyi girdik.Bu şifreyi google kabul etmıyor
                                                                                 //bunu yapmak için gönderen mailin account hesabına gırıp 2 adımlı dogrulamayı yaptıktan sonra
                                                                                 //altında uygulama sıfrelerı ıstıyor buna tıklayıp googleın baska uygulamalarda sana vereceğı siferyi buraya
                                                                                 //koyup o sekılde mail gondereceğız
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }


        #endregion

    }
}
