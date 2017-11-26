using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class InAttackSystem : ISetPools, IEntityCollectorSystem
{
    public EntityCollector entityCollector
    {
        get
        {
            return _groupObserver;
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            var playerViewController = (IPlayerController)e.view.controller;
            if(!playerViewController.InAttackState())
            {
                e.isInAttack = false;
            }
        }
    }

	EntityCollector _groupObserver;

	public void SetPools(Pools pools)
	{
        _groupObserver = new[] { pools.core }
            .CreateEntityCollector(CoreMatcher.InAttack);
	}
}
