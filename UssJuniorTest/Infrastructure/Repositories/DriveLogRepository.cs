﻿using UssJuniorTest.Abstractions;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest.Infrastructure.Repositories
{
    /// <summary>
    /// Класс-репозиторий записей о водителях.
    /// </summary>
    public class DriveLogRepository : IRepository<DriveLog>
    {
        private readonly IStore _store;

        public DriveLogRepository(IStore store)
        {
            _store = store;
        }

        public DriveLog? Get(long id)
        {
            return _store.GetAllDriveLogs().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DriveLog> GetAll()
        {
            return _store.GetAllDriveLogs();
        }
    }
}
