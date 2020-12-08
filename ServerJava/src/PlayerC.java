/**
 * Clase que lleva el control de los jugadores en la partida
 */
public class PlayerC {

    private int player_num;
    private int progress;
    private String tree;
    private int goal;
    private int points;

    /**
     * Constructor de la clase que recibe el numero de jugador.
     * @param num
     */
    public PlayerC(int num){
        this.player_num = num;
        this.progress = 0;
        System.out.println("Player "+String.valueOf(player_num)+" created");
    }

    /**
     * Asigna el valor al que el jugador debe de llegar con su progreso.
     * @param goal
     */
    public void setGoal(int goal) {
        this.goal = goal;
    }

    /**
     * Asigna el tipo de arbol que el jugador debe de armar
     * @param tree
     */
    public void setTree(String tree) {
        this.tree = tree;
    }

    /**
     * Lleva el progreso de vuelta a 0.
     */
    public void Reset(){
        this.progress = 0;
        SalidaMSG.getInstance().EnviarMensaje("RESET#"+String.valueOf(player_num));
    }

    /**
     * Aumenta el progreso cuando el jugador toma un token correcto.
     */
    public void TokenTaken(){
        this.progress += 1;
    }

    /**
     * Agrega los puntos al jugador cuando este gana.
     * @param won
     */
    public void addPoints(int won){
        this.points += won;
    }

    /**
     * Obtiene la cantidad de puntos del jugador
     * @return
     */
    public int getPoints() {
        return points;
    }

    /**
     * Obtiene el numero de jugador.
     * @return
     */
    public int getPlayer_num() {
        return player_num;
    }
}
