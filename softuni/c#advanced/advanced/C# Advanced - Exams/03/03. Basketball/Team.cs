using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        public int Count { get { return Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            OpenPositions--;
            players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }
        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name == name)
                {
                    players.RemoveAt(i);
                    OpenPositions++;
                    return true;
                }
            }
            return false;
        }
        public int RemovePlayerByPosition(string position)
        {
            int countRemovedPlayers = 0;

            while (Players.FirstOrDefault(x => x.Position == position) != null)
            {
                var targetPlayer = Players.FirstOrDefault(x => x.Position == position);
                OpenPositions++;
                players.Remove(targetPlayer);
                countRemovedPlayers++;
            }

            return countRemovedPlayers;
        }
        public Player RetirePlayer(string name)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name == name)
                {
                    Players[i].Retired = true;
                    return Players[i];
                }
            }
            return null;
        }
        public List<Player> AwardPlayers(int games)
        {
            List<Player> list = new List<Player>();
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Games >= games)
                {
                    list.Add(players[i]);
                }
            }
            return list;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in players)
            {
                if (player.Retired == false)
                {
                    sb.AppendLine(player.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}