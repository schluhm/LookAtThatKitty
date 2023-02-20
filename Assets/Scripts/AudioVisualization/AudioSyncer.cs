using UnityEngine;

namespace AudioVisualization
{
    public class AudioSyncer : MonoBehaviour
    {
        public float bias;
        public float timeStep;
        public float timeToBeat;
        public float restSmoothTime;
        private float _previousAudioValue;
    
        protected float _audioValue;
        private float _timer;
        protected bool _isBeat;

        protected virtual void OnBeat()
        {
            _timer = 0;
            _isBeat = true;
        }

        protected virtual void OnUpdate()
        {
            _previousAudioValue = _audioValue;
            _audioValue = AudioSpectrum.SpectrumValue;
            if (_previousAudioValue > bias && _audioValue <= bias)
            {
                if(_timer > timeStep)
                    OnBeat();
            }

            if (_previousAudioValue <= bias && _audioValue > bias)
            {
                if(_timer > timeStep)
                    OnBeat();
            }

            _timer += Time.deltaTime;
        }

        // Update is called once per frame
        private void Update()
        {
            OnUpdate();   
        }
    }
}