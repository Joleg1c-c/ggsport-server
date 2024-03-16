using ggsport.Authentication.Model.Entity;
using ggsport.Domain.Schedule.Model.Entity;

namespace ggsport.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<UserModel> UserRepository { get;}
        IGenericRepository<ScheduleModel> ScheduleRepository { get;}
        void Dispose();
        void Save();
    }
}