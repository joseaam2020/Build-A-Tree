import java.net.*;
import java.io.*;

public class Server implements Runnable {

    private int puerto = 5000;
    private static Server instance;
    private ServerSocket server;

    private Server(){

    }

    public static Server getInstance(){
        if (instance == null){
            instance = new Server();
        }
        return instance;
    }

    public ServerSocket getServer() {
        return server;
    }

    @Override
    public void run() {
        try{
            server = new ServerSocket(puerto);
            System.out.println("\n  Server abierto");

            while (true){
                Socket client = server.accept();

                Runnable start_con = new StartServer(client);
                Thread hilo = new Thread(start_con);
                hilo.start();
            }
        } catch (IOException e){
            e.printStackTrace();

        }    }
}