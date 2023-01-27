using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Musica
    {
        public int Id { get; set; }   
        public  Cantor Cantor { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; }
    }

}
