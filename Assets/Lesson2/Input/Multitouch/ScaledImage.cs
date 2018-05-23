using UnityEngine;
using UnityEngine.UI;

namespace Lesson2.Multitouch
{
    public class ScaledImage : MonoBehaviour
    {
        [SerializeField] private Image img;
    
        private IScaleGesture gesture;

        private void Awake()
        {
            var go = new GameObject();
            go.name = "Scale gesture";
            gesture = go.AddComponent<ScaleGesture>();
        }
    
        private void Update()
        {
            img.transform.localScale = Vector3.one * gesture.ZoomFactor();
        }
    
    }
}