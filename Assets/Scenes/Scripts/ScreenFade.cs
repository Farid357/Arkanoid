using System.Collections;
using UnityEngine;
using UnityEngine.UI;

    public sealed class ScreenFade : MonoBehaviour
    {
        public bool IsDarkened => _isDarkened;
        [SerializeField] private Image _screen;
        private WaitForSeconds _delay;
        private bool _isDarkened;
        private void Start()
        {
            _delay = new WaitForSeconds(0.05f);
        }
        public void StartFade()
        {
            StartCoroutine(Fade());
        }
        public void StartFadeOut()
        {
            StartCoroutine(FadeOut());
        }
        private IEnumerator Fade()
        {
            while (!_isDarkened)
            {
                for (float t = 0.05f; t <= 1; t += 0.05f)
                {
                    SetColor(t);
                    yield return _delay;
                }
                _isDarkened = true;
            }
        }
        private IEnumerator FadeOut()
        {
            while (_isDarkened)
            {
                for (float t = 1; t >= 0; t -= 0.05f)
                {
                    SetColor(t);
                    yield return _delay;
                }
                _isDarkened = false;
            }
        }
        private void SetColor(float t)
        {
            Color color = _screen.color;
            color.a = t;
            _screen.color = color;
        }
    }
