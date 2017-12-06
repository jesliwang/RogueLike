﻿using Entitas;
using UnityEngine;

public class CollisionEmitter : MonoBehaviour {

    public string targetTag;

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag(targetTag)) {
            var link = gameObject.GetEntityLink();
            var targetLink = collision.gameObject.GetEntityLink();

            Pools.sharedInstance.input.CreateEntity()
                .AddCollision(link.entity, targetLink.entity);
        }
    }
}
