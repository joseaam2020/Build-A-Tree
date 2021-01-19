using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTag : MonoBehaviour
{

    private bool facingRight;
    
    /// <summary>
    /// Permite que el name tag del jugador no cambie de posicion 
    /// </summary>
   public void OnPlayerTurned()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
