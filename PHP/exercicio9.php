<?php 

/* 9 - Faça um algoritmo que calcule o IMC (Índice de Massa Corporal) de uma pessoa,
 leia o seu peso e sua altura e imprima na tela sua condição de acordo com a tabela abaixo:

Fórmula do IMC = peso / (altura) ²

Tabela Condições IMC  

 Abaixo de 18,5   | Abaixo do peso          

 Entre 18,6 e 24,9 | Peso ideal (parabéns)  

 Entre 25,0 e 29,9 | Levemente acima do peso

 Entre 30,0 e 34,9 | Obesidade grau I 

 Entre 35,0 e 39,9 | Obesidade grau II (severa)

 Maior ou igual a 40 | Obesidade grau III (mórbida)*/

 class CalculadoraImc{

    private float $peso;
    private float $altura;

    public function __construct($peso,$altura){
        $this->peso = $peso;
        $this->altura = $altura;
    
    }

    public function calcularImc(): float{
        
        return $this->peso /  ($this->altura * $this->altura);
    }

    public function verificarEstado(): string {
        $indiceMassa =(float) $this->calcularImc();

        if($indiceMassa < 18.5){
            return "Você está abaixo do peso.";
        } else if ($indiceMassa <= 29.9){
            return "Parabéns seu peso é o ideal";
        } else if ($indiceMassa <= 34.9)   {
            return "Obesidade grau I, se cuide, pratique exercícios e se alimente bem.";
        } else if ($indiceMassa <= 35.9) {
            return "Obesidade grau II, procure um médico";
        } else{
            return "Atenção você está em obesidade mórbida procure um médico urgente";
        }

    }


 }    
 
echo "Informe seu peso:  ";
$pesoInformado = (float)trim(fgets(STDIN));
echo "Informe a altura ex 1.74: ";
$alturaInformada = (float)trim(fgets(STDIN));

$calculadoraImc = new CalculadoraImc($pesoInformado, $alturaInformada);

echo $calculadoraImc->verificarEstado();



?>