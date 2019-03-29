using Apolice.Model.Models;
using Apolice.Repository;
using Apolice.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Apolice.Test
{
    [TestClass]
    public class ApoliceTest
    {
        [TestMethod]
        public void AdicionarApolice()
        {
            var apolice = new Model.Models.Apolice
            {
                NumeroApolice = 123456789,
                CpfCnpj = "000.000.001-91",
                PlacaVeiculo = "ABC1234",
                ValorPremio = 20M
            };

            var apoliceRepositoryMoq = new Mock<IApoliceRepository>();
            var serviceVeilculo = new ApoliceService(apoliceRepositoryMoq.Object);
            serviceVeilculo.Insert(apolice);

            apoliceRepositoryMoq.Verify(r => r.Insert(
                It.Is<Model.Models.Apolice>(v => v.PlacaVeiculo == apolice.PlacaVeiculo)));

        }

        [TestMethod]
        public void AlterarApolice()
        {
            var apolice = new Model.Models.Apolice
            {
                NumeroApolice = 123456789,
                CpfCnpj = "000.000.001-91",
                PlacaVeiculo = "ABC1234",
                ValorPremio = 20M
            };

            var apoliceRepositoryMoq = new Mock<IApoliceRepository>();
            var serviceVeilculo = new ApoliceService(apoliceRepositoryMoq.Object);
            
            serviceVeilculo.Update(apolice);

            apoliceRepositoryMoq.Verify(r => r.Update(
                It.Is<Model.Models.Apolice>(v => v.PlacaVeiculo == apolice.PlacaVeiculo)));

        }

        [TestMethod]
        public void ConsultarApolice()
        {
            var apolice = new Model.Models.Apolice
            {
                NumeroApolice = 123456789,
                CpfCnpj = "000.000.001-91",
                PlacaVeiculo = "ABC1234",
                ValorPremio = 20M
            };


            var apoliceRepositoryMoq = new Mock<IApoliceRepository>();
            var serviceVeilculo = new ApoliceService(apoliceRepositoryMoq.Object);

            serviceVeilculo.GetApolice(apolice.ID);

            apoliceRepositoryMoq.Verify(r => r.GetById(
                It.Is<int>(v => v == apolice.ID)));
        }

        [TestMethod]
        public void ExcluirApolice()
        {
            var apolice = new Model.Models.Apolice
            {
                NumeroApolice = 123456789,
                CpfCnpj = "000.000.001-91",
                PlacaVeiculo = "ABC1234",
                ValorPremio = 20M
            };

            var apoliceRepositoryMoq = new Mock<IApoliceRepository>();
            var serviceVeilculo = new ApoliceService(apoliceRepositoryMoq.Object);
            serviceVeilculo.Delete(apolice);

            apoliceRepositoryMoq.Verify(r => r.Delete(
                It.Is<Model.Models.Apolice>(v => v.ID == apolice.ID)));

        }
    }
}
