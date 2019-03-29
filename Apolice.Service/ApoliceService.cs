using System;
using System.Linq;
using Apolice.Model.Models;
using Apolice.Repository;

namespace Apolice.Service
{
    public class ApoliceService : IApoliceService
    {
        private IApoliceRepository apoliceRepository;


        public ApoliceService(IApoliceRepository apoliceRepository)
        {
            this.apoliceRepository = apoliceRepository;
        }

        public IQueryable<Model.Models.Apolice> GetApolices()
        {
            return apoliceRepository.Table;
        }

        public Model.Models.Apolice GetApolice(int id)
        {
            return apoliceRepository.GetById(id);
        }

        public void Insert(Model.Models.Apolice apolice)
        {            
            apoliceRepository.Insert(apolice);
        }

        public void Update(Model.Models.Apolice apolice)
        {            
            apoliceRepository.Update(apolice);
        }

        public void Delete(Model.Models.Apolice apolice)
        {
            apoliceRepository.Delete(apolice);
        }
               
        IQueryable<Model.Models.Apolice> IApoliceService.GetListByApolices(string chassi)
        {
            return apoliceRepository.Table.Where(p => p.NumeroApolice.ToString().Contains(chassi.ToUpper()));
        }
        
        
    }
}
