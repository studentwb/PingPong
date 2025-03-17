using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entites
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }
        public virtual int PlayerId { get; set; }
    }
}
