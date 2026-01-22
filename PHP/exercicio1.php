<?php 

//1 - Faça um algoritmo que leia os valores de
//  A, B, C e em seguida imprima na tela a soma entre A e B 
// é mostre se a soma é menor que C.



echo 'Digite a o valor A: ';
$a = (int) trim(fgets(STDIN));

echo 'Digite a o valor B: ';
$b= (int) trim(fgets(STDIN));

echo 'Digite a o valor C: ';
$c = (int) trim(fgets(STDIN));



$soma = $a + $b;

echo "\nA soma de $a + $b = $soma\n";

if($soma < $c) {
    
     echo "E é menor que C: $c\n";
}

?>