using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;
using Codevil.MACSkeptic.PostSharpExample.Entities;

namespace Codevil.MACSkeptic.PostSharpExample.Aspects
{
    [Serializable]
    public class LogAccountStatusBeforeAndAfterTransaction : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            Account account = (Account)eventArgs.Instance;
            Console.WriteLine(string.Format(
                "New {2} transaction on account {0}. Balance before operation is ${1}.",
                account.Number,
                account.CurrentBalance,
                eventArgs.Method.Name));
        }
        public override void OnExit(MethodExecutionEventArgs eventArgs)
        {
            Account account = (Account)eventArgs.Instance;
            Console.WriteLine(string.Format(
               "Finished {2} transaction on account {0}. Balance after the operation is ${1}.",
               account.Number,
               account.CurrentBalance,
               eventArgs.Method.Name));
        }
    }
}
