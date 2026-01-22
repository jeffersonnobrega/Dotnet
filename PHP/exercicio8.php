<?php 

/*8 - Faça um algoritmo que leia três valores inteiros diferentes e imprima na tela os valores em ordem decrescente.*/
class OrganizadorDeNumeros {

    private int $v1;
    private int $v2;
    private int $v3;

    public function __construct(int $v1, int $v2, int $v3){
        $this->v1 = $v1;
        $this->v2 = $v2;
        $this->v3 = $v3;
    }

    public function ordenar() {
        $valores = [$this->v1, $this->v2, $this->v3];

        rsort($valores);

        for($i=0; $i<count($valores); $i++){
            echo $valores[$i] . PHP_EOL;
        }
    }

    
}


echo "Inform o primeiro valor: ";
$numero1 = (int) trim(fgets(STDIN));

echo "Inform o primeiro valor: ";
$numero2 = (int) trim(fgets(STDIN));

echo "Inform o primeiro valor: ";
$numero3 = (int) trim(fgets(STDIN));

$organizadordeNumeros = new OrganizadorDeNumeros($numero1, $numero2, $numero3);

echo "O números organizados ficam da seguinte forma:\n";
$mensagem = $organizadordeNumeros->ordenar();






?>