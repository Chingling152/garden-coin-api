using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Auth.Domain.Entities
{
    [Table("TB_USUARIO")]
    public class UsuarioEntity
    {
        [Column("ID_USUARIO")]
        public Guid Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("SOBRENOME")]
        public string? Sobrenome { get; set; }

        [Column("CPF")]
        public string? Cpf { get; set; }

        [Column("DT_CRIACAO")]
        public DateTime DataCriacao { get; set; }

        public IEnumerable<LoginEntity> Logins { get; set; }

        public UsuarioEntity()
        {
            this.Logins = new List<LoginEntity>();
        }
    }
}
