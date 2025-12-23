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
    public class RecipientService: IRecipientService
    {
        private readonly IRecipientRespository _recipientRepo;
        public RecipientService(IRecipientRespository recipientRepo)
        {
            _recipientRepo = recipientRepo;
        }
        public IEnumerable<Recipients> GetRecipients()
        {
            return _recipientRepo.GetRecipients();
        }
        public Recipients GetRecipientByID(int id)
        {
            return _recipientRepo.GetRecipientByID(id);
        }
        public Recipients AddRecipient(Recipients recipient)
        {
           var r= _recipientRepo.AddRecipient(recipient);
            _recipientRepo.Save();
            return r;
        }
        public Recipients UpdateRecipient(int id, Recipients recipient)
        {
            var r = _recipientRepo.UpdateRecipient(id, recipient);
            _recipientRepo.Save();
            return r;

        }
        public void DeleteRecipient(int id)
        {
            _recipientRepo.DeleteRecipient(id);
            _recipientRepo.Save();

        }
    }
}
