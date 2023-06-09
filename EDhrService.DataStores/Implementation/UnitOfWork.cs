﻿using FileMonitor.DataStores.Interfaces;
using FileMonitor.DataStores.Repositories;
using System;

namespace FileMonitor.DataStores.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public StationInformationRepository StationInformationRepository => GetRepository<StationInformationRepository>();        

        #region [Private]
        private T GetRepository<T>() where T : class
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        #endregion
    }
}
