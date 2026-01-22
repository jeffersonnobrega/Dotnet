<?php 

class Calculadora {
    private int $a; //atributo privado
    private int $b;
    private int $c;
    
   // --------------------------------------------
    // MÉTODO CONSTRUTOR (__construct)
    // É executado automaticamente quando usamos "new Calculadora()"
    // Serve para inicializar valores da classe no momento da criação do objeto.
   public function __construct(int $a, int $b, int $c){
        $this->a = $a; // "$this->" significa "este objeto"
        $this->b = $b; 
        $this->c = $c; 

   }

   // MÉTODO: Calcula a soma
    // Métodos são "funções dentro de uma classe".
    // --------------------------------------------

    public function somar(){
        return $this->a + $this->b;
    }

    public function verifica(): bool{
        return $this-> somar() < $this->c;
    }


    //Metodo exibir resultados

    public function resultados(): void{
        $soma = $this->somar();

        echo"A soma dos resultados a: {$this->a} + b: {$this->b} é $soma\n";

        if($this->verifica()){
            echo "A Soma de A: {$this->a} + B:{$this-> b} é menor que C: {$this->c} \n";
        } else {
            echo "A soam de A e B não é menor que C";
        }

        
    }

}


// --------------------------------------------------
// PROGRAMA PRINCIPAL (fora da classe)
// Aqui é onde pedimos dados ao usuário via console.
// --------------------------------------------------

echo "Digite o valor A: ";
$a = (int) trim(fgets(STDIN));   // recebendo int

echo "Digite o valor B: ";
$b = (int) trim(fgets(STDIN));   // recebendo int

echo "Digite o valor C: ";
$c = (int) trim(fgets(STDIN));   // recebendo int

// Criamos um OBJETO da classe Calculadora
$calc = new Calculadora($a, $b, $c);

$calc->resultados();
?>