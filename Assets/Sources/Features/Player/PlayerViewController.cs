using System;
using UnityEngine;

public interface IPlayerController : IViewController {
    void SetPlayerDirection(float x, float y);

    void SetPlayerSpeed(float speed);

    bool InAttackState();
}

public class PlayerViewController : AnimatorViewController, IPlayerController, InterfaceHit, InterfaceAttack
{    
    public Vector2 GetDirection(){
        return new Vector2(_animator.GetFloat("moveX"), _animator.GetFloat("moveY"));
    }

    public void SetPlayerDirection(float x, float y)
    {
        bool moveing = false;
        if (Mathf.Abs(x) > 0.5f){
            _animator.SetFloat("moveX", x);
            moveing = true;
        }else{
            _animator.SetFloat("moveX", 0);
        }


        if (Mathf.Abs(y) > 0.5f)
        {
            _animator.SetFloat("moveY", y);
            moveing = true;
        }else{
            _animator.SetFloat("moveY", 0);
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

    public void Hit()
    {
        Debug.LogError("lost hp");
    }
}
