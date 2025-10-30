using UnityEngine;

namespace Mono.User
{
    public class UserInput
    {
        public float Horizontal =>
            Input.GetAxisRaw(nameof(Horizontal));

        public bool IsJump =>
            Input.GetKeyDown(KeyCode.Space);
        
        public bool IsCast =>
            Input.GetKeyDown(KeyCode.E);
    }
}