import Árboles.*;
import java.util.Random;

public class Challenge {

    private Random randnum = new Random();

    public Challenge(){
        selectChallenge();
    }

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

    public void AVLChallenge(){

        int get_num = randnum.nextInt(2);

        if(get_num == 0) {
            AVLTree challenge1 = new AVLTree();
            int num_in = 0;
            while (num_in < 9){
                challenge1.setRoot(challenge1.insert(challenge1.getRoot(), num_in));
                num_in++;
            }

        } else{
            AVLTree challenge2 = new AVLTree();
            int num_in = 0;
            while (num_in < 15){
                challenge2.setRoot(challenge2.insert(challenge2.getRoot(), num_in));
                num_in++;
            }
        }
    }

    public void BSTChallenge(){

    }

    public void BChallenge(){

        int get_num = randnum.nextInt(2);

        if(get_num == 0) {
            BTree challenge1 = new BTree(2);
            int num_in = 0;
            while (num_in < 6){
                challenge1.Insert(num_in);
                num_in++;
            }
        } else{
            BTree challenge2 = new BTree(5);
            int num_in = 0;
            while (num_in < 13){
                challenge2.Insert(num_in);
                num_in++;
            }
        }

    }

    public void SplayChallenge(){

    }

}
