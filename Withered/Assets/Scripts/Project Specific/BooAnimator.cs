using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooAnimator : MonoBehaviour
{
    
    [SerializeField] private MovementBase _movement;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _idleIntervalMax;
    [SerializeField] private float _idleIntervalMin;
    private Vector3 _scale;
    private float _timer;

    private void Start()
    {
        _scale = _animator.GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = Random.Range(_idleIntervalMin, _idleIntervalMax);
            _animator.SetTrigger("Play Idle");
        }

        _animator.SetFloat("VelocityX", _movement.GetCurrentVelocity().x);
        _animator.SetFloat("VelocityY", _movement.GetCurrentVelocity().y);
        _animator.SetBool("Walking", _movement.GetCurrentVelocity().x > 0.5 || _movement.GetCurrentVelocity().x < -0.5);
        _animator.SetBool("Jumping", !_movement.Grounded && !_movement.Climbing);
        if(_movement.GetCurrentVelocity().x < 0)
        {
            _animator.GetComponent<Transform>().localScale = Vector3.Scale(_scale , new Vector3(-1, 1, 1));
        }
        else
        {
            _animator.GetComponent<Transform>().localScale = _scale;
        }
    }
}
