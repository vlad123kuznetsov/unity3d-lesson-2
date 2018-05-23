using UnityEngine;

namespace Lesson2.Input
{
    public class TestRotate : MonoBehaviour
    {
        [SerializeField] private float horizontalSpeed = 2.0F;
        [SerializeField] private float verticalSpeed = 2.0F;
	
        private void Update() {
            var h = horizontalSpeed * UnityEngine.Input.GetAxis("Mouse X");
            var v = verticalSpeed * UnityEngine.Input.GetAxis("Mouse Y");
            transform.Rotate(v, h, 0);
        }
    }
}