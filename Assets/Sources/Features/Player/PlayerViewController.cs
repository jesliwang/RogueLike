using System;
using UnityEngine;

public interface IPlayerController : IViewController {
    void SetPlayerDirection(float x, float y);

    void SetPlayerSpeed(float speed);

    void AttackTrigger();

    bool InAttackState();
}

public class PlayerViewController : AnimatorViewController, IPlayerController
{
    public void SetPlayerDirection(float x, float y)
    {
		_animator.SetFloat("moveX", x );
		_animator.SetFloat("moveY", y);
    }

    public void SetPlayerSpeed(float speed)
    {
        _animator.SetFloat("speed", speed);
        if (speed > 0.1f){
            _animator.SetBool("moveing", true);
        }else{
            _animator.SetBool("moveing", false);
        }
    }

    public void AttackTrigger()
    {
        _animator.SetTrigger("attack");
    }

    public bool InAttackState()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName("attack");
    }


}
