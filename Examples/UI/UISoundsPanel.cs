using UnityEngine;

namespace LoaderObject.Examples
{
    public class UISoundsPanel : MonoBehaviour
    {
        [SerializeField] private AudioManager manager;

        private int _sliderIndex;
        private UISoundSlider[] _sliders;

        private void Awake()
        {
            _sliders = GetComponentsInChildren<UISoundSlider>();
            
            foreach (var slider in _sliders)
                slider.Index = _sliderIndex++;

            _sliderIndex = 0;
        }

        private void OnEnable()
        {
            AudioLoaderData.OnLoadData += ChangeTexts;
            UISoundSlider.OnValueChanged += manager.SetChannelVolume;
        }

        private void OnDisable()
        {
            AudioLoaderData.OnLoadData -= ChangeTexts;
            UISoundSlider.OnValueChanged -= manager.SetChannelVolume;
        }

        private void ChangeTexts(string sliderName, float sliderVolume)
        {
            _sliders[_sliderIndex++].Change(sliderName, sliderVolume);

            if (_sliderIndex == _sliders.Length)
                _sliderIndex = 0;
        }
    }
}