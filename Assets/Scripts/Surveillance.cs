using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Surveillance : MonoBehaviour
{
    private bool _isTriggered;
    private HashSet<Rogue> _rogues = new();

    public event Action Triggered;
    public event Action Shutdowned;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;

        if (collision.TryGetComponent(out Rogue rogue))
        {
            _rogues.Add(rogue);
            Observe();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null)
            return;

        if (collision.TryGetComponent(out Rogue rogue))
        {
            _rogues.Remove(rogue);
            Observe();
        }
    }

    private void Observe()
    {
        if (_rogues.Count > 0 && _isTriggered == false)
        {
            Triggered?.Invoke();
            _isTriggered = true;
        }

        if(_rogues.Count == 0 && _isTriggered)
        {
            Shutdowned?.Invoke();
            _isTriggered = false;
        }
    }
}
