using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Utils
{
    /// <summary> 
    /// Representa o resultado paginado de uma consulta. 
    /// </summary> 
    public class PageResult<T>
    {

        /// Coleção de itens (entidade) retornados  na página atual da consulta

        public IEnumerable<T> Items { get; set; } = new List<T>();

        /// Número da página atual da consulta 
        public int PageNumber { get; set; }

        /// Quantidade de registros exibidos por página 

        public int PageSize { get; set; }

        /// Quantidade total de registros encontrados na consulta(sem paginação)

        public int TotalCount { get; set; }

        /// Quantidade total de páginas, calculado  com base no TotalCount e PageSize
        public int TotalPages => (int)Math.Ceiling
     ((double)TotalCount / PageSize);

        /// Indica se existe uma próxima página após a atual 
        public bool HasNextPage => PageNumber < TotalPages;

        /// Indica se existe uma página anterior à atual.

        public bool HasPreviousPage => PageNumber > 1;
    }
}
