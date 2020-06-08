using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioWM.Domain.Entities
{
    public class AnuncioEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "Este campo pode ter no maximo 45 caracteres")]
        public string Marca { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "Este campo pode ter no maximo 45 caracteres")]
        public string Modelo { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "Este campo pode ter no maximo 45 caracteres")]
        public string Versao { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public int Quilometragem { get; set; }
        [Required]
        public string Observacao { get; set; }
    }
}
