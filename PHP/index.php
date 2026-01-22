<?php //assim abrimos um codigo php

//IMPRIMIR
echo 'Nóbrega Tecnologia';
print 'Jefferson';

//DECLARAÇÃO DE VARIAVEIS E SEUS TIPOS
$pai = 'Jefferson';
$nome = 'Luna'; // string
$idade = 2; // int
$peso = 11.6; // flota
$booleana = false; //boolean

var_dump($nome); // mostra o tipo de variável
echo "<br>"; // pula uma linha
//concatenação de variáveis
echo $pai . ' é pai da ' . $nome . ' e ela tem ' . $idade . ' pesa ' . $peso . ' kg'; 
echo "<br>";

//FUNÇÕES

function imprimir ($funcao,){
    return "Olá, $funcao";
}

echo imprimir('Eu sou uma função');

echo "<br>";

function dados ($linguagem,$ano){
    return "Essa é a linguagem: $linguagem, apredendo em $ano";
}

echo dados('PHP', 2025);

echo '<br>';

//array simples

$familia = ['Jefferson', 'Raiane', 'Luna'];

print_r($familia);
echo '<br>';

foreach($familia as $pessoa){
    echo $pessoa . '<br>';
}
echo '<br>';    

//array associativo

//$gasto = [10 => 'Crédito', 20.5 => 'Débito', 99 => 'PIX'];
//perceba que acima o 20.5 é float, mas não é permitido dentro de um array como valor chave
//então temos duas formas de contornar primeira abaixo:

  $gasto = [10 => 'Crédito', '20.5' => 'Débito', 99 => 'PIX'];  //transformei em string

foreach($gasto as $gastos => $categoria){
    echo 'Gasto de R$: ' . $gastos . '  passado no ' . $categoria . '<br>';
}

echo '<br>';

//segunda forma de contornar:
// PHP aceita qualquer tipo como valor: int, float, string, boolean, array, objeto
$gasto2 = [
    ['valor' => 10, 'categoria' => 'Crédito'],
    ['valor' => 20.5, 'categoria' => 'Débito'],
    ['valor' => 99, 'categoria' => 'PIX']
];

foreach ($gasto2 as $item) {
    echo 'Gasto de R$: ' . $item['valor'] . ' passado no ' . $item['categoria'] . '<br>';
}

// o que fiz acima foi dentro do array adicionar outro arry individual para cada valor

echo '<b>' . 'uma classe é um modelo ou plano para que você possa criar objetos <br> e os objetos
são a instância da classe.'

?>