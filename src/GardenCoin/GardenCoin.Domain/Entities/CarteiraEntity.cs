using GardenCoin.Auth.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities
{
    [Table("TB_CARTEIRA")]
    public class CarteiraEntity
    {
        [Column("ID_CARTEIRA")]
        public Guid Id { get; set; }

        [Column("VALOR_TOTAL")]
        public double ValorTotal { get ; set ;}

        [Column("DT_CRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("DT_ATUALIZACAO")]
        public DateTime DataAtualizacao { get; set; }

        [Column("ID_CORRETORA")]
        public Guid IdCorretora { get; set; }
        public CorretoraEntity Corretora { get; set; }

        [Column("ID_USUARIO")]
        public Guid IdUsuario { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }
}
