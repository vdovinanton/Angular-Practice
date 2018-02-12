using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using wepApiMockServer.Controllers;

namespace wepApiMockServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class SetUpMock
    {
        // static storrage
        public static SetUpMock Instance => _instance.Value;
        private static readonly Lazy<SetUpMock> _instance = new Lazy<SetUpMock>(() => new SetUpMock());
        private SetUpMock() { }

        public IList<Hero> _list = new List<Hero>
            {
                new Hero { Id = 11, Name = "Mr. Nice" },
                new Hero { Id = 12, Name = "Narco" },
                new Hero { Id = 13, Name = "Bombasto" },
                new Hero { Id = 14, Name = "Celeritas" },
                new Hero { Id = 15, Name = "Magneta" },
                new Hero { Id = 16, Name = "RubberMan" },
                new Hero { Id = 17, Name = "Dynama" },
                new Hero { Id = 18, Name = "Dr IQ" },
                new Hero { Id = 19, Name = "Magma" },
                new Hero { Id = 20, Name = "Tornado" }
            };

        public IList<Hero> Data
        {
          get { return _list; }
          set
            {
              _list.Clear();
              _list = value;
            }
        }
        public void Add(Hero hero) => _list.Add(hero);
    }
}
