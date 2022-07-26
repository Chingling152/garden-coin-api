using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities
{
    [Table("TB_ATIVO")]
    public class AtivoEntity
    {
        [Column("ID_ATIVO")]
        public Guid Id { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("VALOR_UNITARIO")]
        public double ValorUnitario { get; set; }

        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        [Column("ID_BALANCO")]
        public Guid IdBalanco { get; set; }

        [Column("ID_TIPO_ATIVO")]
        public Guid IdTipoAtivo { get; set; }

        public BalancoEntity Balanco { get; set; }
        public TipoAtivoEntity TipoAtivo { get; set; }
    }
}
