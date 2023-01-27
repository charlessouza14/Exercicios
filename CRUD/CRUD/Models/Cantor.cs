using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Cantor 
    {
        public  int Id { get; set; }
        public string Nome { get; set; }   
        public DateTime DataDeNascimento { get; set; }
        
    }
}
