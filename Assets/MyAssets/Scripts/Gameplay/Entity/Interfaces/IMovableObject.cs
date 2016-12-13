using System;

using UnityEngine;

namespace GenShootUnity.Gameplay.Entity
{
    [Flags]
    public enum Directions
    {
        UP = 0x1,
        RIGHT = 0x2,
        DOWN = 0x4,
        LEFT = 0x8
    }

    interface IMovableObject
    {
        float Speed { get; set; }

        void Move(Directions dir, float deltaT);
        void StepMove(float deltaT);
    }
}
