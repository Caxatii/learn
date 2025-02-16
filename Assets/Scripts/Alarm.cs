using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private AudioSource _alarm;
    private Coroutine _coroutine;

    private void Awake()
    {
        _alarm = GetComponent<AudioSource>();
        _alarm.Play();
        _alarm.volume = _minVolume;
    }

    public void Activate()
    {
        _coroutine = SwitchCoroutine(_maxVolume);
    }

    public void Deactivate()
    {
        _coroutine = SwitchCoroutine(_minVolume);
    }

    private Coroutine SwitchCoroutine(float nextVolume)
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        return StartCoroutine(ChangeVolume(nextVolume));
    }

    private IEnumerator ChangeVolume(float nextVolume)
    {
        while (_alarm.volume != nextVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, nextVolume, _step * Time.deltaTime);
            yield return 0;
        }
    }
}
