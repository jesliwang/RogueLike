using System;
using UnityEngine;

public interface IMonsterController : IViewController
{
    void Attack();
}

public class MonsterViewController : AnimatorViewController, IMonsterController, InterfaceHit
{
    public void Attack()
    {
        
    }

    public void Hit()
    {
        _animator.SetTrigger("hit");
    }
}
