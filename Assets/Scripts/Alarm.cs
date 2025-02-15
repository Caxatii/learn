using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private float _maxVolume;

    private float _nextVolume;

    private AudioSource _alarm;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(_alarm.volume == _nextVolume)
            return;

        if (_alarm.volume == 0 && _alarm.isPlaying)
        {
            _alarm.Stop();
        }
        else if (_nextVolume > 0 && _alarm.isPlaying == false)
        {
            _alarm.Play();
        }

        _alarm.volume = Mathf.MoveTowards(_alarm.volume, _nextVolume, _step * Time.deltaTime);
    }

    public void Activate()
    {
        _nextVolume = _maxVolume;
    }

    public void Deactivate()
    {
        _nextVolume = 0;
    }
}
