using System;

namespace Mono.Detectors
{
    public interface IGroundDetector
    {
        bool IsGrounded { get; }

        public event Action<bool> Changed;
    }
}