package Árboles;

/**
 * Clase que forma al arbol splay, contiene a la clase que forma sus nodos.
 */
public class SplayTree {
    /**
     * Clase nodo, alamacena los datos del arbol splay
     */
    class Nodo
    {
        int info;
        Nodo izq, der;
    }
    private Nodo raiz;

    /**
     * Constructor del arbol splay
     */
    public SplayTree() {
        raiz=null;

    }

    /**
     * Metodo para insertar datos en el arbol splay.
     * @param info
     */
    public void insertar (int info)
    {
        Nodo nuevo;
        nuevo = new Nodo ();
        nuevo.info = info;
        nuevo.izq = null;
        nuevo.der = null;
        if (raiz == null)
            raiz = nuevo;
        else
        {
            Nodo anterior = null, reco;
            reco = raiz;
            while (reco != null)
            {
                anterior = reco;
                if (info < reco.info)
                    reco = reco.izq;
                else
                    reco = reco.der;
            }
            if (info < anterior.info)
                anterior.izq = nuevo;
            else
                anterior.der = nuevo;
        }
    }

    /**
     * Imprime los valores contenidos en el arbol
     * @param reco
     */
    private void imprimirPre (Nodo reco)
    {
        if (reco != null)
        {
            System.out.print(reco.info + " ");
            imprimirPre (reco.izq);
            imprimirPre (reco.der);
        }
    }

    /**
     * Llama a la funcion que muestra el recorrido del arbol y le pasa la raiz como nodo inicial.
     */
    public void imprimirPre ()
    {
        imprimirPre (raiz);
        System.out.println();
    }

    /**
     * Imprime los valores del arbol variando entre izquierda y derecha.
     * @param reco
     */
    private void imprimirEntre (Nodo reco)
    {
        if (reco != null)
        {
            imprimirEntre (reco.izq);
            System.out.print(reco.info + " ");
            imprimirEntre (reco.der);
        }
    }

    /**
     * Llama a la funcion de imprimir entre dandole como nodo inicial la raiz.
     */
    public void imprimirEntre ()
    {
        imprimirEntre (raiz);
        System.out.println();
    }

    /**
     * Permite imprimir luego izquierda-derecha de cada nodo.
     * @param reco
     */
    private void imprimirPost (Nodo reco)
    {
        if (reco != null)
        {
            imprimirPost (reco.izq);
            imprimirPost (reco.der);
            System.out.print(reco.info + " ");
        }
    }

    /**
     * Llama al imprimir post para que inicie con la raiz.
     */
    public void imprimirPost ()
    {
        imprimirPost (raiz);
        System.out.println();
    }
}

