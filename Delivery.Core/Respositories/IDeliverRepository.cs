using Delivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Respositories
{
    public interface IDeliverRepository
    {
        public Task<List<Delivers>> GetDeliversAsync();
        public Task<Delivers> GetDeliverByIDAsync(int id);

<<<<<<< HEAD
        public Task<Delivers> AddDeliverAsync(Delivers deliver);
=======
        public Task<Delivers> AddDeliverAsync( Delivers deliver);
>>>>>>> dcb4604375466e6b02a5f82eb243040f91a35087
        public Task<Delivers> UpdateDeliverAsync(int id, Delivers deliver);
        public Task DeleteDeliverAsync(int id);
        public Task SaveAsync();

    }
}
