using Apolice.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Repository
{
    public class ApoliceRepository : Repository<Model.Models.Apolice>, IApoliceRepository
    {
        public ApoliceRepository(IDbContext context) : base(context)
        {
        }        
    }
}
