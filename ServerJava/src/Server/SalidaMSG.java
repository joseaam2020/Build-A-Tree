package Server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

public class SalidaMSG {

    private Socket salida;
    private DataOutputStream out;
    private DataInputStream in;
    private String IP = "localhost";
    private int puerto = 5345;
    private static SalidaMSG instance;

    private SalidaMSG(){

        try{
            this.salida = new Socket(IP,puerto);
            this.in = new DataInputStream(salida.getInputStream());
            this.out = new DataOutputStream(salida.getOutputStream());
        }catch (Exception e){
            e.printStackTrace();
        }

    }

    public static SalidaMSG getInstance(){
        if (instance == null){
            instance = new SalidaMSG();
            return instance;
        } else{
            return instance;
        }
    }

    public void EnviarMensaje(String msg){
        try{
            this.out.writeUTF(msg);
        }catch (IOException e){
            e.printStackTrace();
        }
    }


}
