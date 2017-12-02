using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ChangeStageEmitter : MonoBehaviour {

    public int targetScene;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Pools.sharedInstance.core.CreateEntity().ReplaceStage(targetScene);
        }
    }
}
