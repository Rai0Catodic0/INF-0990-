/*
Robot.cs - A classe Robot deverá ser responsável por armazenar as
informações do robô, que será a posição (x, y) e uma sacola (bag),
em que o robô colocará as joias coletadas no mapa. Além disso,
a classe Robot deverá implementar os métodos para que o robô possa
interagir com o mapa, isto é, deslocar-se nas quatro direções e
coletar as joias. Além disso, implemente um método para imprimir na
tela o total de joias armazenadas na sacola e o valor total. 
*/

public class Robot : Elemento{
    Jewel [] sacola;
    public int energia;
    public Robot(int x,int y, int max_joias) : base(x,y){
        energia = 5;
        sacola = new Jewel[max_joias];
    }
    public override string ToString()
    {
        return "ME";
    }

    public void andar(int x, int y){
        this.x = x;
        this.y = y;
        energia -= 1;
    }
    public void recarregar(Elemento e){
        energia += e.energia;
    }

    public Jewel[] coletar(Jewel joia){
        int i;
        for (i = 0;i<sacola.Length;i++){
            if(sacola[i] == null){
                break;
            }
        }
        this.recarregar(joia);
        sacola[i] = joia;
        return this.sacola;
    }
    public string BagToString(){
        int n_joias;
        int v_joias = 0;
        for(n_joias = 0; n_joias<this.sacola.Length;n_joias++){
            if(sacola[n_joias]== null){
                break;
            }
            v_joias += sacola[n_joias].pontos;
        
        }
        return $"Bag total items:{n_joias} | Bag total value:{v_joias}\nenergia:{this.energia}";
    }
}