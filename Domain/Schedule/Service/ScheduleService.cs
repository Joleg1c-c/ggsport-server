using ggsport.Domain.Schedule.Model.Entity;
using ggsport.Infrastructure;
using ggsport.Repository;

namespace ggsport.Domain.Schedule.Service
{
    public class ScheduleService(IUnitOfWork unitOfWork) : IService<ScheduleModel>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<ScheduleModel>> GetAsync()
        {
            return await _unitOfWork.ScheduleRepository.GetAsync();
        }

        public async Task<ScheduleModel?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ScheduleRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(ScheduleModel entity)
        {
            await _unitOfWork.ScheduleRepository.InsertAsync(entity);
            _unitOfWork.Save();
        }

        public async Task UpdateAsync(ScheduleModel entityToUpdate)
        {
            await _unitOfWork.ScheduleRepository.DeleteAsync(entityToUpdate);
            _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ScheduleRepository.DeleteAsync(id);
            _unitOfWork.Save();
        }
    }
}
