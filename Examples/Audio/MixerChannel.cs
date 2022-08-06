using UnityEngine;
using UnityEngine.Audio;

namespace LoaderObject.Examples
{
    [System.Serializable]
    public class MixerChannel
    {
        [SerializeField] private string channelName;
        [SerializeField] private string displayName;

        private AudioMixer _audioMixer;
        
        public string DisplayName => displayName;
        public float SliderVolume { get; private set; }

        internal void SetMixer(AudioMixer audioMixer) => _audioMixer = audioMixer;
        
        public void SetVolume(float sliderVolume)
        {
            SliderVolume = sliderVolume;
            _audioMixer.SetFloat(channelName, GetChannelVolume());

            float GetChannelVolume() => Mathf.Log(sliderVolume) * 20;
        }
    }
}