using GameStore.DAL.Context;
using GameStore.DAL.Entityes.Base;
using GameStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly GameStoreDB db;
        private readonly DbSet<T> set;

        private bool AutoSaveChanges { get; set; } = true;
        public DbRepository(GameStoreDB dB)
        {
            db = dB;
            set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => set;

        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);
        public async Task<T> GetAsync(int id, CancellationToken Cancel = default) =>
           await Items.SingleOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false);



        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                db.SaveChanges();

        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }



        public void Remove(int id)
        {
            var item = set.Local.FirstOrDefault(i => i.Id == id) 
                ?? new T { Id = id};

            
            db.Remove(item);
            if (AutoSaveChanges)
                db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            db.Remove(new T { Id = id });
            if (AutoSaveChanges)
              await  db.SaveChangesAsync(Cancel);
        }

        
    }
}
