using Entitas;
using UnityEngine;

public interface IViewController {

    GameObject gameObject { get; }
    Vector2 position { get; set; }
    Vector3 rotate { get; set; }

    void Link(Entity entity, Pool pool);

    void Show(bool animated);
    void Hide(bool animated);

    void Reset();

    void Velocity(Vector2 value);
}
