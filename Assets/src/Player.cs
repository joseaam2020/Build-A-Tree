using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    private InputControl inputControl; 
    public PlayerMovement player;
    public Animator animator;
    public Transform punchPoint;
    public LayerMask playerLayer;

    public float attackRange = 0.5f;
    private bool jump = false;
    public float speed = 40;
    private float lastPunch;
    public float punchForce = 200;

    private float horizontalMovement;
   
    private void Awake()
    {
        inputControl = new InputControl();
        lastPunch = inputControl.Player.Punch.ReadValue<float>();
        horizontalMovement = 0f;
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        player.Move(horizontalMovement * speed * Time.deltaTime,false, jump);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
    }

    public void jumpLanding()
    {
        jump = false;
        animator.SetBool("Jump", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchPoint.position,attackRange);
    }

    public void OnMovement()
    {
        horizontalMovement = inputControl.Player.Movement.ReadValue<float>();
    }

    public void OnJump()
    {
        float verticalMovement = inputControl.Player.Jump.ReadValue<float>();
        if (verticalMovement == 1)
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        player.Move(horizontalMovement * speed * Time.deltaTime, false, jump);
    }

    public void OnPunch()
    {
        
        float punchingValue = inputControl.Player.Punch.ReadValue<float>();
        if (lastPunch != 1)
        {
            //punch animation     
            animator.SetTrigger("Punch");
            animator.SetBool("Jump", false);
            //add force to enemies
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(punchPoint.position, attackRange, playerLayer);
            if (hitPlayers.Length != 0)
            {
                foreach (Collider2D enemyPlayer in hitPlayers)
                {
                    Transform enemy = enemyPlayer.GetComponent<Transform>();
                    Rigidbody2D enemybody = enemyPlayer.GetComponent<Rigidbody2D>();
                    if (enemy.Equals(transform))
                    {
                        continue;
                    }
                    if (transform.position.x <= enemy.position.x)
                    {
                        enemybody.AddForce(new Vector2(punchForce, 0));
                    }
                    else
                    {
                        enemybody.AddForce(new Vector2(-punchForce, 0));
                    }
                }
            }
        }
        lastPunch = punchingValue;
    }
}
