namespace Portafolio.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Experiencia")]
    public partial class Experiencia
    {
        public int id { get; set; }

        public int Usuario_id { get; set; }

        public byte Tipo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(10)]
        public string Desde { get; set; }

        [Required]
        [StringLength(10)]
        public string Hasta { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public Experiencia Obtener(int id)
        {
            var experiencia = new Experiencia();

            try
            {
                using (var ctx = new PortafolioModel())
                {
                    experiencia = ctx.Experiencias.Where(x => x.id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return experiencia;
        }

        public ResponseModel Eliminar(int id)
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new PortafolioModel())
                {
                    var experiencia = ctx.Entry(this);
                    experiencia.State = EntityState.Deleted;
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

        public List<Experiencia> ObtenerLista(int tipo, int id_usuario)
        {
            var experiencia = new List<Experiencia>();

            try
            {
                using (var ctx = new PortafolioModel())
                {
                    experiencia = ctx.Experiencias.Where(x => x.Tipo == tipo)
                                                  .Where(x => x.Usuario_id== id_usuario)
                                                  .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return experiencia;
        }

        public ResponseModel Guardar()
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new PortafolioModel())
                {
                    var experiencia = ctx.Entry(this);
                    if (this.id > 0)
                    {
                        experiencia.State = EntityState.Modified;
                    }
                    else
                    {
                        experiencia.State = EntityState.Added;
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
