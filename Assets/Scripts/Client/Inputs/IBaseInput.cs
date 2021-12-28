using System;

namespace FlamyHail.Client.Inputs
{
    public interface IBaseInput
    {
        event Action<MouseInput> OnMouseButtonDown;
    }
}
