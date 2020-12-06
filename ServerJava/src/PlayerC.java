public class PlayerC {

    private int player_num;
    private int progress;
    private String tree;
    private int goal;

    public PlayerC(int num){
        this.player_num = num;
        this.progress = 0;
        System.out.println("Player "+String.valueOf(player_num)+" created");
    }

    public void setGoal(int goal) {
        this.goal = goal;
    }

    public void setTree(String tree) {
        this.tree = tree;
    }

    public void Reset(){
        this.progress = 0;
    }

}
