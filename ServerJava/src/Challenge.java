import Árboles.*;
import java.util.Random;

/**
 * Clase challenge que genera los challenge de la partida de manera aleatoria.
 */
public class Challenge {

    private Random randnum = new Random();

    /**
     * Constructor de la clase challenge que llama al metodo que selecciona el tipo de arbol.
     */
    public Challenge(){
        selectChallenge();
    }

    /**
     * Metodo que selecciona el tipo de arbol para el challenge.
     */
    public void selectChallenge(){

        int get_num = randnum.nextInt(8);

        if (get_num == 0 | get_num == 1){
            AVLChallenge();
        } else if (get_num == 2 | get_num == 3){
            BChallenge();
        } else if (get_num == 4 | get_num == 5){
            BSTChallenge();
        } else {
            SplayChallenge();
        }

    }

    /**
     * Challenge del arbol AVL, selecciona uno de las 2 opciones.
     */
    public void AVLChallenge(){

        int get_num = randnum.nextInt(2);

        if(get_num == 0) {
            AVLTree challenge1 = new AVLTree();
            int num_in = 0;
            while (num_in < 9){
                challenge1.setRoot(challenge1.insert(challenge1.getRoot(), num_in));
                num_in++;
            }
            int time = 351;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("AVL");
            Control.getInstance().setGoal(num_in);


        } else{
            AVLTree challenge2 = new AVLTree();
            int num_in = 0;
            while (num_in < 15){
                challenge2.setRoot(challenge2.insert(challenge2.getRoot(), num_in));
                num_in++;
            }
            int time = 421;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("AVL");
            Control.getInstance().setGoal(num_in);
        }
        Control.getInstance().setShape("CIRCULO");

    }

    /**
     * Challenge del arbol BST, selecciona uno de las 2 opciones.
     */
    public void BSTChallenge(){
        int get_num = randnum.nextInt(2);

        if(get_num == 0) {
            BSTTree challenge1 = new BSTTree();
            int num_in = 0;
            while (num_in < 7){
                challenge1.insertar(num_in);
                num_in++;
            }
            int time = 351;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("BST");
            Control.getInstance().setGoal(num_in);
        } else{
            BSTTree challenge2 = new BSTTree();
            int num_in = 0;
            while (num_in < 11){
                challenge2.insertar(num_in);
                num_in++;
            }
            int time = 471;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("BST");
            Control.getInstance().setGoal(num_in);
        }
        Control.getInstance().setShape("ROMBO");
    }

    /**
     * Challenge del arbol B, selecciona uno de las 2 opciones.
     */
    public void BChallenge(){

        int get_num = randnum.nextInt(2);

        if(get_num == 0) {
            BTree challenge1 = new BTree(2);
            int num_in = 0;
            while (num_in < 6){
                challenge1.Insert(num_in);
                num_in++;
            }
            int time = 371;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("B");
            Control.getInstance().setGoal(num_in);
        } else{
            BTree challenge2 = new BTree(5);
            int num_in = 0;
            while (num_in < 13){
                challenge2.Insert(num_in);
                num_in++;
            }
            int time = 491;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("B");
            Control.getInstance().setGoal(num_in);
        }
        Control.getInstance().setShape("CUADRADO");

    }

    /**
     * Challenge del arbol Splay, selecciona uno de las 2 opciones.
     */
    public void SplayChallenge(){
        int get_num = randnum.nextInt(2);

        if(get_num == 0) {
            SplayTree challenge1 = new SplayTree();
            int num_in = 0;
            while (num_in < 6){
                challenge1.insertar(num_in);
                num_in++;
            }
            int time = 374;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("SPLAY");
            Control.getInstance().setGoal(num_in);
        } else{
            BTree challenge2 = new BTree(5);
            int num_in = 0;
            while (num_in < 12){
                challenge2.Insert(num_in);
                num_in++;
            }
            int time = 481;
            Control.getInstance().setTime1(time);
            Control.getInstance().setChallenge("SPLAY");
            Control.getInstance().setGoal(num_in);
        }
        Control.getInstance().setShape("TRIANGULO");
    }

}
