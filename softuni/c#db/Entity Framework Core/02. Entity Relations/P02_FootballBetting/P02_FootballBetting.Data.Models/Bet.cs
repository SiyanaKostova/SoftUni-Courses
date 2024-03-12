using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Bet
    {
        public int BetId { get; set; }
        public decimal Amount { get; set; }

        [Required]
        public string Prediction { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
    }
}
