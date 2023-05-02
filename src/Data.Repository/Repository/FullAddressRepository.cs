
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Repository
{
    public class FullAddressRepository : IXmlImporterRepository<FullAddressEntity>
    {
        private readonly XmlImporterDbContext _ctx;
        public FullAddressRepository(XmlImporterDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<FullAddressEntity> AddAsync(FullAddressEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _ctx.FullAddress.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task AddEntityCollectionAsync(IEnumerable<FullAddressEntity> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _ctx.FullAddress.AddRangeAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(FullAddressEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Task.FromResult(_ctx.FullAddress.Remove(entity));
        }

        public async Task<IEnumerable<FullAddressEntity>> GetAsync()
        {
            return await _ctx.FullAddress.ToListAsync();
        }

        public async Task<FullAddressEntity> GetAsync(Guid id)
        {
            return await _ctx.FullAddress.Where(u => u.FullAddressId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistingAsync(Guid id)
        {
            return await _ctx.FullAddress.AnyAsync(u => u.FullAddressId == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _ctx.SaveChangesAsync() > 0);
        }

        public async Task UpdateAsync(FullAddressEntity entity)
        {
            _ctx.FullAddress.Update(entity);
            await SaveAsync();
        }
    }



}
