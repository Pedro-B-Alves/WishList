using Senai_WishList.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList.Interfaces
{
    interface IDesejoRepository
    {
        /// <summary>
        /// Lista todos os desejos
        /// </summary>
        /// <returns>Uma Lista de desejos</returns>
        List<Desejo> Listar();

        /// <summary>
        /// Lista todos os desejos de um usuario
        /// </summary>
        /// <param name="id">Id Usuario</param>
        /// <returns>Uma Lista de desejos</returns>
        List<Desejo> BuscarPorIdUsuario(int id);

        /// <summary>
        /// Cadastra um desejo
        /// </summary>
        /// <param name="novoDesejo"></param>
        void Cadastrar(Desejo novoDesejo);

        /// <summary>
        /// Exclui o desejo
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
