# Registro de testes de software

Relatório com as evidências dos testes de software realizados no sistema pela equipe, baseado em um plano de testes pré-definido.

Para cada caso de teste definido no <a href="07-Plano-testes-software.md"> Plano de testes de software</a>, foi realizado o registro das evidências dos testes feitos na aplicação pela equipe. Para isso, utilizamos o OBS Studio para registrar a tela durante a realização dos testes.

| **Caso de teste**  | **CT-001 – Gerenciamento de Produtos**  |
|:---: |:---: |
| Requisito associado | RF-001 - O gerente deve ser capaz de gerenciar produtos. |
| Registro de evidência | [Vídeo CT - 001](https://youtu.be/xrL_Q6VFwQs) |

| **Caso de teste**  | **CT-002 – Gerenciamento de Categorias**  |
|:---: |:---: |
| Requisito associado | RF-002 - O gerente deve ser capaz de gerenciar as categorias de produtos. |
| Registro de evidência | [Vídeo CT - 002](https://youtu.be/iGOefTz8MPA) |

| **Caso de teste**  | **CT-003 – Gerenciamento de Pedidos**  |
|:---: |:---: |
| Requisito associado | RF-003 - O funcionário deve ser capaz de gerenciar pedidos. |
| Registro de evidência | [Vídeo CT - 003](https://youtu.be/z8WxCIbVXaQ) |

| **Caso de teste**  | **CT-004 – Visualização de Relatórios**  |
|:---: |:---: |
| Requisito associado | RF-004 - O gerente deve ser capaz de visualizar relatórios de pedidos por data ou períodos personalizados. |
| Registro de evidência | [Vídeo CT - 004](https://youtu.be/0s2-Pp1rOlE) |

| **Caso de teste**  | **CT-005 – Gerenciamento de Funcionários**  |
|:---: |:---: |
| Requisito associado | RF-005 - O gerente deve ser capaz de gerenciar o acesso dos funcionários do sistema. |
| Registro de evidência | [Vídeo CT - 005](https://youtu.be/tNw9JPNPSSc) |

| **Caso de teste**  | **CT-006 – Gerenciamento de Mesas**  |
|:---: |:---: |
| Requisito associado | RF-006 - O gerente deve ser capaz de gerenciar as mesas do restaurante. |
| Registro de evidência | [Vídeo CT - 006](https://youtu.be/VLaolNcPUyw) |

| **Caso de teste**  | **CT-007 – Impressão de Contas e Relatórios**  |
|:---: |:---: |
| Requisito associado | RF-007 - O sistema deve permitir a impressão de contas e relatórios. |
| Registro de evidência | [Vídeo CT - 007](https://youtu.be/9MG50ol8fKU) |

| **Caso de teste**  | **CT-008 – Responsividade**  |
|:---: |:---: |
| Requisito associado | RNF-004 - Funcionamento adequado em dispositivos móveis e desktops. |
| Registro de evidência | [Vídeo CT - 008](https://youtu.be/ZPzBg7wZSpk) |

| **Caso de teste**  | **CT-009 – Otimização para Hardware Limitado**  |
|:---: |:---: |
| Requisito associado | RNF-007 - Boa performance em hardwares modestos. |
| Registro de evidência | [Vídeo CT - 009](https://youtu.be/6j3HyuVno6Y) |

| **Caso de teste**  | **CT-010 – Controle de Acesso por Permissões**  |
|:---: |:---: |
| Requisito associado | Restricao-003 - Restrições de acesso por perfil. |
| Registro de evidência | [Vídeo CT - 010](https://youtu.be/DqOpHuS9pxo) |

| **Caso de teste**  | **CT-011 – Atualização em Tempo Real**  |
|:---: |:---: |
| Requisito associado | Restricao-006 - Atualizações imediatas dos pedidos. |
| Registro de evidência | [Vídeo CT - 011](https://youtu.be/rvJX4B7t5Qk) |

## Avaliação

A execução dos testes demonstrou que o sistema está funcional e atende aos requisitos previamente estabelecidos no plano de testes. Todos os onze casos de teste foram concluídos com sucesso, sem ocorrência de falhas críticas, confirmando a conformidade da aplicação com os requisitos funcionais e não funcionais esperados.

### Pontos fortes identificados:

* **Estabilidade da aplicação**: O sistema se manteve estável durante todos os testes, sem apresentar travamentos ou erros, mesmo em execuções prolongadas e em diferentes dispositivos.
* **Performance satisfatória**: A aplicação teve bom desempenho mesmo em equipamentos com especificações modestas, atendendo ao requisito de otimização para hardware limitado.
* **Responsividade**: A interface foi corretamente adaptada para diferentes tamanhos de tela, garantindo uma boa experiência de uso tanto em dispositivos móveis quanto em desktops.
* **Funcionalidade de impressão**: As funcionalidades de geração e impressão de contas e relatórios funcionaram conforme esperado, com dados consistentes e bem organizados.
* **Atualização em tempo real**: As alterações realizadas nos pedidos foram refletidas imediatamente nas telas correspondentes, promovendo maior agilidade na operação.

### Pontos de melhoria identificados:

* **Navegação entre telas**: A ausência de um mecanismo de navegação rápida (como um dropdown com as telas principais) dificulta a usabilidade, exigindo mais cliques e tempo do usuário para alternar entre seções do sistema.
* **Ordenação da lista de pedidos**: Após a atualização de um pedido, ele permanece na mesma posição na lista. Isso pode impactar negativamente a priorização na cozinha, já que não reflete a ordem cronológica de atualização.
* **Bug no nome da mesa**: O botão inferior que deveria mostrar o nome da mesa selecionada está mostrando sempre o nome da primeira mesa.

### Ações futuras:

* **Melhoria na navegação**: Será implementado um componente de dropdown para facilitar a navegação entre as telas do sistema, otimizando a experiência do usuário.
* **Ajuste na ordenação de pedidos**: A classe `Pedido` será modificada no back-end para incluir o campo `DataHoraAtualizacao`. A listagem de pedidos será ordenada com base nesse atributo, garantindo que pedidos mais recentes ou atualizados sejam exibidos em ordem apropriada.
* **Bug do nome da mesa**: Corrijir o bug que exibe o nome errado da mesa no botão inferior.
