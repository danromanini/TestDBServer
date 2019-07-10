using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Domain.Entities
{
    public class Lancamentos
    {
        [Required]
        [Display(Name = "Descricao Lancamento")]
        public string Lancamento { get; set; }

        [Required]
        [Display(Name = "Tipo de Lancamento")]
        public string TipoLancamento { get; set; }

        [Required]
        [Display(Name = "Conta")]
        public int Conta { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}
