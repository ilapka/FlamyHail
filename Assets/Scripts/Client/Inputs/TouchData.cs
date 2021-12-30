using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public readonly struct TouchData
    {
        public Vector3 Position { get; }
        public TouchData(Vector3 position)
        {
            Position = position;
        }
    }
}