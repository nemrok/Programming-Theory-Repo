using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemy : Enemy
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private int damage;

    public override int GetSpeed()
    {
        return speed;
    }

    public override int GetDamage()
    {
        return damage;
    }
}
