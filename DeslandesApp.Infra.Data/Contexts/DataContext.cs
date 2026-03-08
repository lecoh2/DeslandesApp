using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //Método construtor para receber por meio de injeção de dependência 
        //as configurações do banco de dados, como conexão, tipo etc. 
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoriaMap());
            //modelBuilder.ApplyConfiguration(new MovimentacaoMap());

            //Adicionar todas as classe de mapemenento do Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //definindo as configurações DEFAULT para campos das entidades 
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                //definir o nome das tabelas em caixa alta
                entity.SetTableName(entity.GetTableName().ToUpper());

                //verificando o tipo de campo de cada entidade 
                foreach (var property in entity.GetProperties())
                {
                    //configurações default para campos de texto (string) 
                    if (property.ClrType == typeof(string))
                    {
                        property.SetIsUnicode(false);
                        //campo do tipo varchar 
                        //tamanho máximo de caracteres
                        property.SetMaxLength(250);

                        //definindo como not null (obrigatório)
                        //property.IsNullable = false;
                    }
                    //configurações default para campos do tipo decimal 
                    else if (property.ClrType == typeof(decimal))
                    {
                        //definindo o tipo do campo no banco de dados 
                        property.SetColumnType("decimal(18,2)");
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
