using System;
using System.Collections.Generic;
using Entitas;

public class ChopSystem : ReactiveSystem<PoolEntity>
{
    readonly PoolContext context;

    public ChopSystem(Contexts contexts):base(contexts.pool)
    {
        context = contexts.pool;
    }

    protected override void Execute(List<PoolEntity> entities)
    {
        foreach(var e in entities)
        {
            if(e.hasView)
            {
                e.AddAnimation(Animation.playerChop);
            }
            e.isAttack = false;
        }
    }

    protected override bool Filter(PoolEntity entity)
    {
        return entity.isAttack && entity.isChop;
    }

    protected override ICollector<PoolEntity> GetTrigger(IContext<PoolEntity> context)
    {
		return new Collector<PoolEntity>(
			new[]
			{ context.GetGroup(Matcher<PoolEntity>.AllOf(
						PoolMatcher.Attack,
						PoolMatcher.Chop))
			},
			new[] { GroupEvent.Added }
		);
    }

   
}
