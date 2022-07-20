
using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities
{
    [Table("TB_CDB")]
    public class CdbEntity
    {
        [Column("ID_CDB")]
        public Guid Id { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }
            
        [Column("VALOR_BRUTO")]
        public double ValorBruto { get; set; }

        [Column("VALOR_LIQUIDO")]
        public double ValorLiquido { get; set; }

        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        [Column("ID_BALANCO")]
        public Guid IdBalanco { get; set; }
        public BalancoEntity Balanco { get; set; }
    }
}
