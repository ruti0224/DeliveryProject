using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Core.Respositories;
using Delivery.Core.Models;
using Delivery.Core.Services;

namespace Delivery.Service
{
    public class DeliverService: IDeliverService
    { 
        private readonly IDeliverRepository _deliverRepo;

        public DeliverService(IDeliverRepository deliverRepo)
        {
            _deliverRepo = deliverRepo;
        }
        public IEnumerable<Delivers> GetDelivers()
        {
            return _deliverRepo.GetDelivers();
        }
        public Delivers GetDeliverByID(int id)
        {
            return _deliverRepo.GetDeliverByID(id);
        }
        public Delivers AddDeliver(Delivers deliver)
        {
              var d=  _deliverRepo.AddDeliver(deliver);
               _deliverRepo.Save();
            return d;

        }
        public Delivers UpdateDeliver(int id, Delivers deliver)
        {        
           var d= _deliverRepo.UpdateDeliver(id, deliver);
            _deliverRepo.Save();
            return d;

        }
        public void DeleteDeliver(int id)
        {
            _deliverRepo.DeleteDeliver(id);
            _deliverRepo.Save();

        }
    }
}
