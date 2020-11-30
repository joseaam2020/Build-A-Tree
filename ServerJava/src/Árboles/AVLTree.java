package Árboles;

public class AVLTree {

    private AVLNode root;

    public AVLNode getRoot() {
        return root;
    }

    public void setRoot(AVLNode root) {
        this.root = root;
    }

    public int Balance(AVLNode node){
        if (node == null){
            return 0;
        }
        return Height(node.getLeft()) - Height(node.getRight());
    }

    public AVLNode rightRotate(AVLNode y){
        AVLNode x = y.getLeft();
        AVLNode T2 = x.getRight();

        x.setRight(y);
        y.setLeft(T2);

        y.setHeight(Max(Height(y.getLeft()),Height(y.getRight()))+1);
        x.setHeight(Max(Height(x.getLeft()),Height(x.getRight()))+1);

        return x;
    }

    public AVLNode leftRotate(AVLNode x){
        AVLNode y = x.getRight();
        AVLNode T2 = y.getLeft();

        y.setLeft(x);
        x.setRight(T2);

        x.setHeight(Max(Height(x.getLeft()),Height(x.getRight()))+1);
        y.setHeight(Max(Height(y.getLeft()),Height(y.getRight()))+1);

        return y;
    }

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

    public int Height(AVLNode node){
        if (node == null)
            return 0;
        return node.getHeight();
    }

    public int Max(int num1, int num2){
        return (num1 > num2 ) ? num1:num2;
    }

    public void Show(AVLNode node){
        if (node != null){
            System.out.print(node.getData()+" ");
            Show(node.getLeft());
            Show(node.getRight());
        }
    }
}
