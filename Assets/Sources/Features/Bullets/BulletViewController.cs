using UnityEngine;

public interface IBulletController : IPoolableViewController {
}

public class BulletViewController : PoolableViewController, IBulletController {

    public override Vector2 position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }

    public override void Velocity(Vector2 value)
    {
        transform.Translate(new Vector3(value.x, value.y, 0));
    }

    [SerializeField]
    Vector3 _minRotation;

    [SerializeField]
    Vector3 _baseRotation;

    [SerializeField]
    float _randomRotationFactor;

    [SerializeField]
    EffectPlayer _despawnEffects;

    Vector3 _rotation;

    void OnEnable() {
        _rotation = _minRotation + (_baseRotation * GameRandom.view.RandomFloat(0, _randomRotationFactor));
    }

    void Update() {
        transform.Rotate(_rotation);
    }

    public override void Hide(bool animated) {
        if(animated) {
            _despawnEffects.Play(transform.position);
        }

        base.Hide(animated);
        PushToObjectPool();
        Reset();
    }
}
