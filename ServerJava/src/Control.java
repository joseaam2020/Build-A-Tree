import java.sql.Time;
import java.util.TimerTask;

public class Control {

    private int players;
    private static Control instance;
    private int time;

    private Control(){

    }

    public static Control getInstance(){
        if (instance == null){
            instance = new Control();
        }
        return instance;
    }

    public void setTime1(int time) {
        this.time = time;
        TimerClass timer = new TimerClass();
        timer.CountTime(time);
    }

    public void setTime(int time) {
        this.time = time;
    }

    public void setPlayers(int players) {
        this.players = players;
    }
}
