package Árboles;

/**
 * Clase nodo para el arbol BST, que se encarga de
 */
class BSTNodo {
    private int dato;
    private BSTNodo izquierda, derecha;

    /**
     * Constructor del nodo del arbol BST, debe recibir el dato que tiene que almacenar.
     * @param dato
     */
    public BSTNodo(int dato) {
        this.dato = dato;
        this.izquierda = this.derecha = null;
    }

    /**
     * Metodo para obtener el dato que se encuentra dentro del nodo.
     * @return
     */
    public int getDato() {
        return dato;
    }

    /**
     * Obtiene el hijo izquierdo del nodo
     * @return
     */
    public BSTNodo getIzquierda() {
        return izquierda;
    }

    /**
     * Asiga=na un hijo izquierdo para el nodo.
     * @param izquierda
     */
    public void setIzquierda(BSTNodo izquierda) {
        this.izquierda = izquierda;
    }

    /**
     * Obtiene el hijo derecho del nodo.
     * @return
     */
    public BSTNodo getDerecha() {
        return derecha;
    }

    /**
     * Asigna un valor al hijo derecho del nodo.
     * @param derecha
     */
    public void setDerecha(BSTNodo derecha) {
        this.derecha = derecha;
    }

    /**
     * Imprime el dato que se introduce en el nodo.
     */
    public void imprimirDato() {
        System.out.println(this.getDato());
    }
}
