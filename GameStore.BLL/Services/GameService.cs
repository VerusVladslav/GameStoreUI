using Binbin.Linq;
using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using GameStore.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GameService:IGameService
    {
        private readonly IGenericRepository<Game> gamerepos;
        private readonly IGenericRepository<Genre> genrepos;
        private readonly IGenericRepository<Developer> devrepos;

        public GameService(IGenericRepository<Game> _gamerep, IGenericRepository<Genre> _Genrep, IGenericRepository<Developer> _devrep)
        {
            gamerepos = _gamerep;
            genrepos = _Genrep;
            devrepos = _devrep;

        }

        public void AddGame(Game game)
        {
          //  var entity = game;
            var genre = genrepos.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name);
            
            game.Genre = genre;
            var Dev = devrepos.GetAll().FirstOrDefault(x => x.Name == game.Developer.Name);
            game.Developer = Dev;
            gamerepos.Create(game);
        }

        public void Delete(int id)
        {
            gamerepos.Delete(gamerepos.Find(id));
        }

        public ICollection<Game> FilterGame(List<GameFilter> gameFilters)
        {
            if (gameFilters.Count != 0)
            {
                var predicates = new List<Expression<Func<Game, bool>>>();
                foreach (var type in gameFilters.GroupBy(x=>x.Type))
                {
                    var predicate = PredicateBuilder.Create(type.First().Predicate);
                    for (int i = 1; i < type.Count(); i++)
                    {
                        predicate = predicate.Or(type.ToList()[i].Predicate);
                    }
                    predicates.Add(predicate);
                }
               
                var result= PredicateBuilder.Create(gameFilters[0].Predicate);

                for (int i = 0; i < predicates.Count; i++)
                {
                    result = result.And(predicates[i]);
                }

                var games = gamerepos.Filter(result);
                return games.ToList();
            }
            else
                return gamerepos.GetAll().ToList();
        }

        public ICollection<string> GetAllDevelopers()
        {
            return devrepos.GetAll().Select(x => x.Name).ToList();
        }

        public ICollection<Developer> GetDevelopers()
        {
            return devrepos.GetAll().ToList();
        }
        public ICollection<Genre> GetGenres()
        {
            return genrepos.GetAll().ToList();
        }
        public ICollection<Game> GetAllGames()
        {
            return gamerepos.GetAll().ToList();
        }

        public void AddDeveloper(Developer dev)
        {
            devrepos.Create(dev);
        }
        public void AddGenre(Genre genre)
        {
            genrepos.Create(genre);
        }
        public ICollection<string> GetAllGenres()
        {
            return genrepos.GetAll().Select(x => x.Name).ToList();
        }

        public Game GetGame(int id)
        {
          return gamerepos.Find(id);
        }

        public void Update(Game game)
        {
           
          //  gamerepos.Delete(gamerepos.Find(game.Id));
            gamerepos.Update(game);
        }

        public void Update(Developer developer)
        {
            devrepos.Update(developer);
        }

        public void Update(Genre genre)
        {
            genrepos.Update(genre);

        }

        public void DeleteDeveloper(int id)
        {

            var getid = gamerepos.GetAll().Where(x => x.Developer.Id == id);
            foreach (var item in getid)
            {

            gamerepos.Delete(item);
            }
            devrepos.Delete(devrepos.Find(id));
        }

        public void DeleteGenre(int id)
        {
            var getid = gamerepos.GetAll().Where(x => x.Genre.Id == id);
            foreach (var item in getid)
            {

                gamerepos.Delete(item);
            }
            genrepos.Delete(genrepos.Find(id));
        }

        public Developer GetDeveloper(int id)
        {
          return  devrepos.Find(id);
        }

        public Genre GetGenre(int id)
        {
            return genrepos.Find(id);
        }
    }
}
