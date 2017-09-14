using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Repel
{
    public class FadeLoad : MonoBehaviour
    {
        [SerializeField]
        private Image _FadeOverlay;

        [SerializeField]
        private Color _FadeColor;

        [SerializeField]
        private float _FadeSpeed;


        private float _FadeValue = 0f;


        private void Awake()
        {
            StartFadeIn();
        }

        //Call for a fade-in.
        public void StartFadeIn()
        {
            _FadeOverlay.gameObject.SetActive(true);
            _FadeValue = 1f;
            StartCoroutine(Fade(-1));
        }


        //Call for a fade-out.
        public void StartFadeOut()
        {
            _FadeOverlay.gameObject.SetActive(true);
            _FadeValue = 0f;
            StartCoroutine(Fade(1));
        }


        //The actual fade code.
        IEnumerator Fade(int direction)
        {
            bool fading = true;
            while (fading)
            {
                _FadeValue += direction * _FadeSpeed * Time.deltaTime;
                _FadeOverlay.color = new Color(_FadeColor.r, _FadeColor.g, _FadeColor.b, _FadeValue);

                //Check when to stop the coroutine.
                if ((direction == -1) && (_FadeValue <= 0))
                {
                    _FadeOverlay.gameObject.SetActive(false);
                    fading = false;
                }
                else if ((direction == 1) && (_FadeValue >= 1))
                {
                    direction = -1;
                }

                //I use the WaitForEndOfFrame here so the Fade IEnumerator functions as a second update, which can use the Time.deltatime.
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
