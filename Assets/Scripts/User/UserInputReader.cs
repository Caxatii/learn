using System;
using UnityEngine;

namespace Mono.User
{
    public class UserInputReader : MonoBehaviour
    {
        private float _horizontal;
        private bool _isJump;
        
        private UserInput _userInput = new();

        private void Update()
        {
            _horizontal = _userInput.Horizontal;

            if (_userInput.IsJump) 
                _isJump = true;
        }
        
        public float GetHorizontal() => 
            _horizontal;

        public bool GetIsJump()
        {
            if(_isJump == false)
                return _isJump;
            
            _isJump = false;
            return true;
        }
    }
}