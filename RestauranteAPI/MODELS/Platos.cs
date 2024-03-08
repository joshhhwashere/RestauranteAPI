using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.MODELS
{
    public class Platos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }


        //Cable Foránea
        public int TipoComidaID { get; set; }
        //Propiedad de navegación
        public TipoComida TipoComida { get; set; }
    }
    public class TipoComida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  ID { get; set; }
        public string Descripcion{ get; set; }

        public ICollection<Platos> Platos { get; set; }
    }
}
