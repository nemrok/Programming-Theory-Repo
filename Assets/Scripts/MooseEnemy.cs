using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE Child moose enemy class
public class MooseEnemy : Enemy
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private int damage;

    // POLYMORPHISM Overridden get speed method
    public override int GetSpeed()
    {
        return speed;
    }

    // POLYMORPHISM Overridden get damage method
    public override int GetDamage()
    {
        return damage;
    }
}
