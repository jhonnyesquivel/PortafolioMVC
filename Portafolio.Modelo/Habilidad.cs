namespace Portafolio.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Habilidad")]
    public partial class Habilidad
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Range(1, 100, ErrorMessage ="Debe ingresar un valor entre 1 y 100")]
        public int Dominio { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Habilidad Obtener(int id)
        {
            var habilidad = new Habilidad();

            try
            {
                using (var ctx = new PortafolioModel())
                {
                    habilidad = ctx.Habilidads.Where(x => x.id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return habilidad;
        }

        public ResponseModel Eliminar(int id)
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new PortafolioModel())
                {
                    var Habilidad = ctx.Habilidads.Where(x => x.id == id).FirstOrDefault();
                    var entry = ctx.Entry(Habilidad);
                    entry.State = EntityState.Deleted;
                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return rm;
        }

        public List<Habilidad> ObtenerLista(int id_usuario)
        {
            var Habilidad = new List<Habilidad>();

            try
            {
                using (var ctx = new PortafolioModel())
                {
                    Habilidad = ctx.Habilidads.Where(x => x.Usuario_id == id_usuario)
                                              .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Habilidad;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new PortafolioModel())
                {
                    var Habilidad = ctx.Entry(this);
                    if (this.id > 0)
                    {
                        Habilidad.State = EntityState.Modified;
                    }
                    else
                    {
                        Habilidad.State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return rm;

        }
    }
}
