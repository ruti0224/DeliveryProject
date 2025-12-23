using Delivery.Core.Services;
using Delivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Services
{
    public interface IPackageService
    {
        public IEnumerable<Packages> GetPackages();
        public Packages GetPackageByID(int code);

        public Packages AddPackage(Packages package);
        public Packages UpdatePackages(int code, Packages package);
        public void DeletePackage(int code);
    }
}
