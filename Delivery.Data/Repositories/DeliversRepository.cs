using Delivery.Core.Respositories;
using Delivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data.Repositories
{
    public class DeliversRepository : IDeliverRepository
    {
        private readonly DataContext _context;

        public DeliversRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Delivers> GetDelivers()
        {
            return _context.delivers.Include(d=>d.Packages);

        }
        public Delivers GetDeliverByID(int id)
        {
            return _context.delivers.ToList().Find(x=>x.Id==id);

        }
        public Delivers AddDeliver(Delivers deliver)
        {
            var d = _context.delivers .ToList().Find(p => p.Id == deliver.Id);
            if (d == null)
            {
                _context.delivers.Add(deliver);
                
            }
            return d;
        }
        public Delivers UpdateDeliver(int id, Delivers deliver)
        {
            var d = _context.delivers.ToList().Find(pac => pac.Id == deliver.Id);
            if (d != null)
            {
                d.Email = deliver.Email;
                d.Name = deliver.Name;
                d.Address = deliver.Address;
                d.PhoneNumber = deliver.PhoneNumber;
            }
            return d;
        }
        public void DeleteDeliver(int id)
        {
            var d = _context.delivers.ToList().Find(p => p.Id == id);
            if (d != null)
            {
                _context.delivers.Remove(d);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
