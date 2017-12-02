using Entitas;
using UnityEngine;

public sealed class VelocitySystem : ISetPools, IExecuteSystem {

    Group[] _movableGroups;

    public void SetPools(Pools pools) {
        var matcher = Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.View);
        _movableGroups = new [] {
            pools.core.GetGroup(matcher),
            pools.bullets.GetGroup(matcher)
        };
    }

    public void Execute() {
        foreach(var group in _movableGroups) {
            foreach(var e in group.GetEntities()) {
                e.view.controller.Velocity(e.velocity.value);
            }
        }
    }
}
