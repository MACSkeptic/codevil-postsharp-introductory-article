using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codevil.MACSkeptic.PostSharpExample.Entities;

namespace Codevil.MACSkeptic.PostSharpExample.Services
{
    public class TransactionService
    {
        public static void TransferMoney(Account from, Account to, decimal howMuch)
        {
            from.Withdraw(howMuch);
            to.Deposit(howMuch);
        }
    }
}
