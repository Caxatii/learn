using UnityEngine;

namespace Mono.Interactions
{
    public abstract class Effector : MonoBehaviour
    {
        public abstract void ApplyEffect(GameObject target);
    }
}