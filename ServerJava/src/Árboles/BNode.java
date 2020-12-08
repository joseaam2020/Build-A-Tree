package Árboles;

/**
 * Clase que crea los nodos con los que trabaja el arbol B.
 */
public class BNode {
    private int T;
    private int datum;
    private int data[];
    private BNode childs[];
    private boolean leaf = true;

    /**
     * Constructor de la clase del nodo, recibe el dato que debe almacenar.
     * @param t
     */
    public BNode(int t){
        this.T = t;
        this.data = new int[2*T-1];
        this.childs = new BNode[2*T];
    }

    /**
     * Obtiene el elemento que almacena
     * @return
     */
    public int getDatum() {
        return datum;
    }

    /**
     * Asigna el elemento que alamacena
     * @param datum
     */
    public void setDatum(int datum) {
        this.datum = datum;
    }

    /**
     * Booleano para la variable de leaf, le asigna true o false segun el caso.
     * @param leaf
     */
    public void setLeaf(boolean leaf) {
        this.leaf = leaf;
    }

    /**
     * Obtiene el valor booleano de la variable leaf.
     * @return
     */
    public boolean getLeaf(){
        return this.leaf;
    }

    public int[] getData() {
        return data;
    }

    public void setData(int[] data) {
        this.data = data;
    }

    public BNode[] getChilds() {
        return childs;
    }

    public void setChilds(BNode[] childs) {
        this.childs = childs;
    }
}
