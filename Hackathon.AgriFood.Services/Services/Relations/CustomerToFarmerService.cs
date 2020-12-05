using Hackathon.AgriFood.Models.Converters.Interfaces;
using Hackathon.AgriFood.Models.Dtos.Relations;
using Hackathon.AgriFood.Models.Models.Relations;
using Hackathon.AgriFood.Repositories.Providers;
using Hackathon.AgriFood.Services.Interfaces.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Services.Relations
{
    public class CustomerToFarmerService : ICustomerToFarmerService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public CustomerToFarmerService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddCustomerToFarmer(CustomerToFarmerDto customerToFarmerDto)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmer = _entityConverter.GetModelFromDto(customerToFarmerDto);

            await customerToFarmerRepository.Add(customerToFarmer);
        }

        public async Task AddManyCustomerToFarmers(IEnumerable<CustomerToFarmerDto> customerToFarmerDtos)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmers = customerToFarmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToFarmerRepository.AddRange(customerToFarmers);
        }

        public async Task DeleteCustomerToFarmer(CustomerToFarmerDto customerToFarmerDto)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customer = _entityConverter.GetModelFromDto(customerToFarmerDto);

            await customerToFarmerRepository.Delete(customer);
        }

        public async Task DeleteManyCustomerToFarmers(IEnumerable<CustomerToFarmerDto> customerToFarmerDtos)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmers = customerToFarmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToFarmerRepository.DeleteRange(customerToFarmers);
        }

        public async Task<IEnumerable<CustomerToFarmerDto>> GetAllCustomerToFarmers()
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmers = await customerToFarmerRepository.GetAll();

            return customerToFarmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<CustomerToFarmerDto> GetCustomerToFarmer(Guid firstId, Guid secondId)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmer = await customerToFarmerRepository.Get(firstId, secondId);

            return _entityConverter.GetDtoFromModel(customerToFarmer);
        }

        public async Task<IEnumerable<CustomerToFarmerDto>> GetCustomerToFarmersByFirstId(Guid firstId)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmers = await customerToFarmerRepository.GetByFirstId(firstId);

            return customerToFarmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<IEnumerable<CustomerToFarmerDto>> GetCustomerToFarmersBySecondId(Guid secondId)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmers = await customerToFarmerRepository.GetBySecondId(secondId);

            return customerToFarmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task UpdateCustomerToFarmer(CustomerToFarmerDto customerToFarmerDto)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customer = _entityConverter.GetModelFromDto(customerToFarmerDto);

            await customerToFarmerRepository.Update(customer);
        }

        public async Task UpdateManyCustomerToFarmers(IEnumerable<CustomerToFarmerDto> customerToFarmerDtos)
        {
            var customerToFarmerRepository = _repositoryProvider.GetRelationRepository<CustomerToFarmer>();
            var customerToFarmers = customerToFarmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToFarmerRepository.UpdateRange(customerToFarmers);
        }
    }
}
