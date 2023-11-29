namespace Cinema_Hope.ViewModels
{
    public class SeatFrom_ViewModel
    {
        public int SeatId { get; set; }
        public int ScreenId { get; set; } // Foreign key
        public short RowNumber { get; set; }
        public short SeatNumber { get; set; }
        public bool IsBookedUp { get; set; } = false;

        public IEnumerable<SelectListItem> SelectListOfScreens = Enumerable.Empty<SelectListItem>(); // for View this Is SelectMenu DropDown

    }
}
