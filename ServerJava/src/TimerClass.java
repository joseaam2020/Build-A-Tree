import java.util.Timer;
import java.util.TimerTask;

public class TimerClass {

    private Timer timer = new Timer();
    private int time;

    public void CountTime(int limit){
        this.time = limit;
        TimerTask count = new TimerTask() {
            @Override
            public void run() {

                if (time >= 0){
                    SalidaMSG.getInstance().EnviarMensaje(String.valueOf(time));
                    time--;
                    Control.getInstance().setTime(time);
                    //System.out.println(time);
                } else{
                    timer.cancel();
                    SalidaMSG.getInstance().EnviarMensaje("El tiempo ha acabado");
                }
            }
        };
        timer.schedule(count,0,1000);
    }
}
