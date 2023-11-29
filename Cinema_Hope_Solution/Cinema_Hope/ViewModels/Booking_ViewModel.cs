namespace Cinema_Hope.ViewModels
{
    public class Booking_ViewModel
    {
        public int BookingId { get; set; }

        [Display(Name = "العرض")]
        public int ShowtimeId { get; set; } // Foreign key

        [Display(Name = "المقعد")]
        public int SeatId { get; set; } // Foreign key


        [Display(Name = "اسم المستخدم")]
        public int CustomerId { get; set; } // Foreign key

        [Display(Name = "تاريخ الحجز")]
        public DateTime BookingDate { get; set; }

        [Display(Name = "حالة الحجز")]
        public BookingStatus Status { get; set; }

        public IEnumerable<SelectListItem> SelectLisOfShowTimes = Enumerable.Empty<SelectListItem>();       // for View this Is SelectMenu DropDown
        public IEnumerable<SelectListItem> SelectLisOfSeats = Enumerable.Empty<SelectListItem>();            // for View this Is SelectMenu DropDown
        public IEnumerable<SelectListItem> SelectLisOfCustomers = Enumerable.Empty<SelectListItem>();       // for View this Is SelectMenu DropDown
        public IEnumerable<SelectListItem> SelectLisOfBookingStatus = Enumerable.Empty<SelectListItem>();   // for View this Is SelectMenu DropDown
    }
}
