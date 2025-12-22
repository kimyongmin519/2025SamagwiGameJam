using Member.SYW._01_Scripts.Manager;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public void TimeStop()
    {
        Time.timeScale = 0;
    }
}
