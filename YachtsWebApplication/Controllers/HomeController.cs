using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YachtsWebApplication.DatabaseContexts;
using YachtsWebApplication.Entities;
using YachtsWebApplication.ViewModels;
using YachtsWebApplication.ViewModels.CustomValidations;

namespace YachtsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            var yachts = new List<YachtViewModel>();
            using (var db = new DatabaseContext())
            {
                yachts = db.Yachts.ToArray().Select(d => new YachtViewModel(d)).ToList();

            }

            return View(yachts);
        }

        [HttpGet]
        public ActionResult Booking(int id)
        {
            Yacht yacht = new Yacht();
            using(var db = new DatabaseContext())
            {
                yacht = db.Yachts
                    .Include("YachtCategory.Yachts")
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
            if (yacht == null)
            {
                return Content("Nie znaleziono jachtu o podanym identyfikatorze");
            }
            var booking = new BookingViewModel(yacht);
            return View(booking);
        }

        [HttpPost]
        public ActionResult Booking(BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
                return View(bookingViewModel);

            if (bookingViewModel.End < bookingViewModel.Start.AddDays(2))
            {
                ModelState.AddModelError("", "Data końca wypożyczenia nie może być wcześniejsza niż data początku.");
                return View(bookingViewModel);
            }
            if (!BookingViewModelValidation.DateIsAvailable(bookingViewModel.Start, bookingViewModel.End, bookingViewModel.YachtId))
            {
                ModelState.AddModelError("", "Jacht nie jest dostępny w podanym zakresie czasowym");
                return View(bookingViewModel);
            }

            var booking = new Booking(bookingViewModel);
            using (var db = new DatabaseContext())
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
            }

            var confirmationViewModel = new ConfirmationViewModel(booking);

            return RedirectToAction("Confirmation", confirmationViewModel);
        }

        [HttpGet]
        public ActionResult Confirmation(ConfirmationViewModel confirmationViewModel)
        {
            return View(confirmationViewModel);
        }

    }
}