using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_WishList.Domains;
using Senai_WishList.Interfaces;
using Senai_WishList.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList.Contexts
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository _desejoRepository { get; set; }

        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        /// <summary>
        /// Lista todos os desejos
        /// </summary>
        /// <returns>Status Code OK e uma lista de desejos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_desejoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }
        /// <summary>
        /// Lista com os desejos de um usuario
        /// </summary>
        /// <param name="id">id usuario</param>
        /// <returns>Uma lista de desejos</returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdUser(int id)
        {
            try
            {
                return Ok(_desejoRepository.BuscarPorIdUsuario(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        /// <summary>
        /// Cadastra um desejo
        /// </summary>
        /// <param name="novoDesejo">Objeto novoDesejo que será cadastrado</param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult Post(Desejo novoDesejo)
        {
            try
            {
                _desejoRepository.Cadastrar(novoDesejo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
        /// <summary>
        /// Deleta um desejo
        /// </summary>
        /// <param name="id">id do desejo</param>
        /// <returns>Status Code 201</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _desejoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }


    }
}
