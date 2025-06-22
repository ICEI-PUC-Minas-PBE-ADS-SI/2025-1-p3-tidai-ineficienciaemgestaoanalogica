# Your Restaurant Manager

`CURSO: Análise e Desenvolvimento de Sistemas`

`DISCIPLINA: Trabalho Interdisciplinar Desenvolvimento de Aplicação Interativa`

`1º semestre/2025`

<p style="text-align: justify">O objetivo deste projeto é desenvolver uma solução digital para modernizar a gestão de pedidos e comandas em restaurantes que ainda utilizam métodos analógicos para lidar com as questões organizacionais, eliminando os problemas causados por tais métodos. A aplicação visa agilizar o atendimento, reduzir erros humanos e melhorar a experiência do cliente, permitindo que pedidos sejam registrados, processados e rastreados de forma eficiente. Além disso, a solução integrará o controle de estoque, ajudando a evitar desperdícios e garantindo maior organização interna.<br><br>
Com isso, o projeto busca não apenas aumentar a produtividade e a satisfação dos clientes, mas também proporcionar um ambiente de trabalho mais eficaz para os funcionários e uma gestão mais assertiva para os proprietários, alinhando-se às necessidades de um mercado cada vez mais digital e competitivo.
</p>

## Integrantes

* Caio Moreira Marques
* Davi Telles Xavier
* Marco Antonio Alves Moreira
* Pedro César da Matta Silveira
* Thiago Botelho Neves

## Professor

* Jardell Fillipe da Silva

## Instruções de utilização

Esta seção fornece instruções para configurar e executar o sistema em um ambiente local utilizando Docker.

---

### Índice

1. [Dependências](#dependencias)
2. [Instalação das Dependências](#instalacao-das-dependencias)
   - [Windows](#windows)
   - [Linux (Ubuntu/Debian)](#linux-ubuntudebian)
3. [Configuração e Execução](#configuracao-e-execucao)
   - [Instalador](#configuracao-instalador)
   - [Código-fonte](#configuracao-codigo-fonte)
5. [Acessando a Aplicação](#acessando-a-aplicacao)
6. [Contas de Demonstração](#contas-de-demostracao)
7. [Gerenciamento do Sistema](#gerenciamento-do-sistema)
8. [Possívels Problemas](#possiveis-problemas)

---

### <span id="dependencias">Dependências</span>

- **Git** (Opcional, para construir pelo código-fonte)
- **Docker**
- **Docker Compose**

---

### <span id="instalacao-das-dependencias">Instalação das Dependências</span>

#### <span id="windows">Windows</span>
1. [Baixe e instale o Git](https://git-scm.com/download/win) (Opcional)
2. [Instale o Docker Desktop](https://www.docker.com/products/docker-desktop/)
3. Após instalação:
   - Reinicie seu computador
   - Abra o Docker Desktop
   - Acesse Settings > General e habilite:
     - "Use WSL 2 based engine" (recomendado)
     - "Start Docker Desktop when you log in"

#### <span id="linux-ubuntudebian">Linux (Ubuntu/Debian)</span>
Execute os seguintes comandos no terminal:

```bash
# Atualiza pacotes e instala Git (Opcional)
sudo apt update && sudo apt upgrade -y
sudo apt install git -y

# Instala Docker e o Docker Compose
sudo apt install docker.io docker-compose -y
sudo systemctl enable --now docker

# Configura usuário (sem essa mudança todo comando docker precisa do sudo)
sudo usermod -aG docker $USER
newgrp docker
```
---

### <span id="configuracao-e-execucao">Configuração e Execução</span>

#### <span id="configuracao-instalador">Opção 1 - Baixe o Instalador para seu Sistema Operacional (Recomendado)</span>

Acesse a nossa página de releases para encontrar os arquivos:

### [**>> Acessar Página de Releases <<**](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica/releases/latest)

Ou use os links diretos abaixo para baixar a versão mais recente:

-   [**Baixar Instalador para Windows (.exe)**](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica/releases/latest/download/YourRestaurantManager-Setup-v1.1.exe)
-   [**Baixar Pacote para Linux (.zip)**](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica/releases/latest/download/YourRestaurantManager-Setup-v1.1.zip)

#### Execute a Instalação

##### Para Windows
1.  Garanta que o Docker Desktop esteja em execução.
2.  Execute o arquivo `.exe` que você baixou.
3.  Siga os passos do assistente de instalação. Ao final, atalhos serão criados e o sistema estará rodando.

##### Para Linux (Ubuntu/Debian)
1.  Garanta que o serviço do Docker esteja ativo (`sudo systemctl status docker`).
2.  Descompacte o arquivo `.zip` que você baixou.
3.  Abra um terminal na pasta que foi criada.
4.  Execute os seguintes comandos para dar permissão e iniciar o instalador:
    ```bash
    chmod +x install.sh
    ./install.sh
    ```
5. Siga os passos no terminal.

---

#### <span id="configuracao-codigo-fonte">Opção 2 - Construa do Código-fonte</span>

Siga estes passos **no terminal do seu computador** para iniciar a aplicação:

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica.git restaurant-manager
   cd restaurant-manager
   ```

2. **Inicie os containers**:
   ```bash
   docker compose up --build
   ```

   A primeira execução pode levar alguns minutos enquanto:
   - Baixa as imagens necessárias
   - Constrói os serviços frontend e backend
   - Configura o banco de dados MySQL

   A primeira execução pode ser interrompida por algum problema na comunicação interna do docker, normalmente, basta executar o comando novamente sem realizar um novo build:

   ```bash
   docker compose up
   ```

3. **Verifique os logs**:
   - Aguarde até ver a mensagem `Angular application started` no terminal
   - O backend estará pronto quando aparecer `Now listening on: http://[::]:5000`

---

### <span id="acessando-a-aplicacao">Acessando a Aplicação</span>

Após a inicialização completa, acesse:

- **Interface do Usuário**: [http://localhost](http://localhost)
- **API Backend**: [http://localhost:5000](http://localhost:5000)

---

### <span id="contas-de-demostracao">Contas de Demonstração</span>

Dois perfis estão disponíveis para teste:

#### Perfil de Gerente
- **Usuário**: admin
- **Senha**: admin
- **Permissões**: Acessar todas as telas do sistema

#### Perfil de Funcionário
- **Usuário**: joao
- **Senha**: senha123
- **Permissões**: Acessar apenas as telas de fazer pedidos e ver pedidos

---

### <span id="gerenciamento-do-sistema">Gerenciamento do Sistema</span>

#### Para parar a aplicação:

```bash
docker compose down
```

#### Para reiniciar:

```bash
docker compose up
```

#### Para limpar completamente (incluindo dados):

```bash
docker compose down -v --rmi all
```

#### Comandos úteis:
- Ver containers ativos: `docker ps`
- Acessar logs: `docker compose logs -f`
- Reconstruir imagens: `docker compose build --no-cache`
- Executar a aplicação em segundo plano:  `docker compose up -d`

---

### <span id="possiveis-problemas">Possíveis Problemas</span>

Problemas comuns e soluções:

1. **Erro de porta conflitante**:
   - Verifique se não há outros serviços usando as portas 80 ou 5000
   - Use `netstat -tulnp | grep LISTEN` (Linux) ou `netstat -ano` (Windows)

2. **Problemas no Docker Desktop**:
   - Reinicie o serviço Docker
   - Verifique se a virtualização está habilitada na BIOS
   - Verifique se o WSL2 está instalado e funcionando

# Documentação

<ol>
<li><a href="docs/01-Contexto.md"> Documentação de contexto</a></li>
<li><a href="docs/02-Especificacao.md"> Especificação do projeto</a></li>
<li><a href="docs/03-Metodologia.md"> Metodologia</a></li>
<li><a href="docs/04-Projeto-interface.md"> Projeto de interface</a></li>
<li><a href="docs/05-Template-padrao.md"> Template padrão da aplicação</a></li>
<li><a href="docs/06-Arquitetura-solucao.md"> Arquitetura da solução</a></li>
<li><a href="docs/07-Plano-testes-software.md"> Plano de testes de software</a></li>
<li><a href="docs/08-Registro-testes-software.md"> Registro de testes de software</a></li>
<li><a href="docs/09-Plano-testes-usabilidade.md"> Plano de testes de usabilidade</a></li>
<li><a href="docs/10-Registro-testes-usabilidade.md"> Registro de testes de usabilidade</a></li>
<li><a href="docs/11-Referencias.md"> Referências</a></li>
</ol>

# Código

* <a href="src/README.md">Código</a>

# Apresentação

* <a href="presentation/README.md">Apresentação do projeto</a>
