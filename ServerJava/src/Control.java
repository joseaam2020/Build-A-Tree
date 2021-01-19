/**
 * Clase control que controla lo que ocurre en la partida.
 */
public class Control {

    private int players;
    private PlayerC players_ingame[];
    private String challenge;
    private static Control instance;
    private int game_time;
    private int time;
    private int goal;
    private String shape;
    private int points = 100;

    /**
     * Constructor privado para evitar instanciacion.
     */
    private Control(){

    }

    /**
     * Metodo para obtener la instancia de la clase Control
     * @return Control instance
     */
    public static Control getInstance(){
        if (instance == null){
            instance = new Control();
        }
        return instance;
    }

    /**
     * Da un valor inicial al tiempo y comienza un thread con timer para el challenge.
     * @param time
     */
    public void setTime1(int time) {
        this.time = time;
        TimerThread timer = new TimerThread(time,"CHALLENGETIMER");
        timer.run();
    }

    /**
     * Actualiza el tiempo restante.
     * @param time
     */
    public void setTime(int time) {
        this.time = time;
    }

    /**
     * Obtiene el tiempo restante
     * @return
     */
    public int getTime() {
        return time;
    }

    /**
     * Asigna el numero de jugadores y les crea los perfiles dentro de la clase.
     * @param players
     */
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

    /**
     * Asigna el challenge para la partida
     * @param challenge
     */
    public void setChallenge(String challenge) {
        this.challenge = challenge;
    }

    /**
     * Obtiene el challenge asignado
     * @return
     */
    public String getChallenge() {
        return challenge;
    }

    /**
     * Asigna la cantidad de tokens que deben obtener los jugadores
     * @param goal
     */
    public void setGoal(int goal) {
        this.goal = goal;
    }

    /**
     * Obtiene la cantidad de tokens que deben obtener los jugadores.
     * @return
     */
    public int getGoal() {
        return goal;
    }

    /**
     * Asigna el valor del tiempo para la partida.
     * @param game_time
     */
    public void setGame_time1(int game_time) {
        this.game_time = game_time;
        TimerThread timer = new TimerThread(game_time,"GAMETIMER");
        timer.run();
    }

    /**
     * Actualiza el valor del timepo para la partida.
     * @param game_time
     */
    public void setGame_time(int game_time){
        this.game_time = game_time;
    }

    /**
     * Asigna la forma del token que deben tener los jugadores.
     * @param shape
     */
    public void setShape(String shape) {
        this.shape = shape;
    }

    /**
     * Obtiene la forma del token que deben recoger los jugadores.
     * @return
     */
    public String getShape() {
        return shape;
    }

    /**
     * Verifica la forma del token con la que el jugador agarro.
     * @param player_i
     * @param shape
     */
    public void verifyToken(int player_i,String shape){

        if (shape.equals(this.shape)){
            players_ingame[player_i].TokenTaken();
        } else{
            players_ingame[player_i].Reset();
        }

    }

    /**
     * Metodo para cuando se acaba el challenge activo y entregar puntos a un jugador.
     */
    public void ChallengeEnd(){
        int p_points[] = new int[players_ingame.length-1];
        for (int i = 0; i!=players_ingame.length; i++){
            p_points[i] = players_ingame[i].getPoints();
        }
        PlayerC ganador = null;
        int mayor = 0;
        for (int i = 0; i!=p_points.length; i++){
            if (players_ingame[i].getPoints() > mayor) {
                mayor = players_ingame[i].getPoints();
                ganador = players_ingame[i];
            }
        }
        SalidaMSG.getInstance().EnviarMensaje("CWINNER#"+String.valueOf(ganador.getPlayer_num()));
    }
}
