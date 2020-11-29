import Árboles.AVLTree;

public class Main {
    public static void main(String[] args) {

        AVLTree tree = new AVLTree();

        tree.setRoot(tree.insert(tree.getRoot(), 9));
        tree.setRoot(tree.insert(tree.getRoot(), 5));
        tree.setRoot(tree.insert(tree.getRoot(), 10));
        tree.setRoot(tree.insert(tree.getRoot(), 0));
        tree.setRoot(tree.insert(tree.getRoot(), 6));
        tree.setRoot(tree.insert(tree.getRoot(), 11));
        tree.setRoot(tree.insert(tree.getRoot(), -1));
        tree.setRoot(tree.insert(tree.getRoot(), 1));
        tree.setRoot(tree.insert(tree.getRoot(), 2));

        tree.Show(tree.getRoot());
        System.out.println("");

    }
}
