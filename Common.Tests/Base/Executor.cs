using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Tests.Base {
    public static class Executor {
        static TimeSpan defaultTimeout = TimeSpan.FromSeconds(30);
        static TimeSpan defaultInterval = TimeSpan.FromMilliseconds(200);
        public static bool SpinWait(Func<bool> test, TimeSpan? timeout = null, TimeSpan? interval = null) {
            SpinWait spin = new SpinWait();
            DateTime startTime = DateTime.Now;
            while (true) {
                if (test.Invoke()) {
                    return true;
                } else {
                    if (DateTime.Now - startTime > (timeout ?? defaultTimeout)) {
                        return false;
                    }
                    Thread.Sleep(interval ?? defaultInterval);
                }
                spin.SpinOnce();
            }
        }
    }
}
