using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animator.SetBool("turn_left_animation", true);
            _animator.SetBool("turn_right_animation", false);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("turn_left_animation", false);
            _animator.SetBool("turn_right_animation", false);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("turn_left_animation", false);
            _animator.SetBool("turn_right_animation", true);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("turn_right_animation",false);
            _animator.SetBool("turn_left_animation", false);
        }
    }
}
