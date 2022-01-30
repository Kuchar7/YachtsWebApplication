using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YachtsWebApplication.DatabaseContexts;

namespace YachtsWebApplication.ViewModels.CustomValidations
{
    public static class BookingViewModelValidation
    {
        public static bool DateIsAvailable(DateTime start, DateTime end, int yachtId)
        {
            using (var db = new DatabaseContext())
            {
                var result = (from x in db.Bookings
                          where ((x.YachtId == yachtId) && (x.Start <= end) && (x.End >= start))
                          select x).Any();
                return !result;
            }
        }
    }
}