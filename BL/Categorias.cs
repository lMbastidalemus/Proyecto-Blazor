using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categorias
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.BlazorContext context = new DL.BlazorContext())
                {
                    var query = context.Categorias.FromSqlRaw($"GetAllCategorias");
                    if(query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach (var obj in query)
                        {
                            ML.Categorias categorias = new ML.Categorias();
                            categorias.IdCategoria = obj.IdCategoria;
                            categorias.Categoria = obj.Categoria1;
                            result.Objects.Add(categorias);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }
            return result;
        }
    }
}
