using System;
using System.Data.Entity;
using Apolice.Model;
namespace Apolice.Repository
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
