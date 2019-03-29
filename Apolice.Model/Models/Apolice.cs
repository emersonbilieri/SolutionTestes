namespace Apolice.Model.Models
{
    public class Apolice : BaseEntity
    {
        public int NumeroApolice { get; set; }
        public string CpfCnpj { get; set; }
        public string PlacaVeiculo { get; set; }
        public decimal ValorPremio { get; set; }
    }
}
