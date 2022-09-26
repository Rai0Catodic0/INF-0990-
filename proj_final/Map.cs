public class Map{
    Elemento [,] mapa;
    int i_max;
    int j_max;
    Robot robo; 
    public readonly List<Jewel> joias;
    public event EventHandler FimDeJogo;
    protected virtual void OnFimDeJogo(EventArgs e){
        FimDeJogo?.Invoke(this, e);
    }
    public Map(Jewel[] joias, Obstacle[] obsatulos, Robot robo,int i_max,int j_max){
        this.mapa = new Elemento[i_max, j_max];
        this.joias = joias.ToList();
        this.i_max = i_max;
        this.j_max = j_max;
        for(int i = 0; i < joias.Length;i++){
            this.mapa[joias[i].x,joias[i].y] = joias[i];
        }for(int i = 0; i < obsatulos.Length;i++){
            this.mapa[obsatulos[i].x,obsatulos[i].y] = obsatulos[i];
        }
        this.robo = robo;
        this.mapa[robo.x,robo.y] = robo;
    }
    public void printMap(){
        for(int i=0;i<i_max;i++){
            for(int j=0;j<j_max;j++){
                if(this.mapa[i,j] == null){
                    Console.Write("--");
                }else{
                    Console.Write(mapa[i,j].ToString());
                }
                Console.Write(" ");
            }
            Console.Write("\n");
        }
    }
    public void procura_joia(int x,int y){
        Jewel joia = null;
        if(x<i_max-1){
            if(mapa[y,x+1] is Jewel){
                joia = (Jewel)mapa[y,x+1];
            }
        }
        if(x>1){
             if(mapa[y,x-1] is Jewel){
                joia = (Jewel)mapa[y,x-1];
            }
        }if(y<j_max-1){
            if(mapa[y+1,x] is Jewel){
                joia = (Jewel)mapa[y+1,x];
            }
        }
        if(y>1){
            if(mapa[y-1,x] is Jewel){
                joia = (Jewel)mapa[y-1,x];
            }
        }
        if (joia != null){
            robo.coletar(joia);
            updateColeta(joia.x,joia.y);
        }
                    
    }
      public void procura_arvore(int x,int y){
        if(x<9 && mapa[y,x+1]?.ToString() == "$$"){
            robo.recarregar(mapa[y,x+1]);
            this.mapa[y,x+1] = null;
        }else if(x>1 && mapa[y,x-1]?.ToString() == "$$"){
            robo.recarregar(mapa[y,x-1]);
            this.mapa[y,x-1] = null;
        }if(y<9 && mapa[y+1,x]?.ToString() == "$$"){
            robo.recarregar(mapa[y+1,x]);
            this.mapa[y+1,x] = null;
        }else if(y>1 && mapa[y-1,x]?.ToString() == "$$"){
            robo.recarregar(mapa[y-1,x]);
            this.mapa[y-1,x] = null;
        }
 }

    public void mover(Robot robo, int x_anterior,int y_anterior){
        if(robo.energia > 0){
            if(temObstaculo(robo.x,robo.y)){
                robo.energia -= 1;
                this.mapa[robo.y,robo.x] = robo;
                this.mapa[y_anterior,x_anterior] = null; 
            }else{
                throw new Exception("Movimento invalido");
            }   
        }else{
            Console.WriteLine("fim de jogo");
            OnFimDeJogo(EventArgs.Empty);
        }
    }
    public void updateColeta(int x, int y){
        Console.WriteLine($"joia coletada em x:{x},y:{y}");
        Jewel joia = (Jewel)this.mapa[x,y];
        this.mapa[x,y] = null;
        this.joias.Remove(joia);
    }
    public bool temObstaculo(int x,int y){

        if((x >= 0 && y >= 0 )&&(x < 10 && y < 10 )){
            Console.WriteLine("movimento valido");
            if(this.mapa[y,x] is not Elemento){
                return true;
            }
        }
        Console.WriteLine("movimento invalido");  
        
        return false;
    }
}