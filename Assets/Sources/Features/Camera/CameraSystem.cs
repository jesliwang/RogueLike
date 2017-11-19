using System;
using System.Collections.Generic;
using Entitas;

public class CameraSystem : ReactiveSystem<PoolEntity>, IInitializeSystem
{
	readonly PoolContext pool;

	public CameraSystem(Contexts contexts)
        : base(contexts.pool)
    {
		pool = contexts.pool;
	}

    public void Initialize()
    {
    }

    protected override void Execute(List<PoolEntity> entities)
    {
        if (!pool.isControllable)
		{
			// ignore input
			return;
		}

        var controllable = pool.controllableEntity;
        var camera = pool.cameraEntity;
        camera.ReplacePosition(controllable.position.x, controllable.position.y);
    }

    protected override bool Filter(PoolEntity entity)
    {
        return true;
    }

    protected override ICollector<PoolEntity> GetTrigger(IContext<PoolEntity> context)
    {
        return context.CreateCollector(PoolMatcher.Controllable);
    }
}
