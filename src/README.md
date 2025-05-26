# Código do projeto

[Código do front-end](../src/front/restaurantManager/)

[Código do back-end](../src/back/RestaurantManagerAPI/)

[Scripts SQL](../src/db)

## Instalação do Site

Este sistema não está hospedado em um servidor público. Ele é executado localmente por meio de contêineres Docker, o que permite simular um ambiente de produção completo no próprio computador do desenvolvedor.

Para executá-lo localmente, é necessário ter o Docker e o Docker Compose instalados. Em seguida, basta rodar:

```bash
docker-compose up --build
```

Após a inicialização, a aplicação estará acessível via http://localhost.

Para mais detalhes sobre a instalação e execução da aplicação, consulte o [README principal do projeto](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica?tab=readme-ov-file#instru%C3%A7%C3%B5es-de-utiliza%C3%A7%C3%A3o).

## Histórico de versões

### \[1.0.0] - 25/05/2025

#### Adicionado

* Primeira versão estável do sistema com as funcionalidades principais implementadas.
* Finalização dos testes de software com todos os requisitos funcionais e não funcionais contemplados.
* Configuração do ambiente com Docker e Docker Compose.
* Integração entre front-end, back-end e banco de dados local.
