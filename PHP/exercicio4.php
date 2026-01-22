<?php

/*4 - Faça um algoritmo que receba um número inteiro e imprima na tela o seu antecessor e o seu sucessor.*/

/*
 A classe Número representa um objeto que guarda um único valor inteiro
 e fornece métodos para trabalhar com esse valor.
*/
class Numero{

    /*
        ENCAPSULAMENTO:
        ----------------
        O atributo $num é private.
        Isso significa que somente métodos dentro da classe podem acessá-lo.
        Esse é um exemplo de encapsulamento: esconder detalhes internos do objeto.
    */
    private int $num;

    /*
        CONSTRUTOR:
        -----------
        Método especial chamado automaticamente quando usamos "new Numero(...)".

        Ele serve para inicializar o estado do objeto.
        Aqui, o valor passado ($num) é guardado dentro do atributo privado $this->num.
    */
    public function __construct(int $num){
        $this->num = $num;
    }

    /*
        MÉTODO PÚBLICO:
        ----------------
        Esse método pode ser chamado por qualquer código externo.

        Ele retorna um array contendo o antecessor e o sucessor do número.
        Também demonstra ENCAPSULAMENTO porque acessa o atributo privado $this->num
        de forma controlada.
    */
    public function verificar(): array {
        return [
            // "chave => valor"
            'Antecessor' => $this->num - 1,
            'Sucessor'   => $this->num + 1,
        ];
    }
}


/*
    Entrada de dados:
    -----------------
    Lê um número digitado pelo usuário no terminal.
*/
echo "Informe um número: ";
$num = (int) trim(fgets(STDIN));

/*
    INSTÂNCIA / OBJETO:
    --------------------
    Aqui é criado um objeto da classe Numero.
    Isso é instanciar uma classe: transformar o modelo (classe)
    em algo concreto (objeto).
*/
$numero = new Numero($num);

/*
    CHAMADA DE MÉTODO:
    -------------------
    O método verificar() é chamado no objeto $numero.
    Ele devolve um array com os resultados.
*/
$resultado = $numero->verificar();

/*
    IMPRESSÃO DOS RESULTADOS:
    -------------------------
    Acessamos as chaves do array retornado pelo método.
*/
echo "Antecessor: {$resultado['Antecessor']}\n";
echo "Sucessor: {$resultado['Sucessor']}\n";

?>
