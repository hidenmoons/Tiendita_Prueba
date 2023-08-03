namespace Prueba_Tecnica.Models
{
    public class NewProduct
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string Descript { get; set; } = null!;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Categoria { get; set; } = null!;

        public string Imagen { get; set; } = null!;

    }
}
