package Árboles;

/**
 * Clase de AVLTree, forma el arbol AVL para los challenge del juego
 */
public class AVLTree {

    private AVLNode root;

    /**
     * Obtiene el nodo raiz del arbol
     * @return
     */
    public AVLNode getRoot() {
        return root;
    }

    /**
     * Asigna la raiz del arbol a la variable que la contiene.
     * @param root
     */
    public void setRoot(AVLNode root) {
        this.root = root;
    }

    /**
     * Retorna el balance del arbol restando la altura del hijo izquierdo y derecho del nodo
     * @param node
     * @return true o false segun el caso
     */
    public int Balance(AVLNode node){
        if (node == null){
            return 0;
        }
        return Height(node.getLeft()) - Height(node.getRight());
    }

    /**
     * Rotacion a la derecha en caso de que se necesite porque el arbol se ecnuentra desbalanceado.
     * @param y
     * @return
     */
    public AVLNode rightRotate(AVLNode y){
        AVLNode x = y.getLeft();
        AVLNode T2 = x.getRight();

        x.setRight(y);
        y.setLeft(T2);

        y.setHeight(Max(Height(y.getLeft()),Height(y.getRight()))+1);
        x.setHeight(Max(Height(x.getLeft()),Height(x.getRight()))+1);

        return x;
    }

    /**
     * Rotacion a la izquierda por parte de los nodos en caso de que el arbol se encuentre desbalanceado.
     * @param x
     * @return
     */
    public AVLNode leftRotate(AVLNode x){
        AVLNode y = x.getRight();
        AVLNode T2 = y.getLeft();

        y.setLeft(x);
        x.setRight(T2);

        x.setHeight(Max(Height(x.getLeft()),Height(x.getRight()))+1);
        y.setHeight(Max(Height(y.getLeft()),Height(y.getRight()))+1);

        return y;
    }

    /**
     * Permite insertar en el arbol un entero y un nodo, el nodo que recibe siempre es la raiz.
     * @param node
     * @param data
     * @return
     */
    public AVLNode insert(AVLNode node, int data){
        if (node == null){
            return (new AVLNode(data));
        }
        if (data < node.getData()){
            node.setLeft(insert(node.getLeft(),data));
        } else if (data > node.getData()) {
            node.setRight(insert(node.getRight(),data));
        } else{
            return node;
        }
        node.setHeight(1+Max(Height(node.getLeft()),Height(node.getRight())));

        int balance = Balance(node);

        if (balance > 1 && data < node.getLeft().getData()){
            return rightRotate(node);
        }

        if (balance < -1 && data > node.getRight().getData()){
            return leftRotate(node);
        }

        if (balance > 1 && data > node.getLeft().getData()) {
            node.setLeft(leftRotate(node.getLeft()));
            return rightRotate(node);
        }

        if (balance < -1 && data < node.getRight().getData()) {
            node.setRight(rightRotate(node.getRight()));
            return leftRotate(node);
        }

        return node;
    }

    /**
     * Retorna la altura del nodo de la raiz, lo que seria la altura del arbol.
     * @param node
     * @return entero con la altura
     */
    public int Height(AVLNode node){
        if (node == null)
            return 0;
        return node.getHeight();
    }

    /**
     * Obtiene el mayor de dos numeros
     * @param num1
     * @param num2
     * @return entero mayor
     */
    public int Max(int num1, int num2){
        return (num1 > num2 ) ? num1:num2;
    }

    /**
     * Imprimir los elementos del arbol en consola.
     * @param node
     */
    public void Show(AVLNode node){
        if (node != null){
            System.out.print(node.getData()+" ");
            Show(node.getLeft());
            Show(node.getRight());
        }
    }
}
