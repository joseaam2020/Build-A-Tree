using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tokenHub : MonoBehaviour
{
    [SerializeField] GameObject[] Tokens;
    public LayerMask playerLayer;
    public float range = 0.7f;
    Client client;
    private string activeToken;
    public GameObject[] datosJugador;


    // Start is called before the first frame update
    void Start()
    {
        GameObject clientSocket = GameObject.FindGameObjectWithTag("ClientSocket");
        client = clientSocket.GetComponent<Client>();
        datosJugador = GameObject.FindGameObjectsWithTag("DatosJugador");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Update is called once per frame
    void Update()
    {
        //Consigue todas las colisiones de con los jugadores
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, range, playerLayer);
        if (hitPlayers.Length > 0)
        {
            //Si hay colisiones, tomar la primera y asignar los puntos
            Transform jugador = hitPlayers[0].GetComponent(typeof(Transform)) as Transform;
            //Arreglar numero de jugador
            int numJugador = Int32.Parse(jugador.parent.name);
            //Enviar TOKEN#"Numero de jugador"#"Forma en mayusculas"
            string tipo = "";
            string arbol = "";
            if (activeToken.Equals("token_rombo"))
            {
                tipo = "ROMBO"; //BST
                arbol = "BST";
            }
            if (activeToken.Equals("token_circulo"))
            {
                tipo = "CIRCULO";//AVL
                arbol = "AVL";
            }
            if (activeToken.Equals("token_cuadrado"))
            {
                tipo = "CUADRADO";//B
                arbol = "B";
            }
            if (activeToken.Equals("token_triangulo"))
            {
                tipo = "TRIANGULO";//SPlay
                arbol = "SPLAY"; 
            }
            client.SendMSG("TOKEN#" + numJugador.ToString() + "#" + tipo);
            //Cambiar Panel de juego
            DatosJugador dato = datosJugador[numJugador].GetComponent<DatosJugador>();
            if (arbol == client.currentTree)
            {
                dato.nextActiveNodo();
            } else
            {
                dato.resetActiveArbol();
            }
            
            
            Destroy(this.gameObject);
        }

        if(transform.position.y < -9)
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        foreach(GameObject token in Tokens)
        {
            token.SetActive(false);
        }
    }

    private string getActiveToken()
    {
        return activeToken;
    }

    public void activar_token(string nombre)
    {
        foreach (GameObject token in Tokens)
        {
            if (nombre == token.name)
            {
                token.SetActive(true);
                activeToken = token.name;
            }
        }
    }

}
