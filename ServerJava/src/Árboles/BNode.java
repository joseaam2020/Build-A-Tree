package Árboles;

public class BNode {
    private int T;
    private int datum;
    private int data[];
    private BNode childs[];
    private boolean leaf = true;

    public BNode(int t){
        this.T = t;
        this.data = new int[2*T-1];
        this.childs = new BNode[2*T];
    }

    public int getDatum() {
        return datum;
    }

    public void setDatum(int datum) {
        this.datum = datum;
    }

    public void setLeaf(boolean leaf) {
        this.leaf = leaf;
    }

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
