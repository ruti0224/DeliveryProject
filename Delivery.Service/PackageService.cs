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
    public class PackageService: IPackageService
    {
        private readonly IPackagesRespository _packageRepo;

        public PackageService(IPackagesRespository packageRepo)
        {
            _packageRepo = packageRepo;
        }
        public IEnumerable<Packages> GetPackages()
        {
            return _packageRepo.GetPackages();
        }
        public Packages GetPackageByID(int code)
        {
            return _packageRepo.GetPackageByID(code);
        }
        public Packages AddPackage(Packages package)
        {
           var p= _packageRepo.AddPackage(package);
            _packageRepo.Save();
            return p;

        }
        public Packages UpdatePackages(int id, Packages package)
        {
           var p= _packageRepo.UpdatePackages(id, package);
            _packageRepo.Save();
            return p;
        }
        public void DeletePackage(int code)
        {
            _packageRepo.DeletePackage(code);
            _packageRepo.Save();

        }
    }
}
