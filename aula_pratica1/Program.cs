Console.WriteLine("digita sua data de nascimento no formato dd/mm/aaaa");
int data = Int32.Parse( Console.ReadLine());
//Alteração realizada por Gabriel 1
if( data <= 2006 ){
    Console.WriteLine("pode votar");
}
else{
    Console.WriteLine("nao pode votar ");
// Outra alteração realizada por Gabriel 1  
}

