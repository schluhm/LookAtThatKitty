using UnityEngine;

namespace AudioVisualization
{
    public class AudioSpectrum : MonoBehaviour
    {
        private float[] _audioSpectrum;
    
        public static float SpectrumValue { get; private set; }
        private void Start()
        {
            _audioSpectrum = new float[128];
        }
        private void Update()
        {
            AudioListener.GetSpectrumData(_audioSpectrum, 0, FFTWindow.Hamming);

            if (_audioSpectrum != null && _audioSpectrum.Length > 0)
            {
                SpectrumValue = _audioSpectrum[0] * 100;
            }
        }
    }
}
