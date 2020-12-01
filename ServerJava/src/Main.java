import Server.*;
import Árboles.BTree;

public class Main {
    public static void main(String[] args) {

        TimerClass timer= new TimerClass();
        timer.CountTime(4);

        BTree b = new BTree(3);
        b.Insert(8);
        b.Insert(9);
        b.Insert(10);
        b.Insert(11);
        b.Insert(15);
        b.Insert(20);
        b.Insert(17);

        b.Show();
        
        Server.getInstance().run();

    }
}
