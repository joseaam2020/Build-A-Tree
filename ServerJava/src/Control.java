public class Control {

    private int players;
    private PlayerC players_ingame[];
    private String challenge;
    private static Control instance;
    private int time;
    private int goal;

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
        TimerThread timer = new TimerThread(time);
        timer.run();
    }

    public void setTime(int time) {
        this.time = time;
    }

    public int getTime() {
        return time;
    }

    public void setPlayers(int players) {
        this.players = players;
        players_ingame = new PlayerC[players];
        for (int i = 0; i< players; i++){
            PlayerC player = new PlayerC(i+1);
            players_ingame[i] = player;
            player.setGoal(this.goal);
            player.setTree(this.challenge);
        }
    }

    public void setChallenge(String challenge) {
        this.challenge = challenge;
    }

    public String getChallenge() {
        return challenge;
    }

    public void setGoal(int goal) {
        this.goal = goal;
    }

    public int getGoal() {
        return goal;
    }
}
