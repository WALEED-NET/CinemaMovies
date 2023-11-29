namespace Cinema_Hope.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //========= ShowTime Mapping ===============
            CreateMap<ShowTime_ViewModel, ShowTime>().ReverseMap();
            //.ForMember(dest => dest.ShowTimeId, opt => opt.Ignore()); // ignore Id when Mapp From ViewModel To DataBase


            //========= Seat Mapping ===============
            CreateMap<SeatFrom_ViewModel, Seat>().ReverseMap();
        }
    }
}
