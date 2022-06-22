using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D), typeof(BonusSound))]
public sealed class BulletBonus : Bonus
{
    public static event Action OnGot;
    protected override void Apply()
    {
        OnGot.Invoke();
    }
}