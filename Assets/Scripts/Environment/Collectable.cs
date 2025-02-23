using System;
using UnityEngine;

namespace Mono.Environment
{
    public abstract class Collectable : MonoBehaviour
    {
        public abstract event Action<Collectable> Collected;
    }
}