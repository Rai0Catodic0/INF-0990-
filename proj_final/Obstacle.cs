/*
Obstacle.cs - A classe Obstacle deverá armazenar as informações
do obstáculo, que será a posição (x, y) e o tipo. Cada obstáculo
deverá possuir um tipo, que poderá ser Water ou Tree.
*/

public class Obstacle:Elemento{
    readonly  Char type;
    public Obstacle(char tipo, int x, int y):base(x,y){
        this.type = tipo;
    }
    public override string ToString(){
        if(this.type=='W'){
            return "##";
        }
        this.energia = 3;
        return "$$";
    }
}