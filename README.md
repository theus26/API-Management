# API - Sistema de Gestão de Pessoal

Essa API foi desenvolvida para atender às necessidades de gestão de pessoal do departamento de Recursos Humanos. Ela permite o gerenciamento completo de funcionários, incluindo cadastro, edição, exclusão, controle de férias, cálculo de salário médio, histórico de alterações e geração de relatórios.

## Tecnologias Utilizadas

* REST
* C#
* Entity Framework Core
* .Net Core
* PostgreSQL

## Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/).
* PostgreSQL


## Configuração

1. Clone o repositório:

```
git clone https://github.com/theus26/API-Management.git
```

2. Acesse o diretório do projeto:

```
cd seu-repositorio
```

3. Configure as variáveis de ambiente do sistema necessárias.

```
ex: 
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=******;Include Error Detail=True;Log Parameters=True"
  },
```


4. Execute os seguintes comandos para restaurar as dependências e iniciar a API:

```
dotnet restore
dotnet run
```

5. Acesse a API em http://localhost:porta, onde "porta" é a porta configurada para a sua API.

## Funcionalidades

Exemplo:
* `GET /Employees/GetEmployeeById/{employeeId}`: Detalha um Funcionário pelo Id
* `GET /Employees/GetAllEmployees/`: Retorna uma lista com todos os funcionários.
* `GET /Employees/GetAverageSalary`: Retorna a média salarial dos funcionários cadastrados.
* `POST /Employees/CreateEmployee`: Criar Funcionário
* `POST /Employees/CreateVacationRecords`: Criar registro de férias do funcionários
* `PUT /Employees/UpdateEmployee/{employeeId}`: Atualiza um Funcionário com base nas novas informações passadas e criar um registro dos campos alterados
* `DELETE /Employees/DeleteEmployee/{employeeId}`: Deletar um Funcionário pelo seu Id.

## Banco de Dados

A API utiliza o Entity Framework Core para gerenciar o banco de dados PostgreSQL. Para configurar:

1. Verifique a porta 5432 e ajuste a ConnectionString corretamente.

2. Execute as migrations:

```
dotnet ef database update
```
_Este comando criará todas as tabelas necessárias no banco de dados._
