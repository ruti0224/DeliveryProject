using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Core.Respositories;
using Delivery.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data.Repositories
{
    public class PackagesRepository : IPackagesRespository
    {
        private readonly DataContext _context;
        public PackagesRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Packages> GetPackages()
        {
            return _context.packages.Include(p=>p.Deliver).Include(p=>p.Recipient);

        }
        public Packages GetPackageByID(int code)
        {
            var p= _context.packages.ToList().Find(x => x.Id == code);
            if (p == null)
                return null;
            return p;

        }
        public Packages AddPackage(Packages package)
        {
            var d = _context.packages.ToList().Find(p => p.Id == package.Id);
            if (d == null)
            {
                _context.packages.Add(d);

            }
            return d;
        }
        public Packages UpdatePackages(int code, Packages package)
        {
            var p = _context.packages.ToList().Find(pac => pac.Id == package.Id);
            if (p != null)
            {
                p.DeliverID = package.DeliverID;
                p.RecipientID = package.RecipientID;
                p.Description = package.Description;
                p.Status = package.Status;
            }
            return p;
        }

        public void DeletePackage(int code)
        {
            var p = _context.packages.ToList().Find(p => p.Id == code);
            if (p != null)
            {
                _context.packages.Remove(p);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
