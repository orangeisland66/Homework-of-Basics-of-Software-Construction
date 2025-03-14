using System;
using System.Threading;

public class AlarmClock
{
    public delegate void TickEventHandler(object sender, EventArgs e);
    public event TickEventHandler Tick;

    public delegate void AlarmEventHandler(object sender, EventArgs e);
    public event AlarmEventHandler Alarm;

    private int alarmTime;
    private int currentTime;

    public AlarmClock(int alarmTime)
    {
        this.alarmTime = alarmTime;
        this.currentTime = 0;
    }

    public void Start()
    {
        while (true)
        {
            OnTick();

            if (currentTime == alarmTime)
            {
                OnAlarm();
                break;
            }

            Thread.Sleep(1000);
            currentTime++;
        }
    }

    protected virtual void OnTick()
    {
        Tick?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnAlarm()
    {
        Alarm?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main()
    {
        AlarmClock clock = new AlarmClock(5);

        clock.Tick += (sender, e) =>
        {
            Console.WriteLine("嘀嗒...");
        };

        clock.Alarm += (sender, e) =>
        {
            Console.WriteLine("响铃！时间到了！");
        };

        clock.Start();
    }
}