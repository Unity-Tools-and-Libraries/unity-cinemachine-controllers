using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class MoveDirectionExtension
{
    public static MoveDirection Invert(this MoveDirection direction)
    {
        switch(direction)
        {
            case MoveDirection.Left:
                return MoveDirection.Right;
            case MoveDirection.Right:
                return MoveDirection.Left;
            case MoveDirection.Up:
                return MoveDirection.Down;
            case MoveDirection.Down:
                return MoveDirection.Up;
            default:
                return MoveDirection.None;
        }
    }
}
