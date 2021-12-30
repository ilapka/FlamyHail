using System;
using UnityEngine;

namespace FlamyHail.Client.Inputs
{
    public interface IBaseInput
    {
        event Action<Touch> OnTouchBegan;
    }
}
