using UnityEngine;

namespace Mono.User
{
    public class UserInputReader
    {
        public float Horizontal => 
            Input.GetAxis(nameof(Horizontal));

        public bool IsJumped =>
            Input.GetKeyDown(KeyCode.Space);
    }
}
