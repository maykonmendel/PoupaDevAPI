# PoupaDevAPI

## Tecnologias e práticas utilizadas

- ASP.NET Core com .NET 6
- Entity Framework Core
- SQL Server Developer 2019
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Clean
- SoftDelete

## Funcionalidades

- Cadastro, Edição, Remoção e Listagem de Objetivos Financeiros
- Cadastro, Edição, Remoção e Listagem de Operações Financeiras

## Como executar o projeto

***Observação:*** Acessar o terminal com direitos administrativos

1. Clonar o projeto do Github

`git@github.com:maykonmendel/PoupaDevAPI.git`

2. Acessar a pasta PoupaDevAPI e restaurar os pacotes do projeto.

```
dotnet restore
dotnet build
```

3. Criar no SQL Server um novo usuário e senha com direitos de administrador:
```
usuário: sa
senha: Alterar@123
```

4. Gerar as migrations que irão gerar o banco de dados

`dotnet ef migrations add InitialMigration`

5. Criar um novo banco de dados com o EF Core:

`dotnet ef database update`

6. Executar o projeto:

`dotnet run`

7. Abrir o navegador e acessar através da porta indica pelo dotnet run:

`https://localhost:{port}/swagger/index.html`