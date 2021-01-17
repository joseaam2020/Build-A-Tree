using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que se encarga de recibir el input de un control y mover a su respectivo modelo.
/// Tambien se encarga de las animaciones.
/// </summary>
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
    private Rigidbody2D body;


    private void Awake()
    {
        inputControl = new InputControl();
        lastPunch = inputControl.Player.Punch.ReadValue<float>();
        horizontalMovement = 0f;
        body = this.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }


    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    /// <summary>
    /// Mueve al personaje segun los valores obtenidos de los controles.
    /// </summary>
    private void Update()
    {
        player.Move(horizontalMovement * speed * Time.deltaTime,false, jump);
        Vector3 position = this.transform.position;
        if (position.y < -6)
        {
            position.y = 7;
        }
        if (position.x < -9)
        {
            position.x = 11;
        } else if (position.x > 11)
        {
            position.x = -9;
        }
        this.transform.position = position;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
    }

    /// <summary>
    /// Es llamada cuando se termina un salto.
    /// </summary>
    public void jumpLanding()
    {
        animator.SetBool("Jump", false);
        player.setGrounded(true);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchPoint.position,attackRange);
    }

    /// <summary>
    /// Obtiene valores del control para moverse de manera horizontal.
    /// </summary>
    public void OnMovement()
    {
        horizontalMovement = inputControl.Player.Movement.ReadValue<float>();
    }

    /// <summary>
    /// Añade una fuerza al personaje para hacerlo saltar cuando se obtiene la instruccion del control.
    /// </summary>
    public void OnJump()
    {
        animator.SetBool("Jump", true);
        // Add a vertical force to the player.
        if (player.getGrounded())
        {
            player.setGrounded(false);
            body.AddForce(new Vector2(0f, player.getJumpForce()));
        }
    }

    /// <summary>
    /// Obtiene el valor de golpear del control y añade fuerza a los enmigos en la zona de golpe.
    /// </summary>
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

    /// <summary>
    /// Obtiene nombre.
    /// </summary>
    /// <returns>Nombre como string</returns>
    public string getName()
    {
        return this.gameObject.name; 
    }
}
