
using Humanizer;
using System.Threading.Channels;
using System;

namespace Cinema_Hope.Services
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ShowTimeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShowTime>> GetAllShowTimesAsync()
        {
            return await _context.ShowTimes.Include(sh => sh.Movie)
                                            .Include(sh => sh.Screen).ThenInclude(s => s.Cinema)
                                            .ToListAsync();
        }

        public async Task<ShowTime?> GetByIdAsync(int id)
        {
            return await _context.ShowTimes
                                        .Include(sh => sh.Movie)
                                        .Include(sh => sh.Screen)
                                        .SingleOrDefaultAsync(sh => sh.ShowTimeId == id);
        }

        public async Task Create(ShowTime_ViewModel model)
        {
            // create entity model  Then Map Values here from viewModel To Entity_ToDB
            ShowTime showTimeToDB =  _mapper.Map<ShowTime>(model);


            //ShowTime showTimeToDB = new()
            //{
            //    MovieId = model.MovieId,
            //    ScreenId = model.ScreenId,
            //    StartTime = model.StartTime,
            //    EndTime = model.EndTime,
                
            //};

            // save that into DB
            _context.Add(showTimeToDB);
            await _context.SaveChangesAsync();
        }



        /// <summary>
        ///  
        /// In  original code, I were using the `Map` method like this:
        /// 
        /// ```csharp
        ///         showTimeInDB = _mapper.Map<ShowTime?>(model);
        /// ```
        /// 
        /// This line of code is creating a new `ShowTime` object from the `model`, and then assigning this new object to `showTimeInDB`. 
        /// This means that `showTimeInDB` is no longer referring to the object that was retrieved from the database.Instead,
        /// it's now referring to a completely new object.
        /// 
        /// This can cause problems because Entity Framework tracks changes to objects that are retrieved from the database.When
        /// I overwrite `showTimeInDB` with a new object, Entity Framework loses track of the changes that need to be saved to the database.
        /// 
        ///     In the revised code, I changed the `Map` method to this:
        /// ```csharp
        /// _mapper.Map(model, showTimeInDB);
        /// ```
        /// `
        /// This version of the `Map` method takes two parameters: the source object and the destination object. 
        /// It applies the changes from the source object (in this case, `model`) to the destination object (in this case, `showTimeInDB`). 
        /// This means that `showTimeInDB` is still the same object that was retrieved from the database,
        /// but its properties have been updated with the values from `model`.
        /// 
        /// Because `showTimeInDB` is still the same object, Entity Framework can correctly track the changes
        /// and save them to the database when I call `SaveChangesAsync`. This ensures that the updates are correctly saved to the database. 
        /// 
        /// 
        ///  </summary>
        public async Task<ShowTime?> Edit(ShowTime_ViewModel model)
        {
            //check if Entity null in DB

            ShowTime? showTimeInDB = await _context.ShowTimes.FindAsync(model.ShowTimeId);

            if (showTimeInDB == null)
                return null;

            // map new Values From viewModel To EntityInDB
            _mapper.Map(model , showTimeInDB );

            // Save Changes
            var effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
            {

                return showTimeInDB;
            }
            else
            {
                // if changes does not effected,   return null 
                return null;
            }

        }



        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = false;

            ShowTime? showTimeInDB = await _context.ShowTimes.FindAsync(id);

            if (showTimeInDB is null)
                return false;

            _context.Remove(showTimeInDB);

            int effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
                isDeleted = true;

            return isDeleted;
        }



        public IEnumerable<SelectListItem> GetSelectListOf_ShowTimeStatus()
        {
             return Enum.GetValues(typeof(ShowTimeStatus))
                           .Cast<ShowTimeStatus>()
                           .Select(v => new SelectListItem
                           {
                               Text = v.ToString(),
                               Value = v.ToString() // Store the string representation of the enum
                           }).ToList();

        }

        public IEnumerable<SelectListItem> GetSelectListOf_ShowTimes()
        {
            return _context.ShowTimes.Include(sh => sh.Movie)
                                     .Include(sh => sh.Screen).ThenInclude( sc => sc.Cinema)
                                    .ToList()
                                    .Select(sh => new SelectListItem
                                    { Value = sh.ShowTimeId.ToString(), Text = $"{sh.Screen.Cinema.Name} - {sh.Screen.ScreenNumber} - {sh.Screen.ScreenType} - {sh.Movie.Title} " });
        }

        public IEnumerable<SelectListItem> GetSelectListOf_ShowTimesByCinemaId(int cinemaId)
        {
            return _context.ShowTimes.Include(sh => sh.Movie)
                                    .Include(sh => sh.Screen).ThenInclude(sc => sc.Cinema).Where(sh => sh.Screen!.ScreenId == cinemaId)
                                   .ToList()
                                   .Select(sh => new SelectListItem
                                   { Value = sh.ShowTimeId.ToString(), Text = $"{sh.Screen.Cinema.Name} - {sh.Screen.ScreenNumber} - {sh.Screen.ScreenType} - {sh.Movie.Title} " });


        }
    }
}
