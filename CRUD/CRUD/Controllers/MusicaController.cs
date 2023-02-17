using CRUD.DTO;
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
            ValidadorDeMusica validadorDeMusica = musica.EhValido();
            if (validadorDeMusica.Status == false)
            {
                return BadRequest(validadorDeMusica.Mensagem);
            }
            musicaRepository.Adicionar(musica);
            return Ok(validadorDeMusica.Mensagem);
        }

        // api/musica/1
        // api/musica?id=1
        [HttpGet]
        public IActionResult GetById([FromQuery] int id)
        {
            //proibir busca no banco por id <= 0
            if (id <= 0)
            {
                return BadRequest("Por favor inserir um Id maior que 0");
            }
            MusicaRepository musica = new MusicaRepository();          
            var buscar = musica.BuscarPorId(id);
            if (buscar == null)
            {
                return BadRequest("Id não encontrado, por favor tente outro!");
            }         
            return Ok(buscar);
          
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public IActionResult BuscarPorNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return BadRequest("Cantor não encontrado, por favor tente outro!");
            }           
            MusicaRepository musicaRepository = new MusicaRepository();
            var buscar = musicaRepository.BuscarPorNome(nome);         
           
            if (buscar == null)
            {
                return BadRequest("Cantor não encontrado, por favor tente outro!");
            }
            return Ok(buscar);           
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
            var deletar = musicaRepository.Deletar(id);         
            return (deletar);
        }


    }

    
}
