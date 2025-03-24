using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /*
     * [Table]
     * [Column]
     * [NotMapped]
     * [Foreingkey] Define que a propriedade é o vínculo da chave estrangeira
     * [InverseProperty] Define a referência para cada  FK vinda na mesma tabela
     * [DatabaseGenerated] Define se a propriedade vai ser gerenciada pelo banco
     */
    [Index(nameof(Email),IsUnique =true, Name = "IX_EMAIL_UNICO")]
    [Index(nameof(Name), nameof(CPF))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula { get; set; }
        public DateTimeOffset DataCadastro { get; set; }
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }


    }
}
