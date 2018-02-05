using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

namespace wepApiMockServer.Controllers
{
    public class HeroesController : ApiController
    {
        [HttpGet, Route("api/heroes")]
        public IEnumerable<Hero> Get() => SetUpMock.Instance.Data;

        [HttpGet, Route("api/heroes/{id:int}")]
        public Hero Get(int id) => SetUpMock.Instance.Data.FirstOrDefault(_ => _.Id == id);

        [HttpGet, Route("api/heroes/total")]
        public int Total() => SetUpMock.Instance.Data.Count;

        [HttpPost, Route("api/heroes")]
        public Hero Post([FromBody]Hero hero) => CreateOrUpdate(hero);

        [HttpPut, Route("api/heroes")]
        public Hero Put([FromBody]Hero hero) => CreateOrUpdate(hero);

        #region private methoods
        private Hero CreateOrUpdate(Hero hero)
        {
            var matches = SetUpMock.Instance.Data.FirstOrDefault(_ => _.Id == hero.Id);
            
            if (matches == null) {
                matches = new Hero
                {
                    Id = SetUpMock.Instance.Data.Count + 11,
                    Name = hero.Name
                };
                SetUpMock.Instance.Add(matches);
            } else {
                matches.Name = hero.Name;
            }

            return matches;
        }
        #endregion
    }

    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
