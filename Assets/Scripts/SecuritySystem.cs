using UnityEngine;

public class SecuritySystem : MonoBehaviour
{
    [SerializeField] private Surveillance _surveillance;
    [SerializeField] private Alarm _alarm;

    private void Awake()
    {
        _surveillance.Triggered += ActivateAlarm;
        _surveillance.Shutdowned += ShutdownAlarm;
    }

    private void ShutdownAlarm()
    {
        _alarm.Deactivate();
    }

    private void ActivateAlarm()
    {
        _alarm.Activate();
    }
}
