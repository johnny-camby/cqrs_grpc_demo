
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Repository
{
    public class OrderRepository : IXmlImporterRepository<OrderEntity>
    {
        private readonly XmlImporterDbContext _ctx;
        public OrderRepository(XmlImporterDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<OrderEntity> AddAsync(OrderEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _ctx.Orders.AddAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task AddEntityCollectionAsync(IEnumerable<OrderEntity> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _ctx.Orders.AddRangeAsync(entity);
        }

        public async Task DeleteAsync(OrderEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Task.FromResult(_ctx.Orders.Remove(entity));
            await SaveAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetAsync()
        {
            return await _ctx.Orders.Include(f => f.ShipInfo).ToListAsync();
        }

        public async Task<OrderEntity> GetAsync(Guid id)
        {
            return await _ctx.Orders.Include(f => f.ShipInfo).Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistingAsync(Guid id)
        {
            return await _ctx.Orders.Include(f => f.ShipInfo).AnyAsync(u => u.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _ctx.SaveChangesAsync() > 0);
        }

        public async Task UpdateAsync(OrderEntity entity)
        {
            var shipInfo = new ShipInfoEntity
            {
                ShipAddress = entity.ShipInfo.ShipAddress,
                ShipCity = entity.ShipInfo.ShipCity,
                ShipCountry = entity.ShipInfo.ShipCountry,
                ShipInfoId = entity.ShipInfoId,
                ShipName = entity.ShipInfo.ShipName,
                ShippedDate = entity.ShipInfo.ShippedDate,
                ShipPostalCode = entity.ShipInfo.ShipPostalCode,
                ShipRegion = entity.ShipInfo.ShipRegion,
                ShipVia = entity.ShipInfo.ShipVia,
                Freight = entity.ShipInfo.Freight
            };
            _ctx.ShipInfo.Update(shipInfo);
            _ctx.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
    }



}
