import java.util.Random;

public class TokenGen {

    private Random rand = new Random();

    private static TokenGen instance;

    private TokenGen(){

    }

    public static TokenGen getInstance(){
        if (instance == null){
            instance = new TokenGen();
        }
        return instance;
    }

    public void SelectRandomToken(){
        int num = rand.nextInt(4);
        if (num == 0){
            GenBSTtoken();
        } else if(num == 1){
            GenAVLtoken();
        } else if(num == 2){
            GenBtoken();
        } else{
            GenSplaytoken();
        }

    }

    public void GenBSTtoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#BST");
    }

    public  void GenAVLtoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#AVL");
    }

    public void GenBtoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#B");
    }

    public void GenSplaytoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#SPLAY");
    }

}
