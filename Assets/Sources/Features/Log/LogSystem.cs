using UnityEngine;
using System.Collections.Generic;
using Entitas;
using System;


public sealed class LogSystem : ISetPool, IReactiveSystem, ICleanupSystem
{

    public TriggerOnEvent trigger { get { return CoreMatcher.Log.OnEntityAdded(); } }

    Pool _pool;
    Group _logs;

    void ISetPool.SetPool(Pool pool)
    {
        _pool = pool;
        _logs = pool.GetGroup(CoreMatcher.Log);
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in _logs.GetEntities())
        {
            switch (e.log.type)
            {
                case LogType.Error:
                    Debug.LogError(e.log.logInfo);
                    break;
                case LogType.Log:
                    Debug.Log(e.log.logInfo);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(e.log.logInfo);
                    break;
                default:
                    break;
            }
        }
    }

    public void Cleanup()
    {
        foreach (var e in _logs.GetEntities())
        {
            _pool.DestroyEntity(e);
        }
    }
}


