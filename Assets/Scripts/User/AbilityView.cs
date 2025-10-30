using System.Collections;
using TMPro;
using UnityEngine;

namespace Mono.User
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private GameObject _view;
        
        public void Show(float actionTime, float cooldown, float radius)
        {
            StartCoroutine(ShowCircleCoroutine(actionTime, radius));
            StartCoroutine(ShowTextCoroutine(actionTime + cooldown));
        }

        private IEnumerator ShowCircleCoroutine(float time, float radius)
        {
            _view.SetActive(true);
            _view.transform.localScale = Vector3.one * radius;
            yield return new WaitForSeconds(time);
            _view.SetActive(false);
        }
        
        private IEnumerator ShowTextCoroutine(float time)
        {
            float leftTime = 0;

            while (leftTime < time)
            {
                leftTime += Time.deltaTime;
                _text.text = $"{time - leftTime:F2}s";
                yield return null;
            }
        }
    }
}