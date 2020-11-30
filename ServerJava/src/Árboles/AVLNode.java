package Árboles;

public class AVLNode {
    private int data;
    private int height;

    private AVLNode left;
    private AVLNode right;

    public AVLNode(int data){
        this.data = data;
        this.height = 1;
    }

    public void setRight(AVLNode right) {
        this.right = right;
    }

    public void setLeft(AVLNode left) {
        this.left = left;
    }

    public AVLNode getLeft() {
        return left;
    }

    public AVLNode getRight() {
        return right;
    }

    public int getData() {
        return data;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }
}
