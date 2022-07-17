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
    public enum EnemyStates
    {
        None,
        Idle,
        Walk,
        Attack,
        Defense,
        CastSpell,
        Teleport,
        Die
    }

    public enum PlayerType
    {
        None,
        Light,
        Heavy
    }
    public enum EnemyType
    {
        None,
        Skeleton,
        HellHound,
        BringerOfDeath
    }
}