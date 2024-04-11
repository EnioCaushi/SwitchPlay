using SwitchPlay.Data;

namespace SwitchPlay.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {
        private readonly SwitchPlayContext _context;
        private List<Game> games = new List<Game>();
        public GameRepository(SwitchPlayContext context) : base(context) { _context = context; }

    }
    
}
