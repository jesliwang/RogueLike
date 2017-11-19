using System;
using System.Collections.Generic;
// by wangjianhong
using Entitas;

public class ControllerSystem : ReactiveSystem<PoolEntity>
{
    readonly PoolContext context;

    public ControllerSystem(Contexts contexts) : base(contexts.pool)
    {
        context = contexts.pool;
    }

    protected override void Execute(List<PoolEntity> entities)
    {
		foreach (var e in entities)
		{
            var controller = e.controllerList;

            if(controller.Controllers.Contains(Controller.Fire))
            {
                if (!e.isAttack){
                    e.isAttack = true;
                }
                e.RemoveControllerList();
            }
		}
    }

    protected override bool Filter(PoolEntity entity)
    {
        return true;
    }

    protected override ICollector<PoolEntity> GetTrigger(IContext<PoolEntity> context)
    {
        return context.CreateCollector(PoolMatcher.ControllerList);
    }
}
