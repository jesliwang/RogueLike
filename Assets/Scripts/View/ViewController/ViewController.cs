using Entitas;
using UnityEngine;

public class ViewController : MonoBehaviour, IViewController {

    public virtual Vector2 position {
        get { 
            return GetComponent<Rigidbody2D>().position; 
        }
        set {
            GetComponent<Rigidbody2D>().position = value;
        }
    }

    public virtual Vector3 rotate {
        get { return transform.localRotation.eulerAngles; }
        set { transform.localEulerAngles = value; }
    }

    public virtual void Link(Entity entity, Pool pool) {
        gameObject.Link(entity, pool);
    }

    public virtual void Show(bool animated) {
        gameObject.SetActive(true);
    }

    public virtual void Hide(bool animated) {
        gameObject.SetActive(false);
    }

    public virtual void Reset() {
        gameObject.Unlink();
    }

    public virtual void Velocity(Vector2 value){
        GetComponent<Rigidbody2D>().velocity = value;
    }
}
