package Árboles;

/**
 * Clase que forma el arbol BST
 */
public class BSTTree {
    private BSTNodo raiz;

    /**
     * Constructor para llamar al arbol BST.
     */
    public BSTTree() {
    }

    /**
     * Funcion de busqueda para algun dato, llama a la funcion privada del mismo nombre. True si encuentra el dato, false
     * en caso contrario.
     * @param busqueda
     * @return true o false
     */
    public boolean existe(int busqueda) {
        return existe(this.raiz, busqueda);
    }

    private boolean existe(BSTNodo n, int busqueda) {
        if (n == null) {
            return false;
        }
        if (n.getDato() == busqueda) {
            return true;
        } else if (busqueda < n.getDato()) {
            return existe(n.getIzquierda(), busqueda);
        } else {
            return existe(n.getDerecha(), busqueda);
        }

    }

    /**
     * Permite insertar un dato en el arbol. Llama a la funcion privada con el mismo nombre para insertar el dato en caso
     * de que si exista una raiz.
     * @param dato
     */
    public void insertar(int dato) {
        if (this.raiz == null) {
            this.raiz = new BSTNodo(dato);
        } else {
            this.insertar(this.raiz, dato);
        }
    }

    /**
     * Funcion privada para insertar un dato en el arbol ya existente.
     * @param padre
     * @param dato
     */
    private void insertar(BSTNodo padre, int dato) {
        if (dato > padre.getDato()) {
            if (padre.getDerecha() == null) {
                padre.setDerecha(new BSTNodo(dato));
            } else {
                this.insertar(padre.getDerecha(), dato);
            }
        } else {
            if (padre.getIzquierda() == null) {
                padre.setIzquierda(new BSTNodo(dato));
            } else {
                this.insertar(padre.getIzquierda(), dato);
            }
        }
    }

    /**
     * Recorrer el arbol de manera de preorden
     * @param n
     */
    private void preorden(BSTNodo n) {
        if (n != null) {
            n.imprimirDato();
            preorden(n.getIzquierda());
            preorden(n.getDerecha());
        }
    }

    /**
     * Recorrer el arbol de manera de inorden
     * @param n
     */
    private void inorden(BSTNodo n) {
        if (n != null) {
            inorden(n.getIzquierda());
            n.imprimirDato();
            inorden(n.getDerecha());
        }
    }

    /**
     * Recorrer el arbol de la forma de post-orden.
     * @param n
     */
    private void postorden(BSTNodo n) {
        if (n != null) {
            postorden(n.getIzquierda());
            postorden(n.getDerecha());
            n.imprimirDato();
        }
    }

    /**
     * Llama al recorrido del preorden
     */
    public void preorden() {
        this.preorden(this.raiz);
    }

    /**
     * Llama al recorrido de inorden
     */
    public void inorden() {
        this.inorden(this.raiz);
    }

    /**
     * Llama al recorrido de postorden
     */
    public void postorden() {
        this.postorden(this.raiz);
    }
}