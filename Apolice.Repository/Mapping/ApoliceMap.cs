using System.Data.Entity.ModelConfiguration;
using Apolice.Model.Models;

namespace Apolice.Repository.Mapping
{
    public class ApoliceMap :EntityTypeConfiguration<Model.Models.Apolice> 
    {
       public ApoliceMap()
       {
           //key
           HasKey(t => t.ID);

            //properties
            Property(t => t.NumeroApolice).IsRequired();
           Property(t => t.CpfCnpj).IsRequired().HasMaxLength(20); ;
           Property(t => t.PlacaVeiculo).IsRequired().HasMaxLength(7); ;
           Property(t => t.ValorPremio).IsRequired();
           
           //table
           ToTable("Apolice");
       }
    }
}
