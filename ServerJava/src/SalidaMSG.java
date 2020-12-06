import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

public class SalidaMSG {

    private Socket salida;
    private DataOutputStream out;
    private String IP = "127.0.0.1";
    private int puerto = 5000;
    private static SalidaMSG instance;
    private Socket connection;

    private SalidaMSG(){


    }

    public static SalidaMSG getInstance(){
        if (instance == null){
            instance = new SalidaMSG();
            return instance;
        } else{
            return instance;
        }
    }

    public void setConnection(Socket connection) {
        this.connection = connection;
    }

    public void EnviarMensaje(String msg){
        try{
            this.salida = connection;
            this.out = new DataOutputStream(salida.getOutputStream());
        }catch (Exception e){
            e.printStackTrace();
        }
        try{
            String toSend = msg;
            byte[] toSendBytes = toSend.getBytes();
            int toSendLen = toSendBytes.length;
            byte[] toSendLenBytes = new byte[4];
            toSendLenBytes[0] = (byte)(toSendLen & 0xff);
            toSendLenBytes[1] = (byte)((toSendLen >> 8) & 0xff);
            toSendLenBytes[2] = (byte)((toSendLen >> 16) & 0xff);
            toSendLenBytes[3] = (byte)((toSendLen >> 24) & 0xff);
            out.write(toSendLenBytes);
            out.write(toSendBytes);
            System.out.println("Enviado: "+msg);

        } catch (IOException e1){
            System.out.println(e1.getMessage());
        }
    }


}
