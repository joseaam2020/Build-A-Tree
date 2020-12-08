package Árboles;

/**
 * Clase AVLNode, que consiste en la clase que utiliza el arbol AVL para crear sus nodos y guardar toda su informacion,
 * asi como acceder tambien a los datos alamacenados en el arbol.
 */
public class AVLNode {
    private int data;
    private int height;

    private AVLNode left;
    private AVLNode right;

    /**
     * Constructor del nodo que recibe el dato que va a almacenar
     * @param data
     */
    public AVLNode(int data){
        this.data = data;
        this.height = 1;
    }

    /**
     * Permite asignar el hijo derecho del nodo
     * @param right
     */
    public void setRight(AVLNode right) {
        this.right = right;
    }

    /**
     * Permite asignar el hijo izquierdo del nodo
     * @param left
     */
    public void setLeft(AVLNode left) {
        this.left = left;
    }

    /**
     * Permite obtener el hijo izquierdo del nodo
     * @return
     */
    public AVLNode getLeft() {
        return left;
    }

    /**
     * Permite asignar el hijo derecho del nodo
     * @return
     */
    public AVLNode getRight() {
        return right;
    }

    /**
     * Permite obtener el dato que se encuentra almacenado en el nodo
     * @return
     */
    public int getData() {
        return data;
    }

    /**
     * Permite obtener la altura del nodo, osea la profundidad del arbol propiamente en el caso del root.
     * @return
     */
    public int getHeight() {
        return height;
    }

    /**
     * Asigna un valor a la altura a la que se encuentra el nodo en el arbol.
     * @param height
     */
    public void setHeight(int height) {
        this.height = height;
    }
}
