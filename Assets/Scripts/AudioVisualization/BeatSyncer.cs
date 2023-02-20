using System.Collections;
using UnityEngine;

namespace AudioVisualization
{
    public class BeatSyncer : AudioSyncer
    {
        private IEnumerator MoveToScale(Vector3 target)
        {
            var curr = transform.localScale;
            var init = curr;
            float timer = 0;

            while (curr != target)
            {
                curr = Vector3.Lerp(init, target, timer / timeToBeat);
                timer += Time.deltaTime;

                transform.localScale = curr;

                yield return null;
            }

            _isBeat = false;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (_isBeat) return;

            //Reset Scale
            transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
        }

        protected override void OnBeat()
        {
            base.OnBeat();

            StopCoroutine("MoveToScale");
            StartCoroutine("MoveToScale", beatScale);
        }
    
        public float lastHeight;
        public Vector3 beatScale;
        public Vector3 restScale;
    }
}