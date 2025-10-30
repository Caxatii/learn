using UnityEngine;
using UnityEngine.UI;

namespace Source.Presentation.HealthView
{
    [RequireComponent(typeof(Slider))]
    public class SliderHealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        private void Awake()
        {
            _slider ??= GetComponent<Slider>();
        }

        public void Render(float currentValue, float maxValue)
        {
            _slider.value = currentValue / maxValue;
        }
    }
}