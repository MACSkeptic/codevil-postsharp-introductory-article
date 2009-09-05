using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codevil.MACSkeptic.PostSharpExample.Entities;

namespace Codevil.MACSkeptic.PostSharpExample.Tests.Builders
{
    public class AccountBuilder
    {
        public static AccountBuilder New { get { return new AccountBuilder(); } }
        public Account Instance { get { return this.instance; } }
        private Account instance;
        
        public AccountBuilder()
        {
            this.instance = new Account(0, string.Empty);
            this.Defaults();
        }

        private void Defaults()
        {
            this.instance.Number = new Random(DateTime.Now.Millisecond).Next(100000, 999999);
            this.instance.Owner = "Default Owner";
        }

        public AccountBuilder WithInitialBalance(decimal howMuch)
        {
            this.instance.Deposit(howMuch);
            return this;
        }

        public AccountBuilder IdentifiedBy(long number)
        {
            this.instance.Number = number;
            return this;
        }

        public AccountBuilder BelongingTo(string owner)
        {
            this.instance.Owner = owner;
            return this;
        }
    }
}
