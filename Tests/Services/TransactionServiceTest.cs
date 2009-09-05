using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codevil.MACSkeptic.PostSharpExample.Entities;
using Codevil.MACSkeptic.PostSharpExample.Tests.Builders;
using Codevil.MACSkeptic.PostSharpExample.Services;

namespace Codevil.MACSkeptic.PostSharpExample.Tests.Services
{
    [TestClass]
    public class TransactionServiceTest
    {
        [TestMethod]
        public void TransferShouldWithdrawFromAnAccountAndDepositTheMoneyOnTheOther()
        {
            Account from = AccountBuilder.New.WithInitialBalance(100).Instance;
            Account to = AccountBuilder.New.WithInitialBalance(-50).Instance;

            TransactionService.TransferMoney(from, to, 60);

            Assert.AreEqual(40, from.CurrentBalance);
            Assert.AreEqual(10, to.CurrentBalance);
        }
    }
}
