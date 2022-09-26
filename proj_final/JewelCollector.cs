/*
JewelCollector.cs - A classe JewelCollector deverá ser responsável por
implementar o método Main(), criar o mapa, inserir as joias,
obstáculos, instanciar o robô e ler os comandos do teclado. Para que
o usuário possa controlar o robô, os seguintes comandos deverão ser
passados através das teclas w, s, a, d, g. Sendo que a tecla w desloca
o robô para o norte, a tecla s desloca para o sul, a tecla a desloca
para oeste e a tecla d para leste. Para coletar uma joia, use a tecla g. 
*/
public class JewelCollector{
    

    static public (Map,Robot) criarmapa(int i_max,int j_max){
        List<Jewel> joias = new List<Jewel>();
        List<Obstacle> Lobstaculos = new List<Obstacle>();
        Random rnd = new Random();
        int n_trees = 5*i_max/10;
        int n_water = 7*i_max/10;
        int n_joias = i_max*2/10;
        for(int i = 0;i < n_trees;i++){
            Lobstaculos.Add(new Obstacle('t',rnd.Next(0,i_max),rnd.Next(0,i_max)));    
        }for(int i = 0; i < n_water; i++){
            Lobstaculos.Add(new Obstacle('W',rnd.Next(0,i_max),rnd.Next(0,i_max)));
        }
        for(int i = 0; i < n_joias;i++){
            joias.Add(new Jewel('G',rnd.Next(0,i_max),rnd.Next(0,i_max)));
            joias.Add(new Jewel('R',rnd.Next(0,i_max),rnd.Next(0,i_max)));
            joias.Add(new Jewel('B',rnd.Next(0,i_max),rnd.Next(0,i_max)));
        }
        Robot robot = new Robot(0,0,joias.Count());
        Map m = new Map(joias.ToArray(),Lobstaculos.ToArray(),robot,i_max,j_max);
        return (m,robot);
    }
    static public void Main(){
        Jewel[] joias = { new Jewel('R',1, 9),new Jewel('R', 8, 8),new  Jewel('G',9, 1),
                        new  Jewel('G',7, 6),new Jewel('B', 3, 4),new Jewel('B',2,1)
                        }; 
        Obstacle [] obstaculos = { new Obstacle('W',5,0),new Obstacle('W',5,1),new Obstacle('W',5,2),
                                   new Obstacle('W',5,3),new Obstacle('W',5,4),new Obstacle('W',5,5),
                                   new Obstacle('W',5,6),new Obstacle('t',5,9),new Obstacle('t',3,9),
                                   new Obstacle('t',8,3),new Obstacle('t',2,5),new Obstacle('t',1,4),

                                 };
        List<Obstacle> Lobstaculos = obstaculos.ToList();
        Robot robot = new Robot(0,0,joias.Length);
        Map m = new Map(joias,obstaculos,robot,10,10);
        for(int j = 11; j<30; j++){
            int estado_do_jogo = 0; 
            do {
                m.printMap();
                Console.WriteLine(robot.BagToString());

                Console.WriteLine("Enter the command:");
                string command = Console.ReadLine();    

                if (command.Equals("quit") ) {
                    estado_do_jogo = -1;
                }else if(m.joias.Count == 0){
                    estado_do_jogo = 1;
                } else if (command.Equals("w")) {
                    int y_anterior = robot.y;
                    robot.y -= 1;
                    try{
                        m.mover(robot, robot.x,y_anterior);
                    }catch(Exception e ){
                        Console.WriteLine(e);
                    }

                } else if (command.Equals("a")) {
                    int x_anterior = robot.x;
                    robot.x -= 1;
                    try{
                        m.mover(robot, x_anterior,robot.y);
                    }catch(Exception e){
                        Console.WriteLine(e);
                    }


                } else if (command.Equals("s")) {
                    int y_anterior = robot.y;
                    robot.y += 1;
                    try{
                        m.mover(robot, robot.x,y_anterior);
                    }catch(Exception e ){
                        Console.WriteLine(e);
                    }
                } else if (command.Equals("d")) {
                
                    int x_anterior = robot.x;
                    robot.x += 1;
                    try{
                        m.mover(robot, x_anterior,robot.y);
                    }catch(Exception){
                        Console.WriteLine("Movimento invalido");
                    }

                } else if (command.Equals("g")) {
                    m.procura_joia(robot.x,robot.y);
                    m.procura_arvore(robot.x,robot.y);                 
                }
            } while (estado_do_jogo == 0);
            if(estado_do_jogo == 1){
                Console.WriteLine($"Parabens! Você concluiu o nivel{j-10}");
            }else{
                Console.WriteLine("Fim de Jogo, Boa sorte na proxima");
                break;
            }
            (m, robot) = criarmapa(j,j);
        }
  }
}