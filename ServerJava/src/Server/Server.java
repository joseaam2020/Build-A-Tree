package Server;

import java.net.*;
import java.io.*;

public class Server implements Runnable {

    private int puerto = 5345;


    @Override
    public void run() {
        try{
            ServerSocket server = new ServerSocket(puerto);
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