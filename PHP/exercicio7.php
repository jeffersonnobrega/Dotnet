<?php 
/*7 - Faça um algoritmo que leia dois valores booleanos (lógicos) e determine se ambos são VERDADEIRO ou FALSO.*/

class Analisador {
    private bool $valor1;
    private bool $valor2;
    public function __construct(string $entrada1, string $entrada2){
        $this->valor1 =$this->converterParaBool($entrada1);
        $this->valor2 =$this->converterParaBool($entrada2);
        
    }   

    public function converterParaBool(string $dadosRecebidos): bool {
        // Converte para maiúsculo para aceitar "v" ou "V"
        $entrada = strtoupper(trim($dadosRecebidos));
        // operador ternário condition ? expr1 : expr2 
        return $entrada === "V";

    }


    public function verificarseValido(): string{
        //verificação conforme tabela da verdade
        if($this->valor1 === true && $this->valor2 === true){
         return "Os valores são Verdadeiros";
        } else {
            return "Os valores são falsos";
        }
    }
    
    
}

echo "Informe o primeiro valor: ";
$primeiroValor = trim(fgets(STDIN));
echo "Informe o segundo valor: ";
$segundoValor = trim(fgets(STDIN));

$analisador = new Analisador($primeiroValor, $segundoValor);

$mensagem=$analisador->verificarseValido();

echo "{$mensagem}";


?>