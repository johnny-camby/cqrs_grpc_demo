
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Repository
{
    public class ShipInfoRepository : IXmlImporterRepository<ShipInfoEntity>
    {
        private readonly XmlImporterDbContext _ctx;
        public ShipInfoRepository(XmlImporterDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<ShipInfoEntity> AddAsync(ShipInfoEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _ctx.ShipInfo.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task AddEntityCollectionAsync(IEnumerable<ShipInfoEntity> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _ctx.ShipInfo.AddRangeAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(ShipInfoEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Task.FromResult(_ctx.ShipInfo.Remove(entity));
        }

        public async Task<IEnumerable<ShipInfoEntity>> GetAsync()
        {
            return await _ctx.ShipInfo.ToListAsync();
        }

        public async Task<ShipInfoEntity> GetAsync(Guid id)
        {
            return await _ctx.ShipInfo.Where(u => u.ShipInfoId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistingAsync(Guid id)
        {
            return await _ctx.ShipInfo.AnyAsync(u => u.ShipInfoId == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _ctx.SaveChangesAsync() > 0);
        }

        public async Task UpdateAsync(ShipInfoEntity entity)
        {
            _ctx.ShipInfo.Update(entity);
            await SaveAsync();
        }
    }



}
