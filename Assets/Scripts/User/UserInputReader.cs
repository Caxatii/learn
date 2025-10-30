using System;
using UnityEngine;

namespace Mono.User
{
    public class UserInputReader : MonoBehaviour
    {
        private float _horizontal;
        private bool _isJump;
        private bool _isCast;
        
        private UserInput _userInput = new();

        private void Update()
        {
            _horizontal = _userInput.Horizontal;
            
            if (_userInput.IsJump) 
                _isJump = true;
            
            if (_userInput.IsCast) 
                _isCast = true;
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
        
        public bool GetIsCast()
        {
            if(_isCast == false)
                return _isJump;
            
            _isCast = false;
            return true;
        }
    }
}