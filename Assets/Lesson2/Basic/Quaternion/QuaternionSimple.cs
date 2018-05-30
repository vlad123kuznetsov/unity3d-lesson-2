using UnityEngine;

namespace Lesson2
{
    public class QuaternionSimple : MonoBehaviour
    {
        [SerializeField] private GameObject cube1;

        private void Update()
        {
            Camera.main.transform.LookAt(cube1.transform.position);
        }
    }
}