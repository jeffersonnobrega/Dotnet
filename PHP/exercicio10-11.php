<?php 
/* 10 - Faça um algoritmo que leia três notas obtidas por um aluno, e imprima na tela a média das notas.

  11 - Faça um algoritmo que leia quatro notas obtidas por um aluno, calcule a média das nota obtidas, imprima na tela o nome do aluno e 

 se o aluno foi aprovado ou reprovado. Para o aluno ser considerado aprovado sua média final deve ser maior ou igual a */

class Aluno {
    private string $nome;
    private float $nota1;
    private float $nota2;
    private float $nota3;
    private float $nota4;

    public function __construct($nome,$nota1,$nota2,$nota3,$nota4){
       $this->nome = $nome;
       $this->nota1 = $nota1;
       $this->nota2 = $nota2;
       $this->nota3 = $nota3;
       $this->nota4 = $nota4;
    }

    public function getMedia(): float{
        return ($this->nota1 + $this->nota2 + $this->nota3 + $this->nota4) / 4;
    }

    public function getAprovacao(): bool{
        if ($this->getMedia() >= 7){
            return true;
        } else {
            return false;
        }
    }

    public function getNome(): string{
        return $this->nome;
    }

    public function printStatus(): void{
        $media = $this->getMedia();
        if ($this->getAprovacao() == true) {
            echo "{$this->nome} foi aprovado com a média: {$media}";
        } else {
        echo "{$this->nome} foi reprovado com a média: {$media}";
        }
    }    

} 

echo "Informe o nome do aluno: ";
$nome = trim(fgets(STDIN));
echo"Informe a primeira nota: ";
$nota1 = (float)trim(fgets(STDIN));
echo"Informe a segunda nota: ";
$nota2 = (float)trim(fgets(STDIN));
echo"Informe a terceira nota: ";
$nota3 = (float)trim(fgets(STDIN));
echo"Informe a quarta nota: ";
$nota4 = (float)trim(fgets(STDIN));

 $aluno = new Aluno($nome,$nota1,$nota2,$nota3,$nota4);
 

 $aluno->printStatus();

?>

