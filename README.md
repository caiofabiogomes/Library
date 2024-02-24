# Library

Este é o projeto Library, um sistema de biblioteca que permite empréstimo de livros, com integração de teste com o Stripe para pagamento dos empréstimos.

## Tecnologias Utilizadas

- **.NET 6.0**
- **Clean Architecture**: Padrão arquitetural que enfatiza a separação de preocupações e a escalabilidade da aplicação.
- **CQRS (Command Query Responsibility Segregation)**: Padrão de design que separa as operações de leitura e escrita em comandos e consultas distintos.
- **JWT (JSON Web Tokens)**: Método para autenticação e autorização de usuários na aplicação.
- **xUnit**: Framework de testes unitários para .NET.
- **Fluent Validation**: Biblioteca para validação de objetos de forma fluente e fácil de ler.
- **RabbitMQ**: Sistema de mensageria para comunicação assíncrona entre componentes.
- **Entity Framework**: Framework ORM para acesso a banco de dados em .NET.

## Estrutura do Projeto - Library

O projeto está estruturado da seguinte forma:

- **Library.API**: Camada de apresentação da aplicação, onde são expostas as APIs REST.
- **Library.Application**: Camada de aplicação que contém a lógica de negócio da aplicação.
- **Library.Domain**: Camada de domínio que contém as entidades e regras de negócio.
- **Library.Infrastructure**: Camada de infraestrutura que contém implementações específicas, como acesso a banco de dados e comunicação com o RabbitMQ.
- **Library.Tests**: Projeto que contém os testes unitários para as diferentes partes da aplicação.

## Estrutura do Projeto - LibraryPayment
O projeto é um microsserviço que lida com a integração de pagamento com stripe.
O projeto está estruturado da seguinte forma:

- **LibraryPayment.API**: Camada de apresentação da aplicação, onde são expostas as APIs REST.
- **LibraryPayment.Application**: Camada de aplicação que contém a lógica de negócio da aplicação.
- **LibraryPayment.Domain**: Camada de domínio que contém as entidades e regras de negócio.
- **LibraryPayment.Infrastructure**: Camada de infraestrutura que contém implementações específicas, como acesso a banco de dados,comunicação com o Stripe API e com o RabbitMQ. 

## Configuração e Execução

1. **Clonar o Repositório**: Clone este repositório em sua máquina local.

    ```bash
    git clone https://github.com/seu-usuario/library.git
    ```

2. **Instalar Dependências**: Certifique-se de ter o .NET 6.0 SDK instalado em sua máquina. Em seguida, instale as dependências do projeto.


3. **Configurar o Stripe API**: Obtenha suas credenciais de teste do Stripe e configure-as no arquivo de configuração correspondente (LibraryPayment.API/appsettings.json).
    ![image](https://github.com/caiogomesxx/Library/assets/72234988/03d2ab6c-ed32-4f10-a706-ae375a1fc9ea)


4. **Configurar Banco de Dados**: Configure a connection string com o banco de dados no arquivo de configuração correspondente (Library.API/appsettings.json).
    ![image](https://github.com/caiogomesxx/Library/assets/72234988/ae9c7166-f884-4ea4-b2b5-b0d32e373ac3)

5. **Executar Migrações**: Execute as migrações do Entity Framework para criar o banco de dados.

    ```bash
    dotnet ef database update
    ```

6. **Executar Projeto**: Execute o projeto principal.

    ```bash
    dotnet run --project Library.API
    ```

7. **Executar Testes**: Para executar os testes unitários, utilize o seguinte comando:

    ```bash
    dotnet test
    ```



