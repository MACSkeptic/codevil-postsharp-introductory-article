using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codevil.MACSkeptic.PostSharpExample.Aspects;

namespace Codevil.MACSkeptic.PostSharpExample.Entities
{
    [LogAccountTransactionDetails(AttributeTargetMembers = "regex:(Deposit)|(Withdraw)")]
    public class Account
    {
        public long Number { get; set; }
        public string Owner { get; set; }
        public decimal CurrentBalance { get { return this.currentBalance; } }
        private decimal currentBalance;
        private const decimal DefaultInitialBalance = 0;

        public Account(long number, string owner)
            : this(number, owner, DefaultInitialBalance)
        {
        }
        public Account(long number, string owner, decimal initialBalance)
        {
            this.Number = number;
            this.Owner = owner;
            this.currentBalance = initialBalance;
        }

        public Account Deposit(decimal howMuch)
        {
            this.currentBalance += howMuch;
            return this;
        }
        public Account Withdraw(decimal howMuch)
        {
            this.currentBalance -= howMuch;
            return this;
        }
    }
}
