using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokenHub : MonoBehaviour
{
    [SerializeField] GameObject[] Tokens;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        foreach(GameObject token in Tokens)
        {
            token.SetActive(false);
        }
    }

    public void activar_token(string nombre)
    {
        foreach (GameObject token in Tokens)
        {
            if (nombre == token.name)
            {
                token.SetActive(true);
            }
        }
    }

}
