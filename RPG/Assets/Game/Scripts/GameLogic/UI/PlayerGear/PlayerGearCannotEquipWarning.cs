using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameLogic.UI
{
    public class PlayerGearCannotEquipWarning : MonoBehaviour
    {
        [SerializeField] private GameObject content;
        private Coroutine _coroutine;

        public void Show()
        {
            StartAnimation();
        }

        private void StartAnimation()
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(Animation());
        }

        private void StopAnimation()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            content.SetActive(false);
        }

        private IEnumerator Animation()
        {
            content.SetActive(true);

            float timer = 0;
            var scale = content.transform.localScale;

            while (timer < 1)
            {
                scale.x = EasingFunction.EaseInCirc(0.25f, 1.2f, timer);
                scale.y = EasingFunction.EaseInCirc(0.25f, 1.2f, timer);
                content.transform.localScale = scale;
                timer += Time.deltaTime * 3;
                yield return null;
            }

            yield return new WaitForSeconds(0.05f);

            scale.x = 1;
            scale.y = 1;
            content.transform.localScale = scale;

            yield return new WaitForSeconds(1.2f);

            StopAnimation();
        }

        private void OnDisable()
        {
            StopAnimation();
        }

        private void OnDestroy()
        {
            StopAnimation();
        }
    }
}