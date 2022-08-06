// Remark: Works only if the project is in URP

using UnityEngine;
using UnityEngine.Rendering;

namespace LoaderObject.Examples
{
    public class PostProcessingManager : LoaderMono<PostProcessingLoaderData, VolumeComponent>
    {
        [SerializeField] private VolumeProfile volume;

        protected override void Awake() => PassData(volume.components);
    }

}