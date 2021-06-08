using Microsoft.EntityFrameworkCore;
using Senai_WishList.Contexts;
using Senai_WishList.Domains;
using Senai_WishList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {

        WishlistContext ctx = new WishlistContext();

        /// <summary>
        /// Busca pelo id o usuario que fez o desejo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma lista de desejos é retornada</returns>
        public List<Desejo> BuscarPorIdUsuario(int id)
        {
            return ctx.Desejos
                .Include(d => d.IdUsuarioNavigation)
                .Select(d => new Desejo
                {
                    IdDesejo = d.IdDesejo
                   ,
                    Descricao = d.Descricao
                   ,
                    DataCriacao = d.DataCriacao
                   ,
                    IdUsuario = d.IdUsuario
                   ,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = d.IdUsuarioNavigation.IdUsuario
                      ,
                        Email = d.IdUsuarioNavigation.Email
                    }
                })
                .Where(d => d.IdUsuario == id)
                .ToList();
        }
        /// <summary>
        /// Cadastra um desejo
        /// </summary>
        /// <param name="novoDesejo">Desejo que deseja cadastrar</param>
        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();
        }
        /// <summary>
        /// Deleta um desejo
        /// </summary>
        /// <param name="id">id do desejo que deseja deletar</param>
        public void Deletar(int id)
        {
            Desejo desejoBuscado = ctx.Desejos.Find(id);

            ctx.Desejos.Remove(desejoBuscado);

            ctx.SaveChanges();
        }
        /// <summary>
        /// Lista todos os desejos
        /// </summary>
        /// <returns>Uma lista de desejos é retornada</returns>
        public List<Desejo> Listar()
        {
            return ctx.Desejos
                .Include(d => d.IdUsuarioNavigation)
                .Select(d => new Desejo
                {
                    IdDesejo = d.IdDesejo
                   ,Descricao = d.Descricao
                   ,DataCriacao = d.DataCriacao
                   ,IdUsuario = d.IdUsuario
                   ,IdUsuarioNavigation = new Usuario
                   {
                       IdUsuario = d.IdUsuarioNavigation.IdUsuario
                      ,Email = d.IdUsuarioNavigation.Email
                   }
                })
                .ToList();
        }
    }
}
