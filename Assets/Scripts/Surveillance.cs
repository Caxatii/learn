using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Surveillance : MonoBehaviour
{
    private bool _isTriggered;

    public event Action Triggered;
    public event Action Shutdowned;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isTriggered == false && collision.TryGetComponent(out Rogue rogue))
        {
            _isTriggered = true;
            Triggered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isTriggered && collision.TryGetComponent(out Rogue rogue))
        {
            _isTriggered = false;
            Shutdowned?.Invoke();
        }
    }
}
