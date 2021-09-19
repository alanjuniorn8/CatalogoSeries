using System;
using System.Collections.Generic;
using DIO.Series.Models;

namespace DIO.Series.Repositories.Interfaces
{
    public interface IRepository<T> where T : EntidadeBase
    {
        List<T> GetAll();

        T GetById(Guid id);

        Serie Create(T entidade);

        bool Update(Guid id, T entidade);

        bool Delete(Guid Id);

         
    }
}