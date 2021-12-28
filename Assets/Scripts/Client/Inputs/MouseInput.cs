using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public struct MouseInput
    {
        public Vector3 Position { get; }
        public MouseInput(Vector3 position)
        {
            Position = position;
        }
    }
}