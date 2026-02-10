# WEB API com .NET 8 e SQL Server | CRUD + Repository Pattern

## Gerenciamento de Autores e Livros

Esta é uma Web API desenvolvida com **.NET 8** voltada para o gerenciamento de um catálogo de **autores** e seus respectivos **livros**.  
O projeto utiliza **SQL Server** como banco de dados e segue o padrão de arquitetura **Repository Pattern**, garantindo uma estrutura organizada, escalável e de fácil manutenção.

---

## 🚀 Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET 8
- **Banco de Dados:** SQL Server
- **ORM:** Entity Framework Core (Code First)
- **Documentação:** Swagger (OpenAPI)
- **Padrão de Projeto:** Repository Pattern com Services e Interfaces

---

## 🛠️ Funcionalidades

A API permite realizar operações completas de **CRUD (Create, Read, Update, Delete)** para as entidades **Autores** e **Livros**.

### 📚 Autores

- Listagem de todos os autores
- Busca de autor por ID
- Busca de autor vinculado a um determinado ID de livro
- Cadastro de autores
- Edição de autores
- Exclusão de autores

### 📖 Livros

- Listagem completa de livros com seus respectivos autores
- Busca de livro por ID
- Busca de livros vinculados a um autor específico
- Cadastro de livros
- Edição de livros
- Exclusão de livros

---

## 🏗️ Estrutura do Projeto

A aplicação foi organizada em pastas para separar responsabilidades:

- **Data**  
  Contém o `AppDbContext`, responsável pela comunicação com o banco de dados.

- **Models**  
  Define as entidades de banco de dados (`AutorModel`, `LivroModel`) e o modelo genérico de resposta (`ResponseModel`).

- **DTOs (Data Transfer Objects)**  
  Objetos utilizados para entrada de dados nas requisições, evitando a exposição direta dos modelos de banco de dados.

- **Services**  
  Implementação da lógica de negócio e comunicação direta com o banco de dados.

- **Interfaces**  
  Contratos que definem os métodos que os serviços devem implementar.

- **Controllers**  
  Endpoints da API que recebem as solicitações do usuário.

---

## 📋 Padronização de Respostas

Todas as requisições da API retornam um objeto padronizado chamado `ResponseModel<T>`, contendo:

- **Dados:** objeto ou lista solicitada
- **Mensagem:** informação sobre o sucesso ou erro da operação
- **Status:** valor booleano indicando o resultado da solicitação

---

## 🔧 Como Executar o Projeto

### 1️⃣ Pré-requisitos

- Visual Studio 2022 ou VS Code
- SDK do .NET 8
- SQL Server (local ou remoto)

### 2️⃣ Configuração do Banco de Dados

- No arquivo `appsettings.json`, configure a string de conexão em `DefaultConnection`
- Ajuste o servidor e o tipo de autenticação (Windows Authentication ou SQL Server)

### 3️⃣ Migrações

Execute os comandos de migração no **Console do Gerenciador de Pacotes** para criar o banco de dados e as tabelas.

### 4️⃣ Execução

- Pressione **F5** no Visual Studio para iniciar a aplicação
- O **Swagger** será aberto automaticamente no navegador para teste dos endpoints

---
