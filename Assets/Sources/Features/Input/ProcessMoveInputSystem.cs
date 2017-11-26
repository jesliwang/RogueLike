using Entitas;
using System.Collections.Generic;
using System;
using UnityEngine;

public sealed class ProcessMoveInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.MoveInput.OnEntityAdded(); } }


    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Execute(List<Entity> entities) {
        var input = entities[entities.Count - 1];
        var ownerId = input.inputOwner.playerId;

        var e = _pools.core.GetEntityWithPlayerId(ownerId);

        // TODO Speed Shoud be configurable
        e.ReplaceVelocity(input.moveInput.direction.normalized * 0.03f);

        var playerViewController = (IPlayerController)e.view.controller;
        if(!(Mathf.Abs(input.moveInput.direction.x) < 0.1f && Mathf.Abs(input.moveInput.direction.y) < 0.1f)){
			playerViewController.SetPlayerDirection(input.moveInput.direction.x, input.moveInput.direction.y);

		}

        if (Math.Abs(input.moveInput.direction.x) > 0.1f)
        {
            playerViewController.SetPlayerSpeed(0.3f);
        }
        else if(Math.Abs(input.moveInput.direction.y) > 0.1f)
        {
            playerViewController.SetPlayerSpeed(0.3f);
			
        }
        else
        {
            playerViewController.SetPlayerSpeed(0);
        }


    }
}
