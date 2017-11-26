using UnityEngine;

public interface IPlayerBulletController : IPoolableViewController
{
}

public class PlayerBulletViewController : PoolableViewController, IPlayerBulletController
{
	public override void Hide(bool animated)
	{
		base.Hide(animated);
		PushToObjectPool();
		Reset();
	}
}
