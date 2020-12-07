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
        SalidaMSG.getInstance().setConnection(soc);
    }

    @Override
    public void run() {

        try{
            out = new DataOutputStream(socket.getOutputStream());
            in = new DataInputStream(socket.getInputStream());

            while(true){

                try{

                    byte[] lenBytes = new byte[4];
                    in.read(lenBytes, 0, 4);
                    int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) | ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
                    byte[] receivedBytes = new byte[len];
                    in.read(receivedBytes, 0, len);
                    String received = new String(receivedBytes, 0, len);
                    System.out.println("Recibido "+received);
                    String command[] = received.split("#");
                    if (command[0].equals("GETCHALLENGE")) {
                        Challenge challenge = new Challenge();
                        Control.getInstance().setPlayers(Integer.parseInt(command[1]));
                    } else {

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
