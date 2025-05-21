using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.Repository<User>().GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<User>().GetByIdAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _unitOfWork.Repository<User>().AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, User user)
        {
            await _unitOfWork.Repository<User>().UpdateAsync(id, user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}