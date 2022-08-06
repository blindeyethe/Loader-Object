using System;
using UnityEngine;
using UnityEngine.UI;

namespace LoaderObject.Examples
{
    public class UISoundSlider : MonoBehaviour
    {
        public static event Action<int, float> OnValueChanged;

        [SerializeField] private Slider slider;
        [SerializeField] private Text nameText;
        [SerializeField] private Text volumeText;
        
        public int Index { private get; set; }

        private void Awake() => slider.onValueChanged.AddListener(OnChange);
        
        public void Change(string sliderName, float sliderVolume)
        {
            if(sliderName != null)
                nameText.text = sliderName;

            slider.SetValueWithoutNotify(sliderVolume);
            SetSliderText(sliderVolume);
        }
        
        private void OnChange(float value)
        {
            OnValueChanged?.Invoke(Index, value);
            SetSliderText(value);
        }

        private void SetSliderText(float sliderVolume)
        {
            volumeText.text = GetVolume().ToString();
            
            int GetVolume() => Mathf.FloorToInt(sliderVolume * 100);
        }
    }
}