using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities
{
    [Table("TB_CORRETORA")]
    public class CorretoraEntity
    {
        [Column("ID_CORRETORA")]
        public Guid Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("ULTIMA_ATUALIZACAO")]
        public DateTime UltimaAtualizacao { get; set; }

        public List<CarteiraEntity> Carteiras { get; set; }
    }
}
