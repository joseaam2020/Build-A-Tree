package Server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.Socket;
import java.net.SocketException;

public class StartServer implements Runnable{

    private Socket socket;
    private DataInputStream in;
    private DataOutputStream out;

    public StartServer(Socket soc){
        this.socket = soc;
    }

    @Override
    public void run() {

        try{
            out = new DataOutputStream(socket.getOutputStream());
            in = new DataInputStream(socket.getInputStream());

            while(true){

                try{
                    try {
                        String message = in.readUTF();
                        System.out.println(message);
                    }catch(SocketException e3){
                        System.exit(0);
                    }

                    //COLOCAR SPLIT

                    //COMANDOS PARA LEER EL MENSAJE
                } catch(SocketException se){
                    se.printStackTrace();
                }
            }


        } catch (Exception e){
            e.printStackTrace();
        }

    }
}
