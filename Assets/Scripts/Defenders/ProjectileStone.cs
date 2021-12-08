using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStone : Projectile
{
    public override void Repel(Attacker attacker)
    {
        attacker.StartCarutine();
    }
}
