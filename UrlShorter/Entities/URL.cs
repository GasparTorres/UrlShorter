using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UrlShorter.Entities;

namespace UrlShorter.entities
{
        public class URL
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string? URLShort { get; set; }

            public string? URLLong { get; set; }

            public int contador  { get; set; } = 1;

            [ForeignKey("IdCategoria")]
            public int IdCategoria { get; set; }
            public Categoria Categoria { get; set; }

            [ForeignKey("IdUser")]

            public int IdUser { get; set; }

            public User? User { get; set; }


    }

}
