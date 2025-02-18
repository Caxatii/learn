using UnityEngine;

public class UserInput
{
    public float Horizontal => 
        Input.GetAxis(nameof(Horizontal));

    public bool IsJumped =>
        Input.GetKeyDown(KeyCode.Space);
}
