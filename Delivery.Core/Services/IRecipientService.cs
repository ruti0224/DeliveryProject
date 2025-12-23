using Delivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Core.Services
{
    public interface IRecipientService
    {
        public IEnumerable<Recipients> GetRecipients();
        public Recipients GetRecipientByID(int id);

        public Recipients AddRecipient(Recipients recipient);
        public Recipients UpdateRecipient(int id, Recipients recipient);
        public void DeleteRecipient(int id);
    }
}
