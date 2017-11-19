using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    Camera m_camera;
    PoolContext pool;

	// Use this for initialization
	void Start()
    {
        m_camera = GetComponent<Camera>();
        pool = Contexts.sharedInstance.pool;


        pool.GetGroup(PoolMatcher.AllOf(PoolMatcher.Camera, PoolMatcher.Position)).OnEntityAdded += (group, entity, index, component) => 
        {
            UpdateCameraPos(entity.position.x, entity.position.y);
        };
    }

	void UpdateCameraPos(int x, int y)
    {
        transform.position = new Vector3(x, y, -10);
    }
}
