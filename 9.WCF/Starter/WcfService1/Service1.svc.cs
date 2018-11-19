using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1 {
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
  public class Service1 : IService1 {
    public string GetData( int value ) {
      return string.Format("You entered: {0}", value);
    }

        public Player GetPlayer(int id)
        {
            return new Player() { ID = id, Name = "Jackson"};
        }

        public List<Player> GetPlayers(int id)
        {
            List<Player> players = new List<Player>();

            Player a = new Player() { ID = id + 1, Name = "Brian" };
            Player b = new Player() { ID = id + 2, Name = "John" };
            Player c = new Player() { ID = id + 3, Name = "David" };

            players.Add(a);
            players.Add(b);
            players.Add(c);

            return players;
        }
    }
}
