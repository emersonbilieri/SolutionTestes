using System.Linq;
using Apolice.Model.Models;

namespace Apolice.Service
{
    public interface IApoliceService
    {
        IQueryable<Model.Models.Apolice> GetApolices();
        IQueryable<Model.Models.Apolice> GetListByApolices(string chassi);
        Model.Models.Apolice GetApolice(int id);        
        void Insert(Model.Models.Apolice apolice);        
        void Update(Model.Models.Apolice apolice);
        void Delete(Model.Models.Apolice apolice);
    }
}
