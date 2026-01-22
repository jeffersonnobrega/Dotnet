<?php 

/*5 - Faça um algoritmo que leia o valor do salário mínimo e o valor do salário de um usuário, 
calcule quantos salários mínimos esse usuário ganha e imprima na tela o resultado. (Base para o Salário mínimo R$ 1.293,20).

6 - Faça um algoritmo que leia um valor qualquer e imprima na tela com um reajuste de 5%.*/

class Salario {
    private float $valorSalario;
    private const SALARIO_MINIMO = 1293.20;
    
    public function __construct ( float $salarioInformado){
        $this->valorSalario = $salarioInformado;
    }
   
    public function CalcularQtd(): int {
        return (int) ($this->valorSalario / self::SALARIO_MINIMO);
        
    } 

   public function verificarSalario(): string
{
    if ($this->valorSalario > self::SALARIO_MINIMO && $this->CalcularQtd() < 2) {
        return 'O salário é um pouco maior que um salário mínimo';
    }

    return ' ';
}

    
    public function CalcularReajuste(): float{
        return ($this->valorSalario + ($this->valorSalario * 0.05));
    }
}

echo "Informe o salário do funcinonário: ";
$sal= (float) trim(fgets(STDIN));

$salario = new Salario($sal);

$resultado=$salario->CalcularQtd();
$resultadoReajuste=$salario->CalcularReajuste();
$mensagem = $salario->verificarSalario();


echo "O Salário informado corresponde a quantidade de {$resultado} salários minimos\n";
echo "O Salário informado com o reajuste é  {$resultadoReajuste}";
echo $mensagem;



?>