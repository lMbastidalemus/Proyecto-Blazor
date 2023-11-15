using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Producto
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BlazorContext context = new DL.BlazorContext())
                {
                    var query = context.Productos.FromSqlRaw("GetAllProductos");
                    if (query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach (var obj in query)
                        {
                            ML.Producto productoResult = new ML.Producto();
                            productoResult.IdProducto = obj.IdProducto;
                            productoResult.Nombre = obj.Nombre;
                            productoResult.Precio = obj.Precio;
                            productoResult.Categorias = new ML.Categorias();
                            productoResult.Categorias.IdCategoria = obj.IdCategoria.Value;
                            productoResult.Categorias.Categoria = obj.Categoria;
                            result.Objects.Add(productoResult);
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
        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BlazorContext context = new DL.BlazorContext())
                {
                    var obj = context.Productos.FromSqlRaw($"GetByIdProductos '{IdProducto}'").AsEnumerable().SingleOrDefault();
                    if (obj != null)
                    {

                        ML.Producto productoResult = new ML.Producto();
                        productoResult.IdProducto = obj.IdProducto;
                        productoResult.Nombre = obj.Nombre;
                        productoResult.Precio = obj.Precio;
                        productoResult.Categorias = new ML.Categorias();
                        productoResult.Categorias.IdCategoria = obj.IdCategoria.Value;
                        productoResult.Categorias.Categoria = obj.Categoria;
                        result.Object = productoResult;
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

        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BlazorContext context = new DL.BlazorContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddProductos '{producto.Nombre}','{producto.Precio}', '{producto.Categorias.IdCategoria}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BlazorContext context = new DL.BlazorContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateProductos '{producto.IdProducto}','{producto.Nombre}','{producto.Precio}', '{producto.Categorias.IdCategoria}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BlazorContext context = new DL.BlazorContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteProductos '{IdProducto}'");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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