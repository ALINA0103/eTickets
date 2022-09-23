using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        IEnumerable<object> Actors { get; }

        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
