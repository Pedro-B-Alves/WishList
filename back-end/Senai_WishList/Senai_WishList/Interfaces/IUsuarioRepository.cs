using Senai_WishList.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_WishList.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
