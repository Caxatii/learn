using System;
using UnityEngine;

namespace Mono.User
{
    [RequireComponent(typeof(UserInputReader))]
    public class AbilityCaster : MonoBehaviour
    {
        [SerializeField] private UserInputReader _inputReader;
        [SerializeField] private Ability _ability;

        private void Awake()
        {
            _inputReader ??= GetComponent<UserInputReader>();
        }

        private void Update()
        {
            if(_inputReader.GetIsCast())
                _ability.Cast();
        }
    }
}