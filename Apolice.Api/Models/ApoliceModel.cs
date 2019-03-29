
using System;
using System.ComponentModel.DataAnnotations;

namespace Apolice.Api.Models
{
    public class ApoliceModel
    {
        public int ID { get; set; }
        public int NumeroApolice { get; set; }
        public string CpfCnpj { get; set; }
        public string PlacaVeiculo { get; set; }
        public decimal ValorPremio { get; set; }
    }
}