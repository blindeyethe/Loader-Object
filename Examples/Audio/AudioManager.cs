using UnityEngine;
using UnityEngine.Audio;

namespace LoaderObject.Examples
{
    public class AudioManager : LoaderMono<AudioLoaderData, MixerChannel>
    {
        [Header("Settings")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private MixerChannel[] mixerChannels;
        
        protected override void Awake()
        {
            foreach (var channel in mixerChannels)
                channel.SetMixer(audioMixer);
            
            PassData(mixerChannels);
        }
        
        public void SetChannelVolume(int channelIndex, float sliderVolume)
        {
            mixerChannels[channelIndex].SetVolume(sliderVolume);
        }
    }
}