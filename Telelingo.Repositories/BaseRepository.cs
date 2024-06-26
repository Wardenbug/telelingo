﻿using Telelingo.DataContext;

namespace Telelingo.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly SqliteContext _dbContext;

        public BaseRepository(SqliteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAllAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
