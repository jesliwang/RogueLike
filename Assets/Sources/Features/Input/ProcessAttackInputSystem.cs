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
            var playerViewController = (PlayerViewController)e.view.controller;
            ((InterfaceAttack)e.view.controller).AttackTrigger();

            float dot = Vector2.Dot(new Vector2(1,0), playerViewController.GetDirection());
            Debug.LogError("e=" + playerViewController.GetDirection() + "," + dot);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
            Vector3 rot = Quaternion.AngleAxis(angle, new Vector3(1,0,0)).eulerAngles;
            Debug.LogError("e=" + playerViewController.GetDirection() + "," + dot + "," + angle + "," + rot);
            _pools.blueprints.blueprints.instance.ApplyBullet(_pools.blueprints.blueprints.instance.playerBullet, _pools.bullets.CreateEntity(), playerViewController.position, Vector2.zero , _bulletsObjectPool, rot);
        }
    }

    Pools _pools;
    public void SetPools(Pools pools)
    {
        _pools = pools;
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.PlayerBullet));
    }

}