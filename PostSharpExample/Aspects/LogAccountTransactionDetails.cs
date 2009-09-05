using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;
using Codevil.MACSkeptic.PostSharpExample.Entities;

namespace Codevil.MACSkeptic.PostSharpExample.Aspects
{
    [Serializable]
    public class LogAccountTransactionDetails : OnMethodInvocationAspect
    {
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            Account account = (Account)eventArgs.Instance;

            LogTransactionStarting(eventArgs, account);
            LogTransactionDetails(eventArgs, account);
            eventArgs.Proceed();
            LogTransactionFinished(eventArgs, account);
        }
        private static void LogTransactionDetails(MethodInvocationEventArgs eventArgs, Account account)
        {
            Console.WriteLine(string.Format(
                "{2} ${0} on account {1}.",
                eventArgs.GetArgumentArray().First(),
                account.Number,
                eventArgs.Method.Name));
        }
        private static void LogTransactionStarting(MethodInvocationEventArgs eventArgs, Account account)
        {
            Console.WriteLine(string.Format(
                "New {2} transaction on account {0}. Balance before operation is ${1}.",
                account.Number,
                account.CurrentBalance,
                eventArgs.Method.Name));
        }
        private static void LogTransactionFinished(MethodInvocationEventArgs eventArgs, Account account)
        {
            Console.WriteLine(string.Format(
               "Finished {2} transaction on account {0}. Balance after the operation is ${1}.",
               account.Number,
               account.CurrentBalance,
               eventArgs.Method.Name));
        }
    }
}
