using Entitas.Serialization.Blueprints;
using UnityEngine;

namespace Entitas.Unity.Serialization.Blueprints {

    public partial class Blueprints {

        public Entity ApplyPlayer1(Entity entity, Vector3 position) {
            return entity.ApplyBlueprint(Player1)
                .AddPosition(position);
        }

        public Entity ApplyBullet(Entity entity, Vector2 position, Vector2 velocity, ObjectPool<GameObject> gameObjectPool, Vector3 rotate) {
            return entity.ApplyBlueprint(playerBullet)
                .AddPosition(position)
                .AddVelocity(velocity)
                         .AddRotate(rotate)
                .AddViewObjectPool(gameObjectPool);
        }

        public Entity ApplyEnemy(Entity entity) {
            return entity.ApplyBlueprint(Enemy);
        }

        public Entity ApplyMonster(Entity entity){
            return entity.ApplyBlueprint(monster);
        }
    }
}
