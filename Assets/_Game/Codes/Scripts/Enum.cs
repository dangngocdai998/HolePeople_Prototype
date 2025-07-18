using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolePeople
{
    public enum GameState
    {
        NotReady,
        Ready,
        Playing,
        Win,
        Lose
    }

    public enum TypeEntity
    {
        None,
        Stickman,
        Hole,
        Block,
        Tunnel,
        HiddenStickman,
        FrozenStickman
    }

    public enum ColorType
    {
        None,
        Red,
        Green,
        Yellow
    }

}
