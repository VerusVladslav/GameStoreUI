using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class TestService : IGameService
    {
        public void AddDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }

        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDeveloper(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> FilterGame(List<GameFilter> gameFilters)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> GetAllGames()
        {
            return new List<Game>()
            {
                new Game {Name="1111"},
                new Game {Name="2222"},
                new Game {Name="3333"}

            };
        }

        public ICollection<string> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public Developer GetDeveloper(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public Genre GetGenre(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Game game)
        {
            throw new NotImplementedException();
        }

        public void Update(Developer developer)
        {
            throw new NotImplementedException();
        }

        public void Update(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
