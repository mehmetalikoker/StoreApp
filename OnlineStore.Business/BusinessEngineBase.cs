﻿using AutoMapper;
using OnlineStore.Core;
using OnlineStore.Core.Common.Contracts;
using OnlineStore.Core.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Core.Common.Contracts.ResponseMessages;

namespace OnlineStore.Business
{
    /// <summary>
    /// DI Frameworküne mapper,configuration,logger larımızı inject ediyoruz.
    /// </summary>
    public class BusinessEngineBase
    {
        protected IMapper Mapper;
        protected IConfigurationHelper ConfigurationHelper;
        private readonly ILogger _logger;

        public BusinessEngineBase()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                RequestMessagesToEntities.Map(cfg);
                EntitiesToResponseMessages.Map(cfg);
            });

            Mapper = mapperConfiguration.CreateMapper();
            ConfigurationHelper = DependencyContainer.Resolve<IConfigurationHelper>();
            _logger = (ILogger)DependencyContainer.Resolve(typeof(ILogger));

        }

        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func)
        {
            try
            {
                var result = func.Invoke();

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);

                throw;
            }
        }

        protected void ExecuteWithExceptionHandledOperation<T>(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);

                throw;
            }
        }

        internal Task<List<ProductResponse>> ExecuteWithExceptionHandledOperation(Func<Task<List<ProductResponse>>> p)
        {
            throw new NotImplementedException();
        }
    }
}
