
using System;
using System.ComponentModel.DataAnnotations;

namespace Apolice.Web.Models
{
    public class ApoliceModel
    {
        public int ID { get; set; }

        [Display(Name = "Número da Apólice")]
        [Required(ErrorMessage = "Campo número da apólice obrigatório.")]
        public int NumeroApolice { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [StringLength(20, MinimumLength = 11, ErrorMessage = "Informe o CPF/CNPJ corretamente.")]
        [Required(ErrorMessage = "Campo CPF/CNPJ obrigatório.")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Placa do Veículo")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Campo placa do veículo obrigatório.")]
        [Required(ErrorMessage = "Campo placa do veículo obrigatório.")]
        public string PlacaVeiculo { get; set; }

        [Display(Name = "Valor do Premio")]
        [Required(ErrorMessage = "Campo valor do premio obrigatório.")]
        public decimal ValorPremio { get; set; }
    }
}