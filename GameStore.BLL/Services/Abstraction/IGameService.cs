using GameStore.BLL.Filters;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IGameService
    {
        ICollection<Game> GetAllGames();
        void AddGame(Game game);
        ICollection<string> GetAllGenres();
        ICollection<string> GetAllDevelopers();
        Game GetGame(int id);
        Developer GetDeveloper(int id);
        Genre GetGenre(int id);
        void Update(Game game);
        void Delete(int id);
        ICollection<Game> FilterGame(List<GameFilter> gameFilters);
        void AddDeveloper(Developer developer);
        void AddGenre(Genre genre);
        void Update(Developer developer);
        void Update(Genre genre);
        void DeleteDeveloper(int id);
        void DeleteGenre(int id);


    }
}
