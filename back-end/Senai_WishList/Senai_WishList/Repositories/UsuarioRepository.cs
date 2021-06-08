using Senai_WishList.Contexts;
using Senai_WishList.Domains;
using Senai_WishList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishlistContext ctx = new WishlistContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
