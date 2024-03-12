using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Exceptions
{
    public static class TransactionExceptionMessages
    {
        public const string IdNotPositiveNumber = "Id should be a positve number";
        public const string SenderNullOrWhiteSpace = "Sender is null or white space";
        public const string ReceiverNullOrWhiteSpace = "Receiver is null or white space";
        public const string AmountNotPositiveNumber = "Amount should be a positve number";
    }
}
