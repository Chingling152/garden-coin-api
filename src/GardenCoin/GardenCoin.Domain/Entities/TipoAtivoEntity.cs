using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities
{
    [Table("TB_TIPO_ATIVO")]
    public class TipoAtivoEntity
    {
        [Column("ID_TIPO_ATIVO")]
        public Guid Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        public List<AtivoEntity> Ativos { get; set; }
    }
}
