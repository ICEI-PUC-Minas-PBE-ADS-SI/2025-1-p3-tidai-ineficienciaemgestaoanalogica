# Arquitetura da solução

![Fluxograma da infraestrutura](./images/fluxograma-funcionamento.png)

## Fluxo de Atendimento

1. Garçom acessa a interface web em um dispositivo móvel.
2. Seleciona mesa e registra pedido (que o cliente escolhe pelo cardápio físico).
3. O pedido vai para a lista de pedidos
4. Os funcionários acessam a lista de pedidos e preparam o pedido do cliente
5. Os clientes pedem a conta, o caixa acessa a lista de pedidos, fecha o pedido e imprime a conta.
6. Ao final do dia o gerente gera o relatório diário e imprime.

##  Modelo de dados

O desenvolvimento da solução proposta requer a existência de bases de dados que permitam realizar o cadastro de dados e os controles associados aos processos identificados, assim como suas recuperações.

Utilizando a notação do DER (Diagrama Entidade-Relacionamento), elabore um modelo, usando alguma ferramenta, que contemple todas as entidades e atributos associados às atividades dos processos identificados. Deve ser gerado um único DER que suporte todos os processos escolhidos, visando, assim, uma base de dados integrada. O modelo deve contemplar também o controle de acesso dos usuários (partes interessadas nos processos) de acordo com os papéis definidos nos modelos do processo de negócio.

Apresente o modelo de dados por meio de um modelo relacional que contemple todos os conceitos e atributos apresentados na modelagem dos processos.

### Modelo ER

O Modelo ER representa, por meio de um diagrama, como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

> **Links úteis**:
> - [Como fazer um diagrama entidade relacionamento](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

### Esquema relacional

O Esquema Relacional corresponde à representação dos dados em tabelas juntamente com as restrições de integridade e chave primária.
 

![Exemplo de um modelo relacional](images/modelo_relacional.png "Exemplo de modelo relacional.")
---

> **Links úteis**:
> - [Criando um modelo relacional - documentação da IBM](https://www.ibm.com/docs/pt-br/cognos-analytics/12.0.0?topic=designer-creating-relational-model)

### Modelo físico

Script de criação das tabelas do sistema:

```sql

-- criando a tabela de categorias de produtos
CREATE TABLE Categoria (
  IdCategoria INT PRIMARY KEY AUTO_INCREMENT,
  NomeCategoria VARCHAR(100) NOT NULL,
);

-- criando tabela de produtos
CREATE TABLE Produto (
  IdProduto INT PRIMARY KEY AUTO_INCREMENT,
  NomeProduto VARCHAR(100) NOT NULL,
  DescricaoProduto VARCHAR(255),
  PrecoProduto DECIMAL(10,2) NOT NULL,
  FotoProduto VARCHAR(255),
  IdCategoria INT,
  FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);

-- criando tabela de funcionários
CREATE TABLE Funcionario (
    IdFuncionario INT PRIMARY KEY AUTO_INCREMENT,
    NomeFuncionario VARCHAR(100) NOT NULL,
    UsuarioFuncionario VARCHAR(50) UNIQUE NOT NULL,
    SenhaFuncionario VARCHAR(60) NOT NULL
);

-- criando tabela de mesas do restaurante
CREATE TABLE Mesa (
    IdMesa INT PRIMARY KEY AUTO_INCREMENT,
    NomeMesa VARCHAR(50) NOT NULL
);

-- criando tabela dos pedidos realizados
CREATE TABLE Pedido (
    IdPedido INT PRIMARY KEY AUTO_INCREMENT,
    IdMesa INT NOT NULL,
    IdFuncionario INT NOT NULL,
    DataHoraInicio DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataHoraFim DATETIME,
    StatusPedido ENUM('Aberto', 'Fechado', 'Cancelado') DEFAULT 'Aberto',
    FOREIGN KEY (IdMesa) REFERENCES Mesa(IdMesa),
    FOREIGN KEY (IdFuncionario) REFERENCES Funcionário(IdFuncionario)
);

-- criando tabela da relação entre pedidos e produtos
CREATE TABLE Pedido_Produto (
  IdPedido_Produto INT PRIMARY KEY AUTO_INCREMENT,
  IdPedido INT NOT NULL,
  IdProduto INT NOT NULL,
  Quantidade INT NOT NULL DEFAULT 1,
  PrecoUnitario DECIMAL(10,2) NOT NULL,
  FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
  FOREIGN KEY (IdProduto) REFERENCES Produto(IdProduto)
);

```

## Tecnlogias utilizadas

### Front-end

| Dimensão | Tecnologias | Finalidade |
| -------- | ----------- | ---------- |
| Framework Principal | Angular | Desenvolver a lógica do front-end |
| Framework CSS | Bootstrap | Componentes pré configurados |
| Gerenciamento de estado | NgRx | Controle do estado da aplicação |
| Roteamento | Angular Routing | Navegação entre telas |
| Chamadas API | Fetch API | Comunicação com o Backend |
| IDE Recomendada | VS Code | Desenvolver com extensões para Angular/TypeScript |

### Back-end

| Dimensão | Tecnologias | Finalidade |
| -------- | ----------- | ---------- |
| Linguagem | C#          | Desenvolver a lógica de comunicação da API |
| Framework | ASP.NET     | Construção da API |
| Criptografia | Bcrypt    | Hash de criptografia para a senha do usuário |
| ORM          | Entity Framework Query | Interface com o banco de dados |
| IDE recomendado | Visual Studio | Desenvolvimento e teste |

### Banco de Dados

| Dimensão | Tecnologias | Finalidade |
| -------- | ----------- | ---------- |
| Banco Principal | MySQL | Armazenamento e relação |

## Hospedagem

| Dimensão | Tecnologias | Finalidade |
| -------- | ----------- | ---------- |
| Hospedagem Front-end | Docker Container | Acesso localmente pelo localhost |
| Hospedagem Back-end | Docker Container | Comunicação com o front-end pela rede local |
| Hospedagem do Banco de Dados | Docker Container | Hospedar o banco de dados localmente |
| Instalação | Inno Setup | Script de instalação |

- **Front-end**: Armazenado em um docker container que sobe para a porta 8080, o usuário acessa o localhost:8080 e acessa a página.
- **Back-end**: Armazenado em um docker container que sobe para a porta 5000.
- **Banco de Dados**: Armazenado em um docker container e não é exposto a porta alguma, se comunica com o back-end pela rede interna do docker.
- **Instalação**: O script de instalação instala o Docker Desktop se ele não estiver instalado, executa o docker compose com o arquivo docker-compose.yaml do projeto e gera um atalho para o localhost:8080 na tela inical. 

## Qualidade do Software

Nossa equipe priorizou 6 das 8 características da norma ISO/IEC 25010, com foco nas necessidades do nosso projeto.

| Criterio | Aplicação no projeto |
| -------- | -------------------- |
| Usabilidade | Interface intuitiva para os funcionários (Botões grandes, feedback visual claro). |
| Desempenho | Aplicação simplificada, consultas otimizadas, containerização. |
| Segurança | Banco de dados não exposto à rede. Hash de senhas. |
| Portabilidade | Software containerizado, possui as próprias dependências internamente |
| Manutenibilidade | Código modularizado, documentação da API |
| Adequação Funcional | O software resolve o problema da gestão analógica ineficiente dos restaurantes |

