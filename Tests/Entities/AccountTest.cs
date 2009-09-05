using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codevil.MACSkeptic.PostSharpExample.Entities;
using Codevil.MACSkeptic.PostSharpExample.Tests.Builders;

namespace Codevil.MACSkeptic.PostSharpExample.Tests.Entities
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void ConstructorShouldInitializeNumber()
        {
            Account account1 = new Account(555, "Owner", 0);
            Assert.AreEqual(555, account1.Number);

            Account account2 = new Account(666, "Owner", 0);
            Assert.AreEqual(666, account2.Number);
        }

        [TestMethod]
        public void ConstructorShouldInitializeOwner()
        {
            Account account1 = new Account(555, "Owner1", 0);
            Assert.AreEqual("Owner1", account1.Owner);

            Account account2 = new Account(666, "Owner2", 0);
            Assert.AreEqual("Owner2", account2.Owner);
        }

        [TestMethod]
        public void ConstructorShouldInitializeBalance()
        {
            Account account1 = new Account(555, "Owner", -10);
            Assert.AreEqual(-10, account1.CurrentBalance);

            Account account2 = new Account(666, "Owner", 20);
            Assert.AreEqual(20, account2.CurrentBalance);

            Account account3 = new Account(666, "Owner", 0);
            Assert.AreEqual(0, account3.CurrentBalance);
        }

        [TestMethod]
        public void ConstructorShouldLeaveBalanceAtZero()
        {
            Account account = new Account(666, "Owner");
            Assert.AreEqual(0, account.CurrentBalance);
        }

        [TestMethod]
        public void WithdrawShouldDecreaseBalance()
        {
            Account account1 = AccountBuilder.New
                .BelongingTo("MACSkeptic")
                .WithInitialBalance(200.95M)
                .IdentifiedBy(773)
                .Instance;

            Assert.AreEqual(100.95M, account1.Withdraw(100).CurrentBalance);
            Assert.AreEqual(0.0M, account1.Withdraw(100.95M).CurrentBalance);
            Assert.AreEqual(-10.0M, account1.Withdraw(10.00M).CurrentBalance);
        }

        [TestMethod]
        public void DepositShouldIncreaseBalance()
        {
            Account account1 = AccountBuilder.New
                .BelongingTo("MACSkeptic")
                .WithInitialBalance(-50.42M)
                .IdentifiedBy(666)
                .Instance;

            Assert.AreEqual(-0.42M, account1.Deposit(50).CurrentBalance);
            Assert.AreEqual(79.58M, account1.Deposit(80).CurrentBalance);
        }
    }
}
