using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Metadata
{
    public class MetadataRepository
    {

        public IEnumerable<SelectListItem> GetBookingTypes()
        {
            using (var context = new CloudbassContext())
            {
                List<SelectListItem> bookingtypes = context.BookingTypes.AsNoTracking()
                    .OrderBy(x => x.BookingTypeID)
                    .Select(x =>
                    new SelectListItem
                    {
                        Value = x.BookingTypeID,
                        Text = x.BookingTypeID
                    }).ToList();
                return new SelectList(bookingtypes, "Value", "Text");
            }
        }
    }
}