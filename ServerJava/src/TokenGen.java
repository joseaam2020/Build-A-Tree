import java.util.Random;

/**
 * Generador de los tokens para los challenge.
 */
public class TokenGen {

    private Random rand = new Random();

    private static TokenGen instance;

    private TokenGen(){

    }

    /**
     * Constructor privado para evitar la instanciacion.
     * @return
     */
    public static TokenGen getInstance(){
        if (instance == null){
            instance = new TokenGen();
        }
        return instance;
    }

    /**
     * Seleccina un token de manera aleatoria
     */
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

    /**
     * Envia mensaje para que el cliente genere el token del BST
     */
    public void GenBSTtoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#BST");
    }

    /**
     * Envia mensaje para que el cliente genere el token del arbol AVL.
     */
    public  void GenAVLtoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#AVL");
    }

    /**
     * Envia mensaje para que el cliente genere el token del arbol B.
     */
    public void GenBtoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#B");
    }

    /**
     * Envia mensaje para que el cliente genere el token del arbol splay.
     */
    public void GenSplaytoken(){
        SalidaMSG.getInstance().EnviarMensaje("SPAWNER#SPLAY");
    }

}
