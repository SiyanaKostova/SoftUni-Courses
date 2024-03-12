using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Exceptions
{
    public class ChainBlockExceptionMessages
    {
        public const string TransactionDuplicated = "Transaction with id: {0} allready added";
        public const string TransactionDoesNotExist = "Transaction with id: {0} does not exist";
        public const string TransactionsWithStatusDoesNotExist = "Transactions with status: {0} does not exist";
    }
}
