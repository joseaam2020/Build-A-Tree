import java.util.Timer;
import java.util.TimerTask;

public class TimerClass implements Runnable{

    private Timer timer = new Timer();
    private int time;

    public TimerClass(int time){
        this.time = time;
    }

    @Override
    public void run() {
        TimerTask count = new TimerTask() {
            @Override
            public void run() {

                if (time >= 0){
                    if (time%3 == 0){
                        TokenGen.getInstance().SelectRandomToken();
                    }
                    String time_string = Integer.toString(time);
                    SalidaMSG.getInstance().EnviarMensaje(time_string);
                    time--;
                    Control.getInstance().setTime(time);
                } else{
                    timer.cancel();
                    SalidaMSG.getInstance().EnviarMensaje("El tiempo ha acabado");
                }
            }
        };
        timer.schedule(count,0,1000);

    }
}
