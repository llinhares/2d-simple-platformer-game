using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed = 10f;
    public float speedRun = 15f;
    public float jumpForce = 2f;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;    

    [Header("Animation Player")]
    public string triggerToWalk = "Walk";
    public string triggerToRun = "Run";
    public Animator animator;
    public float playerSwipeDuration = .1f;

    private float _currentSpeed;
    void Update()
    {
        HandleJump();
        HandleMovements();
    }

    private void HandleMovements()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
            animator.SetBool(triggerToRun, true);
        }
        else
        {
            _currentSpeed = speed;
            animator.SetBool(triggerToRun, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            animator.SetBool(triggerToWalk, true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x == -1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            animator.SetBool(triggerToWalk, true);
        }
        else
        {
            animator.SetBool(triggerToWalk, false);
        }

        if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        } else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myRigidbody.velocity = Vector2.up * jumpForce;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            handleScaleJump();
        }
    }

    private void handleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
