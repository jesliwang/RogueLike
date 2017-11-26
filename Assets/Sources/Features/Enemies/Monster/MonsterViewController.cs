using System;
using UnityEngine;

public interface IMonsterController : IViewController
{
    void Attack();
}

public class MonsterViewController : AnimatorViewController, IMonsterController
{
    public void Attack()
    {
        
    }
}
