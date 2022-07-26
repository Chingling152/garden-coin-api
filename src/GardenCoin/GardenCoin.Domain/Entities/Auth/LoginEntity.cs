using System.ComponentModel.DataAnnotations.Schema;

namespace GardenCoin.Domain.Entities.Auth
{
    [Table("TB_LOGIN")]
    public class LoginEntity
    {
        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }

        [Column("ID_USUARIO")]
        public Guid IdUsuario { get; set; }

        public UsuarioEntity Usuario { get; set; }
    }
}
