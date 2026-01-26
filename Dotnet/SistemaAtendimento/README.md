##🎫 Sistema de Atendimento (Core API)
--
Este projeto é uma API robusta de gerenciamento de tickets de atendimento, construída com foco em escalabilidade, testabilidade e separação de preocupações. O sistema demonstra a aplicação prática de padrões de projeto modernos no ecossistema .NET.

## 🛠️ Stack Tecnológica
- Linguagem: C# 12 / .NET 8

- Banco de Dados: SQL Server

- ORM: Entity Framework Core 8

- Documentação: Swagger/OpenAPI

- Padrões de Projeto: * Repository Pattern: Desacoplamento da lógica de persistência.

- Service Layer: Centralização das regras de negócio.

- Injeção de Dependência: Gerenciamento de ciclo de vida de objetos.

- Async/Await: Processamento assíncrono de ponta a ponta para alta performance.

## 🏗️ Arquitetura do Sistema
O projeto segue os princípios da Clean Architecture, dividido em camadas de responsabilidade única:

- Domain: O coração do sistema. Contém Entidades, Interfaces (Contratos) e Enums. É 100% independente de bibliotecas externas de banco de dados.

- Infrastructure: Implementação técnica. Aqui reside o AppDbContext e os Repositories que traduzem as necessidades do domínio em comandos SQL.

- API: A porta de entrada. Responsável pelo roteamento, documentação Swagger e exposição dos Endpoints.

## 📈 Evolução Técnica (Destaques)
Durante o desenvolvimento, foram aplicadas soluções para problemas reais de software:

- Identificadores Híbridos: Uso de Guid para segurança interna e geração de Protocolos Amigáveis (ex: REQ-2026-A1B2) para o usuário final.

- Abstração de Dados: Implementação de Interfaces (ITicketRepository) que permitem a troca de provedores de dados sem afetar a lógica de negócio.

- Segurança de Tipos: Uso de Nullable Types e Enumerators para evitar erros de referência nula e estados inválidos no banco de dados.

🚀 Como Executar
Bash
# 1. Clone o repositório
git clone https://github.com/seu-usuario/sistema-atendimento-gdf.git

# 2. Restaure os pacotes
dotnet restore

# 3. Atualize o banco de dados (Migrations)
dotnet ef database update --project Atendimento.Infrastructure --startup-project Atendimento.Api

# 4. Rode a aplicação
dotnet run --project Atendimento.Api
🚧 Roadmap de Desenvolvimento
[x] Estrutura base de Domínio e Entidades.

[x] Implementação do Entity Framework e Migrations.

[x] Desenvolvimento do Repository Pattern.

[ ] Conclusão da Camada de Serviço (Próximo passo).

[ ] Implementação de DTOs para proteção de entradas.
