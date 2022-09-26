/*
Jewel.cs - A classe Jewel deverá armazenar as informações da joia, como a posição (x, y) 
no mapa e o tipo, que poderá ser Red, no valor de 100 pontos;
Green, no valor de 50 pontos; e Blue, no valor de 10 pontos. 
*/

public class Jewel : Elemento{
    public readonly int pontos;
    readonly char type;
    public Jewel(char tipo,int x, int y): base(x,y){
        this.type = tipo;
        switch(tipo){
            case 'R':
                this.pontos = 100;
                break;
            case 'G':
                this.pontos = 50;
                break;
            case 'B':
                this.pontos = 10;
                this.energia = 5;
                break;
        }
    }
    public override string ToString(){
        if(this.type=='R'){
            return "JR";
        }else if(this.type =='B'){
            return "JB";
        }else{
            return "JG";
        }
    } 
}   