using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tokenSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField]public GameObject tokenHubPrefab;
    public void Spawn(string tipo, int dato_tkn)
    {
        int x_axis = Random.Range(-8,9);//rango entre 8,-8 para el spawn segun eje x
        int y_axis = 9;//siempre constante, los objetos caen

        Vector3 vector = new Vector3();
        vector.x = x_axis;
        vector.y = y_axis;
        vector.z = -3;
        var token = Instantiate(tokenHubPrefab);
        token.transform.position = vector;
        //Debug.Log(token.transform.position.x);

        TextMeshPro dato = token.gameObject.GetComponentInChildren<TextMeshPro>();
        dato.text = dato_tkn.ToString();
        tokenHub script = token.GetComponent<tokenHub>();

        if (tipo == "BST Tree")
        {
            script.activar_token("token_rombo");
            //BST Tree
        }
        if (tipo == "B Tree")
        {
            script.activar_token("token_cuadrado");
            //B Tree
        }
        if (tipo == "AVL Tree")
        {

            script.activar_token("token_circulo");
            //AVL Tree
        }
        if (tipo == "Splay Tree")
        {
            script.activar_token("token_triangulo");
            //Splay Tree
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //enviar dato al servidor
        }
    }

    public string Redeemtoken(string tipo)
    {
        if (tipo == "rombo")
            //BST Tree
        {
            return tipo;
        }
        if (tipo == "cuadrado")
            //B Tree
        {
            return tipo;
        }
        if (tipo == "circulo")
            //AVL Tree
        {
            return tipo;
        }
        if (tipo == "triangulo")
            //Splay Tree
        { 
            return tipo;
        }
        else
        {
            return null;
        }
    }
}
