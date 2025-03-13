
# Metodologia

A Metodologia de trabalho adotada pelo grupo para o desenvolvimento do software foi baseada no framework Scrum, que permite uma abordagem ágil e iterativa. O projeto está dividido em sprints, com entregas incrementais e reuniões diárias para acompanhamento do progresso. A equipe utiliza ferramentas modernas para gestão de código, documentação e colaboração.

## Relação de ambientes de trabalho

| Ambiente                     | Plataforma        | Link de Acesso |
| :----                        | :----             | :----          |
| Repositório de código fonte  | GitHub            | [Repositório](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica)  |
| Projeto de Interface         | Figma             | [Figma](https://www.figma.com/)  |
| Hospedagem                   | Docker            | [Docker Hub](https://hub.docker.com/)  |
| Banco de Dados               | MySQL             | [MySQL WorkBench](https://www.mysql.com/products/workbench/)/[DBeaver](https://dbeaver.io/)  |
| Desenvolvimento Front-end    | VS Code / Neovim  | [VS Code](https://code.visualstudio.com/)/[Neovim](https://neovim.io/)  |
| Desenvolvimento Back-end     | VS Code / Neovim  | [VS Code](https://code.visualstudio.com/)/[Neovim](https://neovim.io/)  |

## Controle de versão

A ferramenta de controle de versão adotada no projeto foi o [Git](https://git-scm.com/), sendo que o [GitHub](https://github.com) foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software.
- `dev`: versão de desenvolvimento do software.
- `feature/*`: branches para desenvolvimento de novas funcionalidades.
- `hotfix/*`: branches para correções críticas na versão estável.

O fluxo de trabalho funciona da seguinte forma:

- Todo o desenvolvimento ocorre na branch `dev`.
- Funcionalidades prontas para teste são mescladas na branch `testing`.
- Após testes, o código estável é mesclado na branch `unstable` para validação adicional.
- Versões consideradas prontas para produção são mescladas na branch `main`.

O projeto utiliza o seguinte padrão para as tags:

As tags são utilizadas para marcar versões estáveis, seguirão o padrão semântico `MAJOR.MINOR.PATCH` (ex: `v1.0.0`).

Os commits seguem o padrão Conventional Commits:

- Exemplo: `feat(login): adiciona tela de autenticação #11`.

Quanto à gerência de issues, o projeto adota a seguinte convenção para etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

As issues são vinculadas aos commits usando `#<número_da_issue>` (ex: `git commit -m "fix(login): corrige erro de autenticação #12`).
Processo de Commits:

## Planejamento do projeto

###  Divisão de papéis

> Apresente a divisão de papéis entre os membros do grupo em cada Sprint. O desejável é que, em cada Sprint, o aluno assuma papéis diferentes na equipe. Siga o modelo do exemplo abaixo:

#### Sprint 1
- _Scrum master_: AlunaX
- Protótipos: AlunoY
- Testes: AlunoK
- Documentação: AlunaZ

#### Sprint 2
- _Scrum master_: AlunaY
- Desenvolvedor _front-end_: AlunoX
- Desenvolvedor _back-end_: AlunoK
- Testes: AlunaZ

###  Quadro de tarefas

> Apresente a divisão de tarefas entre os membros do grupo e o acompanhamento da execução, conforme o exemplo abaixo.

#### Sprint 1

Atualizado em: 21/04/2024

| Responsável   | Tarefa/Requisito | Iniciado em    | Prazo      | Status | Terminado em    |
| :----         |    :----         |      :----:    | :----:     | :----: | :----:          |
| AlunaX        | Introdução | 01/02/2024     | 07/02/2024 | ✔️    | 05/02/2024      |
| AlunaZ        | Objetivos    | 03/02/2024     | 10/02/2024 | 📝    |                 |
| AlunoY        | Histórias de usuário  | 01/01/2024     | 07/01/2005 | ⌛     |                 |
| AlunoK        | Personas 1  |    01/01/2024        | 12/02/2005 | ❌    |       |

#### Sprint 2

Atualizado em: 21/04/2024

| Responsável   | Tarefa/Requisito | Iniciado em    | Prazo      | Status | Terminado em    |
| :----         |    :----         |      :----:    | :----:     | :----: | :----:          |
| AlunaX        | Página inicial   | 01/02/2024     | 07/03/2024 | ✔️    | 05/02/2024      |
| AlunaZ        | CSS unificado    | 03/02/2024     | 10/03/2024 | 📝    |                 |
| AlunoY        | Página de login  | 01/02/2024     | 07/03/2024 | ⌛     |                 |
| AlunoK        | Script de login  |  01/01/2024    | 12/03/2024 | ❌    |       |


Legenda:
- ✔️: terminado
- 📝: em execução
- ⌛: atrasado
- ❌: não iniciado


> **Links úteis**:
> - [11 passos essenciais para implantar Scrum no seu projeto](https://mindmaster.com.br/scrum-11-passos/)
> - [Scrum em 9 minutos](https://www.youtube.com/watch?v=XfvQWnRgxG0)
> - [Os papéis do Scrum e a verdade sobre cargos nessa técnica](https://www.atlassian.com/br/agile/scrum/roles)

### Processo

Coloque informações sobre detalhes da implementação do Scrum seguido pelo grupo. O grupo deverá fazer uso do recurso de gerenciamento de projeto oferecido pelo GitHub, que permite acompanhar o andamento do projeto, a execução das tarefas e o status de desenvolvimento da solução.
 
> **Links úteis**:
> - [Planejamento e gestão ágil de projetos](https://pucminas.instructure.com/courses/87878/pages/unidade-2-tema-2-utilizacao-de-ferramentas-para-controle-de-versoes-de-software)
> - [Sobre quadros de projeto](https://docs.github.com/pt/issues/organizing-your-work-with-project-boards/managing-project-boards/about-project-boards)
> - [Project management, made simple](https://github.com/features/project-management/)
> - [Como criar backlogs no GitHub](https://www.youtube.com/watch?v=RXEy6CFu9Hk)
> - [Tutorial slack](https://slack.com/intl/en-br/)

### Ferramentas

Liste todas as ferramentas que foram empregadas no projeto, justificando a escolha delas, sempre que possível.

Exemplo: os artefatos do projeto são desenvolvidos a partir de diversas plataformas e a relação dos ambientes com seu respectivo propósito é apresentada na tabela que se segue.

| Ambiente                            | Plataforma                         | Link de acesso                         |
|-------------------------------------|------------------------------------|----------------------------------------|
| Repositório de código fonte         | GitHub                             | http://....                            |
| Documentos do projeto               | GitHub                             | http://....                            |
| Projeto de interface                | Figma                              | http://....                            |
| Gerenciamento do projeto            | GitHub Projects                    | http://....                            |
| Hospedagem                          | Vercel                             | http://....                            |
 
