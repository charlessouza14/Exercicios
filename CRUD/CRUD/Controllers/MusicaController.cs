using CRUD.Models;
using CRUD.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MusicaController : ControllerBase
    {   
                
        [HttpPost]
        public IActionResult Criar([FromBody] Musica musica)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            musicaRepository.Adicionar(musica);
            if (musica.Nome == null)
            {
                return Ok("Por favor, inserir um nome válido");
            }
            if (musica.Cantor.Nome == null)
            {
                return Ok("Por favor, inserir um nome válido");
            }

            return Ok("Criado com sucesso!");
        }
        // api/musica/1
        // api/musica?id=1
        [HttpGet]
        public IActionResult GetById([FromQuery] int id)
        {
            MusicaRepository musica = new MusicaRepository();
            var buscar = musica.BuscarPorId(id);
            return (buscar);
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public IActionResult BuscarPorNome([FromQuery] string nome)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            var buscar = musicaRepository.BuscarPorNome(nome);           
            return (buscar);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Musica musica)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            var atualizar = musicaRepository.Atualizar(musica);
            return (atualizar);
        }

        [HttpDelete]
        public IActionResult Deletar([FromQuery] int id)
        {
            MusicaRepository musicaRepository = new MusicaRepository();
            musicaRepository.Deletar(id);
            if (musicaRepository == null)
            {
                return Ok("Musica não encontrada, por favor envie um Id valido");
            }

            return Ok("Musica excluida com sucesso!");
        }


    }

    
}
