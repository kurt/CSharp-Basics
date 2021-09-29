using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTimer
{
 
    public class OutsideTime
    {
        public static void SendTheTime()
        {
            int i = 0;

            while (i < 7)
            {
                Console.WriteLine("Send the time!!");
                Thread.Sleep(2000);
                i++;
            }
        }

    }
    class PeriodicTimer
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            Thread sendTimeThread = new Thread(OutsideTime.SendTheTime);
            sendTimeThread.Start();
            SetTimer();

            int i = 0;
            while (i <= 15)
            {
                Console.WriteLine("The main loop doing its thing");
                Thread.Sleep(1000);
                i++;
            }
            aTimer.Stop();
            aTimer.Dispose();
            sendTimeThread.Join(1000);
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(2000); //set the timer to 2 seconds 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true; 
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Check The Time");
        }
    }
}
