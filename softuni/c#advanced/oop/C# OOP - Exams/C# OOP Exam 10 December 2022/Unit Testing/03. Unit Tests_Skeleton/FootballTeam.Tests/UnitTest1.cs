using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;
        private FootballPlayer player;
        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("Zaza", 20);
            player = new FootballPlayer("Baba", 13, "Midfielder");
        }

        [Test]
        public void TestFotballTeamConstructor()
        {
            string expectedName = "Zaza";
            int expectedCapacity = 20;

            Assert.That(team.Name, Is.EqualTo(expectedName));
            Assert.That(team.Capacity, Is.EqualTo(expectedCapacity));

            Type t = team.Players.GetType();
            Type expectedType = typeof(List<FootballPlayer>);

            Assert.That(expectedType, Is.EqualTo(t));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestIsNameIsNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(name, 20));
        }

        [Test]
        [TestCase(10)]
        [TestCase(0)]
        public void TestCapacityValue(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Zaza", capacity));
        }

        [Test]
        public void CheckIfAddHasAvailablePosition()
        {
            FootballPlayer player1 = new FootballPlayer("Player1Name", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Playe2rName", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Player3Name", 3, "Midfielder");
            FootballPlayer player4 = new FootballPlayer("Player4Name", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("Player5Name", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("Player6Name", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("Player7Name", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Player8Name", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Player9Name", 9, "Midfielder");
            FootballPlayer player10 = new FootballPlayer("Player10Name", 10, "Midfielder");
            FootballPlayer player11 = new FootballPlayer("Player11Name", 11, "Midfielder");
            FootballPlayer player12 = new FootballPlayer("Player12Name", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Player13Name", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Player14Name", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("Player15Name", 15, "Forward");
            FootballPlayer player16 = new FootballPlayer("Player16Name", 16, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 15);

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);

            var actualResult = team.AddNewPlayer(player16);

            var expectedResult = "No more positions available!";

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
        [Test]
        public void CheckIfTeamAddsPlayerCorrrectly()
        {
            team.AddNewPlayer(player);

            Assert.That(team.Players.Count, Is.EqualTo(1));
            Assert.That(team.Players.Contains(player));

            var actualAddResult = team.AddNewPlayer(player);
            var expectedResult = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            Assert.That(expectedResult, Is.EqualTo(actualAddResult));
        }

        [Test]
        public void TestPickPlayerWorksCorrectly()
        {
            team.AddNewPlayer(player);
            FootballPlayer playerFound = team.Players.FirstOrDefault(p => p.Name == "Baba");
            FootballPlayer playerPicked = team.PickPlayer("Baba");
            Assert.That(playerPicked, Is.EqualTo(playerFound));
        }

        [Test]
        public void TestPickPlayerScoreCorrectly()
        {
            team.AddNewPlayer(player);
            FootballPlayer playerFound = team.Players.FirstOrDefault(p => p.PlayerNumber == 13);
            Assert.That(player, Is.EqualTo(playerFound));

            var expectedResult = team.PlayerScore(13);

            var actualResult = "Baba scored and now has 1 for this season!";

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}