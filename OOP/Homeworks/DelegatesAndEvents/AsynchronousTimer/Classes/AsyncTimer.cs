using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsynchronousTimer.Classes
{
    class AsyncTimer
    {
        public AsyncTimer(Action<int> actionMethod, int ticks, int t)
        {
            this.ActionMethod = actionMethod;
            this.Ticks = ticks;
            this.T = t;
        }

        public Action<int> ActionMethod { get; set; }
        public int Ticks { get; set; }
        public int T { get; set; }

        public void Run()
        {
            while (this.Ticks > 0)
            {
                Thread.Sleep(this.T);
                if (this.ActionMethod != null)
                {
                    this.ActionMethod(this.Ticks);
                }

                this.Ticks--;
            }
        }
    }
}
