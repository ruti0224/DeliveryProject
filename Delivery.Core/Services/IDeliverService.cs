using Delivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Services
{
    public interface IDeliverService
    {
        public IEnumerable<Delivers> GetDelivers();
        public Delivers GetDeliverByID(int id);
        public Delivers AddDeliver(Delivers deliver);
        public Delivers UpdateDeliver(int id, Delivers deliver);
        public void DeleteDeliver(int id);
    }
}
