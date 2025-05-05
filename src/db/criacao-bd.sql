CREATE TABLE Categorias (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL
);

CREATE TABLE Produtos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Descricao VARCHAR(255),
    Preco DECIMAL(10,2) NOT NULL,
    Foto VARCHAR(255),
    CategoriaId INT NOT NULL,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

CREATE TABLE Extras (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    PrecoAdicional DECIMAL(10,2) NOT NULL,
    ProdutoId INT NOT NULL,
    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
);

CREATE TABLE Funcionarios (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) UNIQUE NOT NULL,
    Senha VARCHAR(60) NOT NULL
);

CREATE TABLE Mesas (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(50) NOT NULL
);

CREATE TABLE Pedidos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    MesaId INT NOT NULL,
    FuncionarioId INT NOT NULL,
    DataHoraInicio DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DataHoraFim DATETIME,
    Status ENUM('Aberto', 'Fechado', 'Cancelado') DEFAULT 'Aberto',
    FOREIGN KEY (MesaId) REFERENCES Mesas(Id),
    FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios(Id)
);

CREATE TABLE ItensPedido (
    PRIMARY KEY (PedidoId, ProdutoId),
    PedidoId INT NOT NULL,
    ProdutoId INT NOT NULL,
    Quantidade INT NOT NULL DEFAULT 1,
    PrecoUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
    FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
);

