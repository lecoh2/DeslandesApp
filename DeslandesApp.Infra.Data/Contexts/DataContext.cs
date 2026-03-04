using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //Método construtor para receber por meio de injeção de dependência 
        //as configurações do banco de dados, como conexão, tipo etc. 
        public DataContext(DbContextOptions<DataContext> options)
: base(options)
        {

        }
    }
}
