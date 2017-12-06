using System;
using UnityEngine;

public class MonsterViewController : AnimatorViewController, IViewController, InterfaceHit, InterfaceAI
{
    public void Attack()
    {
        _animator.SetTrigger("attack");

    }

    public void Hit()
    {
        _animator.SetTrigger("hit");
    }
}
