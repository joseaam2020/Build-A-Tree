import Server.SalidaMSG;

import java.util.Timer;
import java.util.TimerTask;

public class TimerClass {

    private Timer timer = new Timer();
    private int time = 0;

    public void CountTime(int limit){
        TimerTask count = new TimerTask() {
            @Override
            public void run() {

                if (time <= limit){
                    time++;
                } else{
                    timer.cancel();
                    time = 0;
                    SalidaMSG.getInstance().EnviarMensaje("El tiempo ha acabado");
                }
            }
        };
        timer.schedule(count,0,1000);
    }
}
