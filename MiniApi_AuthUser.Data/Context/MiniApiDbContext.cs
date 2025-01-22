using Microsoft.EntityFrameworkCore;
using MiniApi_AuthUser.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Data.Context
{
    public class MiniApiDbContext:DbContext
    {
        public MiniApiDbContext(DbContextOptions<MiniApiDbContext> option):base(option)
        {
            
        }

        #region User
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
