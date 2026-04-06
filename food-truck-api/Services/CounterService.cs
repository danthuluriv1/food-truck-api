
using food_truck_api.Repository;

namespace food_truck_api.Services
{
    public class CounterService
    {
        private readonly CounterRepository _counterRepository;

        public CounterService(CounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
        }

        public async Task<long?> GetCounterCount()
        {
            var counterCollection = await _counterRepository.GetAllAsync();
            var counter = counterCollection.FirstOrDefault(_ => _.Name == "counter");
            if (counter != null)
                return counter.Count;
            return null;
        }

        internal async Task<long?> IncrementCounter()
        {
            var counterCollection = await _counterRepository.GetAllAsync();
            var counter = counterCollection.FirstOrDefault(_ => _.Name == "counter");
            if (counter != null)
            {
                counter.Count = counter.Count + 1;
                await _counterRepository.UpdateAsync(counter);
                return counter.Count;
            }
            return null;
        }
    }
}
