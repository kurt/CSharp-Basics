using System;
using System.Timers;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTimer
{
 
    public class myClock
    {
        public EventHandler TimeEvent;
        public void SendTime()
        {
            //Console.WriteLine("Inside SendTime");
            TimeEvent.Invoke(this, EventArgs.Empty);//this class and no arguments
        }
    }

    public class OutsideTime
    {

        public static void SendTheTime()
        {
            int i = 0;
            myClock clock = new myClock();
            while (i < 7)
            {
                Console.WriteLine("Send the time!!");
                clock.SendTime();
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

        /*private void threadClockEventHandler(object sender, EventArgs e)
        {
            Button button = new Button();
            button.ClickEvent += (s, args) =>
            {
                Console.WriteLine("A button was pressed");

            };
            Console.WriteLine("When is this?");
            button.OnClick();
        }*/
    }
}
