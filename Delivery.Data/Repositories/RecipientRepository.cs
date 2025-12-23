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
    public class RecipientRepository : IRecipientRespository
    {
        private readonly DataContext _context;

        public RecipientRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Recipients> GetRecipients()
        {
            return _context.recipients.Include(r=>r.Packages);

        }
        public Recipients GetRecipientByID(int id)
        {
            return _context.recipients.FirstOrDefault(x => x.Id == id);

        }
        public Recipients AddRecipient(Recipients recipient)
        {
            var r = _context.recipients.FirstOrDefault(p => p.Id == recipient.Id);
            if (r == null)
            {
                _context.recipients.Add(recipient);

            }
            return r;
        }
        public Recipients UpdateRecipient(int id, Recipients recipient)
        {
            var r = _context.recipients.FirstOrDefault(pac => pac.Id == recipient.Id);
            if (r != null)
            {
                r.Email = recipient.Email;
                r.Name = recipient.Name;
                r.Address = recipient.Address;
                r.PhoneNumber = recipient.PhoneNumber;
            }
            return r;
        }
        public void DeleteRecipient(int id)
        {
            var d = _context.recipients.FirstOrDefault(p => p.Id == id);
            if (d != null)
            {
                _context.recipients.Remove(d);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
