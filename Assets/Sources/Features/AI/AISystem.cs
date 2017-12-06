using UnityEngine;
using System.Collections;
using Entitas;

public class AISystem : ISetPools, IExecuteSystem
{
    ObjectPool<GameObject> _bulletsObjectPool;
    Group aiObjects;
    
    public void Execute()
    {
        foreach(var e in aiObjects.GetEntities())
        {
            if(e.hasAIIdle && e.aIIdle.ticks > 0){
                e.ReplaceAIIdle(e.aIIdle.ticks-1);
            }
            else{
                var ctrl = (InterfaceAI)e.view.controller;
                if (null != ctrl)
                {
                    ctrl.Attack();
                    _pools.blueprints.blueprints.instance.ApplyBullet(_pools.blueprints.blueprints.instance.enemyBullet, _pools.bullets.CreateEntity(), e.view.controller.position, new Vector2(-0.05f, 0) , _bulletsObjectPool, Vector3.zero);

                }
                e.ReplaceAIIdle(60*10);
            }

        }
    }

    Pools _pools;
    public void SetPools(Pools pools)
    {
        _pools = pools;
        aiObjects = pools.core.GetGroup(Matcher.AllOf( CoreMatcher.AI, CoreMatcher.View));

        _bulletsObjectPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.EnemyBullet));
    }
}
