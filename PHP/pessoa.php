<?php 

class Pessoa{
    public $nome; //atributo
    public $idade;

    //metodo 

    public function saudacao(){
        return 'Olá, meu nome é ' . $this->nome; //this pq nome está fora
    }
}

//instanciar o objeto

$pessoa = new Pessoa();
$pessoa->nome = 'Jefferson';

echo $pessoa->saudacao();

?>