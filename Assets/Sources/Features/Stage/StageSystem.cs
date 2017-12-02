using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Entitas;
using System.Collections.Generic;

public class StageSystem : IReactiveSystem, IInitializeSystem, ITearDownSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return CoreMatcher.Stage.OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        if(entities.Count != 1){
            Pools.sharedInstance.core.CreateEntity().AddLog(LogType.Error, "[StageSystem] found more than one stage");
            return;
        }

        var stageEntity = entities[0];
        switch(stageEntity.stage.StageId)
        {
            case 1:
                SceneManager.LoadSceneAsync("Resources/Stages/Stage1", LoadSceneMode.Additive);
                break;
            case 2:
                SceneManager.LoadSceneAsync("Resources/Stages/Stage2", LoadSceneMode.Additive);
                break;
            default:
                break;
        }

    }

    public void Initialize()
    {
        SceneManager.sceneLoaded += SceneLoaded;

        Pools.sharedInstance.core.CreateEntity().AddStage(1);
    }

    protected string preStage;
    protected void SceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if(null != preStage && !preStage.Equals(scene.name)){
            SceneManager.UnloadSceneAsync(preStage );
        }
        preStage = scene.name;
    }

    public void TearDown()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
}
