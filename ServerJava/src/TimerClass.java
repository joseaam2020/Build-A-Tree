import java.util.Timer;
import java.util.TimerTask;
import java.util.Random;

/**
 * Clase que crea los timers para challenge y la partida.
 */
public class TimerClass implements Runnable{

    private Timer timer = new Timer();
    private int time;
    private String what;
    private Random rand = new Random();

    /**
     * Constructor que recibe el valor del tiempo y si es un timer de un challenge o la partida en general.
     * @param time
     * @param what
     */
    public TimerClass(int time, String what){
        this.time = time;
        this.what = what;
    }

    /**
     * Metodo que se llama al iniciar el thread del timer y lleva el conteo del tiempo asi como envia mensajes cada segundo
     * y maneja el spawn de tokens y poderes.
     */
    @Override
    public void run() {
        if (what.equals("CHALLENGETIMER")) {
            TimerTask count = new TimerTask() {
                @Override
                public void run() {

                    if (time >= 0) {
                        if (time % 4 == 0) {
                            TokenGen.getInstance().SelectRandomToken();
                        }
                        if (time % 14 == 0){
                            int power = rand.nextInt(3);
                            SalidaMSG.getInstance().EnviarMensaje("POWER#"+power);
                        }
                        String time_string = Integer.toString(time);
                        SalidaMSG.getInstance().EnviarMensaje("CHALLENGETIME#"+time_string);
                        time--;
                        Control.getInstance().setTime(time);
                    } else {
                        timer.cancel();
                        Control.getInstance().ChallengeEnd();
                        Control.getInstance().setTime(0);
                    }
                }
            };
            timer.schedule(count, 0, 1000);
        } else{
            TimerTask game_time = new TimerTask() {
                @Override
                public void run() {

                    if (time >= 0) {
                        String time_string = Integer.toString(time);
                        SalidaMSG.getInstance().EnviarMensaje("GAMETIME#"+time_string);
                        time--;
                        Control.getInstance().setGame_time(time);
                    } else {
                        timer.cancel();
                        Control.getInstance().setGame_time(0);
                    }
                }
            };
            timer.schedule(game_time, 0, 1000);
        }

    }
}
