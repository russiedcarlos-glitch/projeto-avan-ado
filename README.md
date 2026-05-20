
## 1) Apresentando o seu projeto
Este projeto é uma experiência VR desenvolvida no Unity que simula uma **Sala de Situação corporativa** (sala de reuniões futurista) para **análise de mercado e tomada de decisão** no contexto do Metaverso.

O ambiente possui mesa central, cadeiras, painéis holográficos e um skybox de cidade moderna à noite. O usuário pode navegar no espaço e interagir com painéis que exibem informações e gráficos.

## 2) Contexto e objetivos (Metaverso)
O cenário representa um espaço de **comunicação corporativa e análise de dados** no Metaverso.  
Objetivo: permitir que um usuário visualize indicadores e alterne gráficos de performance financeira por meio de interação VR (ray/controle), demonstrando que a experiência vai além de uma cena estática.

## 3) Interação implementada (obrigatória)
Interação principal:
- Ao **mirar o raio do controle** em um painel holográfico, um **visor digital** é ativado (hover).
- Ao pressionar o **gatilho/select**, o painel **alterna entre diferentes gráficos** (ex.: Receita, Lucro, Custos).

> Script exemplo: `PainelHolograficoUI.cs` (no relatório técnico).

## 4) Processo de criação e dificuldades
### Processo (resumo)
1. Configuração do XR (OpenXR + Meta XR SDK).
2. Montagem do ambiente (chão, mesa, cadeiras, paredes e iluminação).
3. Criação dos painéis holográficos (mesh + material + UI em World Space).
4. Implementação da interação em C# usando XR Interaction Toolkit.
5. Testes no Editor com XR Device Simulator e ajustes finais.

### Dificuldades (exemplos)
- Ajuste de escala/posição da UI em Canvas World Space.
- Configuração correta de eventos de Hover/Select nos objetos.
- Balancear qualidade visual (materiais/iluminação) com performance para Quest.

## 7) Estrutura recomendada do repositório
- `Assets/`
- `Packages/`
- `ProjectSettings/`
- `.gitignore` 
---
