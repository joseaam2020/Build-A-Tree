public class TimerThread implements Runnable {

    private int time;

    public TimerThread(int time){
        this.time = time;
    }

    @Override
    public void run() {

        Runnable timer = new TimerClass(time);
        Thread timer_th= new Thread(timer);
        timer_th.start();
    }
}
