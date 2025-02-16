using UnityEngine;

public class SecuritySystem : MonoBehaviour
{
    [SerializeField] private Surveillance _surveillance;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _surveillance.Triggered += ActivateAlarm;
        _surveillance.Shutdowned += ShutdownAlarm;
    }

    private void OnDisable()
    {
        _surveillance.Triggered -= ActivateAlarm;
        _surveillance.Shutdowned -= ShutdownAlarm;
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
