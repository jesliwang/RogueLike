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
        bool moveing = false;
        if (Mathf.Abs(x) > 0.5f){
            _animator.SetFloat("moveX", x);
            moveing = true;
        }

        if (Mathf.Abs(y) > 0.5f)
        {
            _animator.SetFloat("moveY", y);
            moveing = true;
        }
		
        _animator.SetBool("moveing", moveing);
    }

    public void SetPlayerSpeed(float speed)
    {
        _animator.SetFloat("speed", speed);

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
