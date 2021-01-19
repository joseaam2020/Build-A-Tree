import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.net.Socket;
import java.net.SocketException;

/**
 * Clase que crea el hilo que mantiene abiierto el server.
 */
public class StartServer implements Runnable{

    private Socket socket;
    private DataInputStream in;
    private DataOutputStream out;

    /**
     * Constructor que recibe un socket, el cual tiene la conexion.
     * @param soc
     */
    public StartServer(Socket soc){
        this.socket = soc;
        SalidaMSG.getInstance().setConnection(soc);
    }

    /**
     * Metodo que se inicia al llamar el thread para mantenerse a la escucha del cliente constantemente, se encarga
     * de leer los mensajes e interpretarlos segun lo que venga.
     */
    @Override
    public void run() {

        try{
            out = new DataOutputStream(socket.getOutputStream());
            in = new DataInputStream(socket.getInputStream());

            while(true){

                try{

                    byte[] lenBytes = new byte[4];
                    in.read(lenBytes, 0, 4);
                    int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) |
                            ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
                    byte[] receivedBytes = new byte[len];
                    in.read(receivedBytes, 0, len);
                    String received = new String(receivedBytes, 0, len);

                    String command[] = received.split("#");
                    if (command[0].equals("GETCHALLENGE")) {
                        Challenge challenge = new Challenge();
                        Control.getInstance().setPlayers(Integer.parseInt(command[1]));
                        System.out.println("Recibido: "+command[0]);
                    }
                    if(command[0].equals("STARTGAME")){
                        Control.getInstance().setGame_time1(984);
                        System.out.println("Recibido: "+command[0]);
                    }
                    if (command[0].equals("TOKEN")){
                        //RECIBE TOKEN#JUGADOR#FORMA QUE AGARRO
                        Control.getInstance().verifyToken(Integer.parseInt(command[1]),command[2]);
                        System.out.println("Recibido: "+command[0]);
                    }
                } catch(SocketException se){
                    System.exit(0);
                }
            }


        } catch (Exception e){
            e.printStackTrace();
        }

    }
}
