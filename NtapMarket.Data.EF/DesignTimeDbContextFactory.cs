using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NtapMarket.Data.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        private string _connectionString 
        { 
            get 
            { 
                return "data source=localhost;initial catalog=NtapMarket;Integrated Security=True;";
            }
        }

        public DBContext CreateDbContext(string[] args)
        {
            return new DBContext(_connectionString);
        }
    }
}
