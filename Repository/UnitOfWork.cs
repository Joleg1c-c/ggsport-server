using ggsport.Authentication.Model.Entity;
using ggsport.Domain.Schedule.Model.Entity;
using ggsport.Infrastructure;

namespace ggsport.Repository
{
    public class UnitOfWork(GGSportContext context) : IDisposable, IUnitOfWork
    {
        private readonly GGSportContext context = context;
        private IGenericRepository<UserModel> userRepository;
        private IGenericRepository<ScheduleModel> scheduleRepository;

        public IGenericRepository<UserModel> UserRepository
        {
            get
            {
                userRepository ??= new GenericRepository<UserModel>(context);
                return userRepository;
            }
        }

        public IGenericRepository<ScheduleModel> ScheduleRepository
        {
            get
            {
                scheduleRepository ??= new GenericRepository<ScheduleModel>(context);
                return scheduleRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
