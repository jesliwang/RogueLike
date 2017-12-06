using UnityEngine;
using System.Collections;
using Entitas;

public class AISystem : ISetPool, IExecuteSystem
{
    Group aiObjects;
    
    public void Execute()
    {
        foreach(var e in aiObjects.GetEntities())
        {
            if(e.hasAIIdle && e.aIIdle.ticks > 0){
                e.ReplaceAIIdle(e.aIIdle.ticks-1);
            }
            else{
                var ctrl = (InterfaceAI)e.view.controller;
                if (null != ctrl)
                {
                    ctrl.Attack();
                }
                e.ReplaceAIIdle(60*10);
            }

        }
    }

    public void SetPool(Pool pool)
    {
        aiObjects = pool.GetGroup(Matcher.AllOf( CoreMatcher.AI, CoreMatcher.View));
    }
}
