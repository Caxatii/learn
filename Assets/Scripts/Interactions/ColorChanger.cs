using System.Collections.Generic;
using UnityEngine;

namespace Mono.Interactions
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private Color _defaultColor;

        [SerializeField] private List<SpriteRenderer> _renderers;

        public void Change(Color color)
        {
            foreach (var sprite in _renderers)
            {
                sprite.color = color;
            }
        }

        public void Return()
        {
            foreach (var sprite in _renderers)
            {
                sprite.color = _defaultColor;
            }
        }
    }
}