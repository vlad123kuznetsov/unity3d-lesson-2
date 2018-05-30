using System;
using UnityEngine;

namespace Lesson2.Multitouch
{
    public class ScaleGesture : MonoBehaviour, IScaleGesture
    {
        [SerializeField] private float maxZoomFactor;

        private bool _started;

        public event Action OnStart = delegate { };
        public event Action OnFinished = delegate { };

        private Vector2 startRightPosition;
        private Vector2 startLeftPosition;

        private bool started
        {
            get { return _started; }

            set
            {
                if (value == _started) return;

                _started = value;
                if (value)
                {
                    OnStart();
                }
                else
                {
                    OnFinished();
                }
            }
        }


        private void Update()
        {            
            if (UnityEngine.Input.touchCount == 2)
            {
                if (started) return;

                started = true;
                
                startLeftPosition = UnityEngine.Input.touches[0].position;
                startRightPosition = UnityEngine.Input.touches[1].position;
            }
            else if (UnityEngine.Input.touchCount < 2)
            {
                started = false;
            }
        }

        public float ZoomFactor()
        {
            var startDistance = Vector3.Distance(startLeftPosition, startRightPosition);
            var currentDistance = Vector3.Distance(UnityEngine.Input.touches[0].position, UnityEngine.Input.touches[1].position);
            return Mathf.Clamp(currentDistance / startDistance, 0, maxZoomFactor);
        }

    }
}