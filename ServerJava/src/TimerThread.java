/**
 * Clase que crea los hilos de los timers.
 */
public class TimerThread implements Runnable {

    private int time;
    private String type;

    /**
     * Constructor que recibe el tiempo del timer y si es para challenge o la partida.
     * @param time
     * @param type
     */
    public TimerThread(int time, String type){
        this.time = time;
        this.type = type;
    }

    /**
     * Metodo que permite iniciar los threads.
     */
    @Override
    public void run() {

        Runnable timer = new TimerClass(time,type);
        Thread timer_th= new Thread(timer);
        timer_th.start();
    }
}
