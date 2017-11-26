using UnityEngine;
using System.Collections;
using Entitas;
using System;

public sealed class LogSystem :ISetPools, IExecuteSystem
{
	Group _coolDowns;

	public void SetPools(Pools pools)
	{
        _coolDowns = pools.core.GetGroup(CoreMatcher.Log);
	}

	public void Execute()
    {
		foreach (var e in _coolDowns.GetEntities())
		{
            switch(e.log.type)
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


}
