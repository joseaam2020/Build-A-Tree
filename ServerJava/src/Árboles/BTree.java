package Árboles;

public class BTree {

    private int T;
    private BNode root;

    public BTree(int t){
        this.T = t;
        root = new BNode(t);
        root.setDatum(0);
        root.setLeaf(true);
    }

    public void Split(BNode x,int pos, BNode y){
        BNode z = new BNode(T);
        z.setLeaf(y.getLeaf());
        z.setDatum(T-1);
        for (int j = 0; j<T-1;j++){
            int zdata[] = z.getData();
            int ydata[] = y.getData();
            zdata[j] = ydata[j+T];
            z.setData(zdata);
        }
        if (!y.getLeaf()){
            for (int i = 0; i < T;i++){
                BNode zchilds[] = z.getChilds();
                BNode ychilds[] = y.getChilds();
                zchilds[i] = ychilds[i+T];
                z.setChilds(zchilds);
            }
        }
        y.setDatum(T-1);
        for (int i = x.getDatum(); i>=pos+1;i--){
            BNode xchilds[] = x.getChilds();
            xchilds[i+1] = xchilds[i];
            x.setChilds(xchilds);
        }
        BNode xchilds[] = x.getChilds();
        xchilds[pos+1] = z;
        x.setChilds(xchilds);

        for(int i = x.getDatum()-1; i>=pos; i--){
            int xdata[] = x.getData();
            xdata[i+1]=xdata[i];
            x.setData(xdata);
        }
        int xdata[] = x.getData();
        int ydata[] = y.getData();
        xdata[pos] = ydata[T-1];
        x.setData(xdata);
        x.setDatum(x.getDatum()+1);
    }

    public void Insert(int num){
        BNode r_node = root;
        if (r_node.getDatum() == 2*T-1){
            BNode new_node = new BNode(T);
            root = new_node;
            new_node.setLeaf(false);
            BNode childs[] = new_node.getChilds();
            childs[0] = r_node;
            new_node.setChilds(childs);
            Split(new_node,0,r_node);
            Insertion(new_node,num);
        } else{
            Insertion(r_node,num);
        }
    }

    private void Insertion(BNode node,int data){
        BNode nodechilds[] = node.getChilds();
        int nodedata[] = node.getData();
        if (node.getLeaf()){
            int i = 0;
            for(i = node.getDatum()-1; i>=0 && data < node.getData()[i]; i--){
                nodedata[i+1] = nodedata[i];
                node.setData(nodedata);
            }
            nodedata[i+1] = data;
            node.setData(nodedata);
            node.setDatum(node.getDatum()+1);
        } else{
            int i = 0;
            for (i = node.getDatum() - 1; i >= 0 && data < nodedata[i]; i--) {
            }
            ;
            i++;
            BNode tmp = nodechilds[i];
            if (tmp.getDatum() == 2 * T - 1) {
                Split(node, i, tmp);
                if (data > nodedata[i]) {
                    i++;
                }
            }
            Insertion(nodechilds[i], data);
        }
    }

    public void Show(){
        ShowAux(root);
    }

    private void ShowAux(BNode node){
        assert (node == null);
        for (int i = 0; i<node.getDatum();i++){
            System.out.print(node.getData()[i]+" ");
        }
        if (!node.getLeaf()){
            for (int i = 0; i< node.getDatum()+1;i++){
                ShowAux(node.getChilds()[i]);
            }
        }
    }
}
