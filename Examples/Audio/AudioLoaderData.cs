using System;
using UnityEngine;

namespace LoaderObject.Examples
{
    [CreateAssetMenu(fileName = "Audio LoaderData", menuName = "Data/Loader Object/Audio")]
    public class AudioLoaderData : LoaderObjectData<MixerChannel, float>
    {
        // Remark: Not the best approach.
        public static event Action<string, float> OnLoadData;
        
        protected override string FileName { get; } = "Audio";
        
        public override void SaveData(MixerChannel channel)
        {
            SetValue(channel.DisplayName, channel.SliderVolume);
        }

        public override void LoadData(MixerChannel channel)
        {
            float sliderVolume = GetValue(channel.DisplayName, 1f);

            OnLoadData?.Invoke(channel.DisplayName, sliderVolume);
            channel.SetVolume(sliderVolume);
        }
    }
}


