// Remark: Works only if the project is in URP

using UnityEngine;
using UnityEngine.Rendering;

namespace LoaderObject.Examples
{
    [CreateAssetMenu(fileName = "PostProcessing LoaderData", menuName = "Data/Loader Object/Post-Processing")]
    public class PostProcessingLoaderData : LoaderObjectData<VolumeComponent, bool>
    {
        protected override string FileName { get; } = "PostProcessing";

        public override void SaveData(VolumeComponent component)
        {
            SetValue(component.name, component.active);
        }

        public override void LoadData(VolumeComponent component)
        {
            bool isEnabled = GetValue(component.name, true);
            component.active = isEnabled;
        }
    }
}