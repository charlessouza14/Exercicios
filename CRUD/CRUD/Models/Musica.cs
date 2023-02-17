using CRUD.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

namespace CRUD.Models
{
    public class Musica
    {
        public int Id { get; set; }   
        public  Cantor Cantor { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; }

        public ValidadorDeMusica EhValido()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))
                return new ValidadorDeMusica(false, "Por favor digite um nome válido!");


            if (string.IsNullOrWhiteSpace(this.Cantor.Nome))
                return new ValidadorDeMusica(false, "Por favor digite um Cantor.Nome válido!");


            if (string.IsNullOrWhiteSpace(this.Genero))
                return new ValidadorDeMusica(false, "Por favor digite um gênero válido!");

            else
                return new ValidadorDeMusica(true, "Criado com sucesso!");

        }
        
    }

}
