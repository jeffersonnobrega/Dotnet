# 🎫 Sistema de Atendimento (Core API)

Este projeto é uma API robusta de gerenciamento de tickets de atendimento, construída com foco em escalabilidade, testabilidade e separação de preocupações. O sistema demonstra a aplicação prática de padrões de projeto modernos no ecossistema .NET.

## 🛠️ Stack Tecnológica
- Linguagem: C# 12 / .NET 8

- Banco de Dados: SQL Server

- ORM: Entity Framework Core 8

- Documentação: Swagger/OpenAPI

- Padrões de Projeto: 

  - Repository Pattern: Desacoplamento total da persistência.

  - Service Layer: Centralização de regras de negócio e tratamento de exceções.

  - Data Transfer Objects (DTOs): Proteção das entidades de domínio e contratos de entrada/saída limpos.

  - Response Pattern: Padronização de retornos da API com envelopes de status e mensagens.

## 🏗️ Arquitetura do Sistema
O projeto segue os princípios da Clean Architecture, dividido em camadas de responsabilidade única:

- Domínio: Entidades, Interfaces e Enums (100% independente).

- Serviços: Orquestração da lógica, validações e mapeamento de dados.

- Infraestrutura: AppDbContext, Migrations e implementação dos Repositórios via EF Core.

- API: Controllers enxutos, roteamento inteligente e injeção de dependência.

## 📈 Evolução Técnica (Destaques)
Durante o desenvolvimento, foram aplicadas soluções para problemas reais de software:

- Filtros Especializados: Implementação de busca por StatusAtendimento via parâmetros de rota, otimizando consultas via LINQ com Where e preparando a base para Include (Eager Loading).

- Tratamento de Erros Robusto: Uso de blocos try-catch na camada de serviço, encapsulando falhas em um objeto de resposta amigável para o cliente.

- Model Binding Avançado: Conversão automática de strings/inteiros da URL para Enums do C#.

## 🚀 Como Executar

### 1. Clone o repositório
git clone https://github.com/seu-usuario/sistema-atendimento-gdf.git

#### 2. Restaure os pacotes
dotnet restore

### 3. Atualize o banco de dados (Migrations)
dotnet ef database update --project Atendimento.Infrastructure --startup-project Atendimento.Api

### 4. Rode a aplicação
dotnet run --project Atendimento.Api

## 🚧 Roadmap de Desenvolvimento
- [x] Estrutura base de Domínio e Entidades.

- [x] Implementação do Entity Framework e Migrações.

- [x] Desenvolvimento do Padrão de Repositório.

- [x] Conclusão da Camada de Serviço e Lógica de Negócio.

- [x] Implementação de DTOs para proteção de dados.

- [ ] Implementação de Relacionamentos (Clientes/Atendentes).

- [ ] Sistema de Auditoria de Status (Log de mudanças).
