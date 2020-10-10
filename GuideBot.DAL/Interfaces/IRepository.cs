using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuideBot.DAL.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> GetByFilter<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto;

        T GetExemplarByFilter<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto;

        T AddExemplar<T>(T exemplar) where T : BaseDto;

        void DeleteById<T>(int id) where T : BaseEntity;

        void DeleteByFilter<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto;

        void UpdateExemplar<T>(T exemplar) where T : BaseDto;

        Task<IEnumerable<T>> GetByFilterAsync<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto;

        Task<T> GetExemplarByFilterAsync<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto;

        Task<T> AddExemplarAsync<T>(T exemplar) where T : BaseDto;

        Task DeleteByIdAsync<T>(int id) where T : BaseEntity;

        Task DeleteByFilterAsync<T>(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties) where T : BaseDto;

        Task UpdateExemplarAsync<T>(T exemplar) where T : BaseDto;
    }
}
