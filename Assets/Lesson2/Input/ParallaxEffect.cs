using UnityEngine;
using UnityEngine.UI;

namespace Lesson2.Input
{
    public class ParallaxEffect : MonoBehaviour
    {
        [SerializeField] private Image imageToParallax;
        [SerializeField] private Vector2 maxTranslation;
        [SerializeField] private Vector2 maxRotation;
	
        private Vector3 startTranslation;
        private Quaternion? startRotation;

        private void Awake()
        {
            startTranslation = imageToParallax.transform.position;
        }

        private void Update()
        {
            if (UnityEngine.Input.gyro.enabled)
            {
                if (startRotation == null)
                {
                    startRotation = UnityEngine.Input.gyro.attitude;
                }

                //get rotation from start rotation to current
                var rotation = startRotation * Quaternion.Inverse(UnityEngine.Input.gyro.attitude);
                ConvertRotationToTranslation(rotation.Value.eulerAngles);
            }
        }

        private void ConvertRotationToTranslation(Vector3 rotationEulers)
        {
            var translationCof = -Mathf.Clamp(-1f, 1f, rotationEulers.x / maxRotation.x);
            var translationYCof = -Mathf.Clamp(-1f, 1f, rotationEulers.y / maxRotation.y);

            imageToParallax.transform.position = startTranslation +
                                                 new Vector3(maxTranslation.x * translationCof,
                                                     maxTranslation.y * translationYCof);
        }
    }
}