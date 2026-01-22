<?php 
/*2 - Faça um algoritmo para receber um número qualquer e 
imprimir na tela se o número é par ou ímpar, positivo ou negativo. 

3 - Faça um algoritmo que leia dois valores inteiros A e B, 
se os valores de A e B forem iguais, deverá somar os dois valores, 
caso contrário devera multiplicar A por B. Ao final de qualquer um dos 
cálculos deve-se atribuir o resultado a uma variável C e imprimir seu valor na tela.*/
 class Calculadora{

    private int $a;
    private int $b;
    private int $c;

    public function __construct(int $a, int $b) {
        $this->a = $a;
        $this->b = $b;
        
    }

    public function somar() {
        return $this->a + $this->b;
    }

    public function somarouMultiplicar() {

        if ($this->a == $this->b){
        return $this->a + $this->b;
        } else {
             return $this->a * $this->b;
        }
    }

   //verificar se é positivo ou negativo par ou impar

    private function parouImpar(int $n): string{
        return($n % 2 == 0) ? "par" : "ímpar";
    }

    private function positivoNegativo(int $n): string {
        return($n>0) ? "positivo" : "negativo";
    }

  
    public function verificar(): void{
       echo "{$this->a} é " . $this->parouImpar($this->a) . " e " . $this->positivoNegativo($this->a) . "!\n";
       echo "{$this->b} é " . $this->parouImpar($this->b) . " e " . $this->positivoNegativo($this->b) . "!\n"; 
       

       
    }



      public function imprimir(): void{
        echo "Foram recebidos os números {$this->a} e {$this->b}\n";
        $this->verificar();
        echo "-----------------------------\n";
        $c = $this->somarouMultiplicar();
        echo "O Restultado do cálculo é : $c\n";

       }
 

}

   echo "Informe a primeiro número: ";
    $a = (int) trim(fgets(STDIN));   // recebendo int
    echo 'Informe o segundo número: ';
    $b = (int) trim(fgets(STDIN));   // recebendo int
    
    $calc = new Calculadora($a, $b);

    
    $calc->imprimir();

?>