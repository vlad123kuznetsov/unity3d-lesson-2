using System;

namespace Lesson2.Multitouch
{
    public interface IScaleGesture
    {
        float ZoomFactor();
        event Action OnStart;
        event Action OnFinished;
    }
}