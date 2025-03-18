# Especificação do projeto

<span style="color:red">Pré-requisitos: <a href="01-Contexto.md"> Documentação de contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto.

## Personas

### João, o Gestor;
- Idade: 45 anos;
- Perfil: Proprietário de um restaurante de médio porte, preocupado com eficiência operacional e controle de custos;
- Desafios: Gerenciar pedidos, evitar desperdícios, monitorar desempenho da equipe e garantir qualidade no atendimento;
- Necessidades: Um sistema que facilite a supervisão de processos, forneça dados em tempo real e permita um controle melhor do estoque e das vendas.

### Carlos, o Garçom
- Idade: 28 anos;
- Perfil: Profissional experiente, com cinco anos no setor, busca agilidade no atendimento e satisfação dos clientes;
- Desafios: Anotar pedidos corretamente, evitar erros na cozinha e gerenciar múltiplas mesas simultaneamente;
- Necessidades: Um sistema rápido e intuitivo para registrar pedidos e comunicar-se com a cozinha sem precisar de papel.

### Ana, a Cozinheira
- Idade: 35 anos;
- Perfil: Responsável pela execução dos pratos conforme os pedidos e padrões do restaurante;
- Desafios: Gerenciar fluxo de pedidos, evitar desperdício e manter a qualidade dos pratos, principalmente em horários de pico;
- Necessidades: Uma interface clara para visualizar os pedidos em tempo real e organizar melhor o tempo de preparo.

### Pedro, o Cliente
- Idade: 32 anos;
- Perfil: Profissional que almoça fora frequentemente e busca um atendimento rápido e eficiente;
- Desafios: Tempo limitado para refeições e espera excessiva por atendimento;
- Necessidades: Uma forma fácil de visualizar o cardápio, fazer pedidos rapidamente e pagar sem demora;


## Histórias de usuários

Com base na análise das personas, foram identificadas as seguintes histórias de usuários:

| EU COMO... `PERSONA`   | QUERO/PRECISO... `FUNCIONALIDADE`                                                                 | PARA... `MOTIVO/VALOR`                                                                 |
|-------------------------|---------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|
| **Gestor**              | Acessar relatórios de vendas e consumo com filtros (diário/semanal/mensal, categoria, horário)   | Tomar decisões estratégicas (ex: avaliar desempenho, definir compras de insumos).     |
| **Garçom**              | Registrar pedidos rapidamente com opções de modificação (ex: sem cebola)                         | Agilizar o atendimento e evitar erros no envio de pedidos para a cozinha.             |
| **Cozinheira**          | Visualizar pedidos em ordem cronológica com status de preparo (ex: "Em andamento", "Pronto")     | Organizar a produção e priorizar a preparação dos pratos conforme demanda.            |
| **Cliente**             | Visualizar cardápio digital via QR Code e realizar pedidos/pagamentos pelo celular               | Evitar filas e agilizar o processo de pedido/pagamento para uma experiência rápida.   |

## Requisitos

As tabelas a seguir apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade dos requisitos, aplique uma técnica de priorização e detalhe como essa técnica foi aplicada.

### Requisitos funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário cadastre tarefas | ALTA | 
|RF-002| Emitir um relatório de tarefas no mês   | MÉDIA |

### Requisitos não funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em dispositivos móveis | MÉDIA | 
|RNF-002| Deve processar as requisições do usuário em no máximo 3 segundos |  BAIXA | 

Com base nas histórias de usuários, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos não funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).

Lembre-se de que cada requisito deve corresponder a uma e somente uma característica-alvo da sua solução. Além disso, certifique-se de que todos os aspectos capturados nas histórias de usuários foram cobertos.

> **Links úteis**:
> - [O que são requisitos funcionais e requisitos não funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [Entenda o que são requisitos de software, a diferença entre requisito funcional e não funcional, e como identificar e documentar cada um deles](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Restrições

Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

O projeto está restrito aos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|001| O projeto deverá ser entregue até o final do semestre |
|002| O custo total do projeto não deve exceder o orçamento definido       |

## Diagrama de casos de uso

[diagrama de caso de uso](./images/diagrama-casos-de-uso.png)
