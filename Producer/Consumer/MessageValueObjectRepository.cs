using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    internal class MessageValueObjectRepository
    {
        private MessageDbContext _messageDbContext;

        public MessageValueObjectRepository(MessageDbContext messageDbContext)
        {
            _messageDbContext = messageDbContext;
        }

        public void AddMessage(TestValueObject testValueObject )
        {
            _messageDbContext.Add(testValueObject);
            _messageDbContext.SaveChanges();
        }

        internal void MigrationCheck()
        {
            _messageDbContext.Database.Migrate();
        }
    }
}
