using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codevil.MACSkeptic.PostSharpExample.Entities;

namespace Codevil.MACSkeptic.PostSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(123, "MACSkeptic");

            account.Deposit(10);
            account.Withdraw(20);

            Console.ReadKey();
        }
    }
}
