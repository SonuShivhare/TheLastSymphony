using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheLastSymphony
{
    public enum AnimationState
    {
        None,
        Idle,
        CombatIdle,
        Run,
        Jump,
        Attack,
        Death,
        Hurt,
        Recover,
        CastSpell
    }

    public enum PlayerType
    {
        None,
        Light,
        Heavy
    }
}