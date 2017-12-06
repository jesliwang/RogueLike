using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity.Serialization.Blueprints;
using UnityEngine;

public class ProcessAttackInputSystem : ISetPools, IReactiveSystem
{
    ObjectPool<GameObject> _bulletsObjectPool;

    public TriggerOnEvent trigger
    {
        get
        {
            return InputMatcher.AttackInput.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {

		var input = entities[entities.Count - 1];
		var ownerId = input.inputOwner.playerId;

		var e = _pools.core.GetEntityWithPlayerId(ownerId);
        if(!e.isInAttack){
            e.isInAttack = true;
            var playerViewController = (IPlayerController)e.view.controller;
            playerViewController.AttackTrigger();
          
            _pools.blueprints.blueprints.instance.ApplyBullet(_pools.blueprints.blueprints.instance.playerBullet, _pools.bullets.CreateEntity(), playerViewController.position, Vector2.zero , _bulletsObjectPool, Vector3.zero);
        }
    }

    Pools _pools;
    public void SetPools(Pools pools)
    {
        _pools = pools;
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.PlayerBullet));
    }

}