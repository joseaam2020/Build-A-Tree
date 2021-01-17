 import java.net.*;
import java.io.*;

/**
 * Clase que crea el Server Socket
 */
public class Server implements Runnable {

    private int puerto = 5100;
    private static Server instance;
    private ServerSocket server;

    /**
     * Constructor privado para evitar la instanciacion
     */
    private Server(){

    }

    /**
     * Clase que retorna la instancia de la clase.
     * @return
     */
    public static Server getInstance(){
        if (instance == null){
            instance = new Server();
        }
        return instance;
    }

    /**
     * Obtiene el socket del server.
     * @return
     */
    public ServerSocket getServer() {
        return server;
    }

    /**
     * Metodo run para iniciar un thread que mantenga el servidor abierto para recibir informacion del cliente
     * en cualquier momento.
     */
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