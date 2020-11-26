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
   
    private void Awake()
    {
        inputControl = new InputControl();
        lastPunch = inputControl.Player.Punch.ReadValue<float>();
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
        float horizontalMovement = inputControl.Player.Movement.ReadValue<float>();
        float verticalMovement = inputControl.Player.Jump.ReadValue<float>();
        float punchingValue = inputControl.Player.Punch.ReadValue<float>();
        //Debug.Log(punchingValue);
        if (verticalMovement == 1)
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        if (punchingValue == 1 && lastPunch != 1)
        {
            //punch animation     
            animator.SetTrigger("Punch");
            animator.SetBool("Jump", false);
            //add force to enemies
            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(punchPoint.position, attackRange, playerLayer);
            if(hitPlayers.Length != 0)
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
        player.Move(horizontalMovement * speed * Time.deltaTime,false, jump);
        //Debug.Log(transform.position);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        lastPunch = punchingValue;
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
}
