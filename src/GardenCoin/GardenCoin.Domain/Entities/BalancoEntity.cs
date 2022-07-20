using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities
{
    [Table("TB_BALANCO")]
    public class BalancoEntity
    {
        [Column("ID_BALANCO")]
        public Guid Id { get; set; }

        [Column("VALOR_TOTAL")]
        public double ValorTotal { get; set; }

        [Column("ID_CARTEIRA")]
        public Guid IdCarteira { get; set; }
        public CarteiraEntity Cateira { get; set; }

        public List<AtivoEntity> Ativos { get; set; }
        public List<CdbEntity> Cdbs { get; set; }
    }
}
