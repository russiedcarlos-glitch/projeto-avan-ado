# RELATÓRIO TÉCNICO — PROJETO VR NO METAVERSO  
**Web 3.0 | Residência em TIC 29 — Atividade Avaliativa**  
**Projeto Final: Meu Primeiro Ambiente VR — Relatório Técnico Avançado**  
**Cena 2: Sala de Situação e Análise de Mercado (Sala de Reuniões)**  

> **Observação:** os campos entre **[colchetes]** são para você preencher com seus dados reais (nome, turma, versão do Unity, etc.). O restante já está escrito e pode ser ajustado conforme o que você implementar no projeto.

---

## SEÇÃO 1 — IDENTIFICAÇÃO

**Nome Completo:** [SEU NOME AQUI]  
**Turma / Residência:** [SUA TURMA AQUI]  
**Limitação de Hardware Relatada (se houver):** [Ex.: “Notebook com 8GB RAM; Unity fecha ao importar assets muito pesados.” | “Sem Quest disponível, testes via XR Device Simulator.”]  

---

## SEÇÃO 2 — CONCEITO DO PROJETO

### 2.1 Nome do Projeto
**[Ex.: MetaBoardroom: Sala de Situação]**

### 2.2 Contexto e Objetivo no Metaverso
O projeto representa um **hub corporativo futurista** voltado para **tomada de decisões, reuniões e apresentações de dados em tempo real** dentro de um contexto de Metaverso.  

**Objetivo:** permitir que o usuário (avatar) se movimente pelo ambiente e interaja com **painéis holográficos** que exibem **informações textuais** (resumos/insights) e **gráficos de performance financeira** (ex.: receita, lucro, custos, crescimento), simulando uma *“Sala de Situação”* onde dados são consumidos de forma rápida e imersiva.

### 2.3 Descrição Geral do Ambiente Virtual
O ambiente é uma **sala de reuniões corporativa futurista** com:
- **Mesa central** de reuniões e **cadeiras ergonômicas** ao redor;
- **Painéis holográficos flutuantes** nas paredes (ou suportes) com gráficos/indicadores;
- **Terminal de comando** (totem/console) para controle e troca de visualizações;
- **Skybox** de cidade moderna à noite (*Golden Hour* ou *Cyberpunk*) para reforçar a identidade visual;
- Iluminação com contraste (luzes frias + detalhes neon) para dar sensação de tecnologia.

---

## SEÇÃO 3 — CONFIGURAÇÃO TÉCNICA DO PROJETO

### 3.1 Versão do Unity e Porquê
- **Unity:** [Ex.: Unity 6000.3.9f1 LTS / 2022.3 LTS]  
- **Motivo:** versão estável e compatível com o fluxo XR (OpenXR + Meta XR SDK), reduzindo risco de incompatibilidades no build Android.

### 3.2 Instalação do Meta XR SDK (Passo a Passo)
> Ajuste os nomes conforme o pacote que você usar (Meta XR All-in-One / Oculus Integration / etc.).
1. Abrir **Package Manager** e instalar **XR Interaction Toolkit** (e opcionalmente **XR Device Simulator**).  
2. Importar o **Meta XR All-in-One SDK** (ou o SDK recomendado pelo curso).  
3. Em **Project Settings**, habilitar o grupo de features do Meta/OpenXR, conforme orientação do SDK.  
4. Reiniciar o Unity se o SDK solicitar.

### 3.3 Configurações de Build para Android/Meta Quest
- **Build Settings → Platform:** Android (**Switch Platform**)  
- **Texture Compression:** ASTC (recomendado para Quest)  
- **Minimum API Level:** Android 10 (Level 29) (ou conforme o SDK)  
- **Scripting Backend:** IL2CPP  
- **Target Architectures:** ARM64  

### 3.4 Configuração do XR Plugin Management
- **XR Plug-in Management:** habilitar **OpenXR** (Android)  
- Em **OpenXR**, garantir que o perfil / interaction profile do Quest esteja ativo (conforme aula/mentoria).

### 3.5 Movimentação no PC (Editor)
Para testar no Editor sem depender do óculos:
- Usar o **XR Device Simulator** (XR Interaction Toolkit) para simular headset e controles no teclado/mouse.

---

## SEÇÃO 4 — ASSETS E ELEMENTOS DA CENA

> Preencha com o que você realmente usar (Asset Store, Sketchfab, Poly Haven, etc.).  
> Regra do projeto: **mínimo de 5 objetos 3D** + chão navegável + skybox.

**ASSET 1**  
- **Nome:** [Ex.: Sci‑Fi Office / Boardroom Pack]  
- **Tipo:** Objetos 3D (mesa, cadeiras, paredes, detalhes)  
- **Origem:** Asset Store (gratuito) / [link]  
- **Função:** construir o cenário principal (sala de reuniões).

**ASSET 2**  
- **Nome:** [Ex.: Hologram Shader / Holographic UI]  
- **Tipo:** Material / Shader  
- **Origem:** Asset Store / GitHub / [link]  
- **Função:** dar aparência holográfica aos painéis e telas.

**ASSET 3**  
- **Nome:** [Ex.: Cyberpunk Night City Skybox]  
- **Tipo:** Skybox / Texturas HDRI  
- **Origem:** [link]  
- **Função:** ambientação externa (cidade moderna à noite).

**ASSET 4**  
- **Nome:** XR Interaction Toolkit  
- **Tipo:** Package Unity  
- **Origem:** Unity Package Manager  
- **Função:** interação por ray, eventos de hover/seleção, locomotion e simulator.

**ASSET 5**  
- **Nome:** [Ex.: UI SFX Pack]  
- **Tipo:** Áudio  
- **Origem:** Asset Store / [link]  
- **Função:** feedback sonoro ao ativar painel e alternar gráficos.

---

## SEÇÃO 5 — HIERARQUIA DE GAME OBJECTS (SUGESTÃO)

**Scene:** `SalaDeSituacao`  

- `[--- MANAGEMENT ---]`  
  - `EventSystem`  
  - `XR Interaction Manager`  
  - `Input Action Manager` (se aplicável)  
  - `AudioManager` (opcional)  

- `[--- PLAYER ---]`  
  - `XR Origin (Action-based)`  
    - `Camera Offset`  
      - `Main Camera`  
    - `LeftHand Controller`  
    - `RightHand Controller`  
  - `XR Device Simulator` (apenas no Editor)  

- `[--- ENVIRONMENT ---]`  
  - `Floor` (Plane/Terrain + Collider)  
  - `MeetingRoom`  
    - `Mesa_Central`  
    - `Cadeiras`  
    - `Paredes_Teto`  
    - `Iluminacao` (Directional/Point/Spot + emissivos)  
  - `Skybox` (via Lighting Settings)  

- `[--- INTERACTABLES ---]`  
  - `Painel_Financeiro_01`  
    - `PanelMesh` (+ Collider)  
    - `Canvas_WorldSpace`  
      - `UI_Visor` (texto + gráfico)  
  - `Painel_Financeiro_02` (opcional)  
  - `Terminal_Comando` (opcional)  

---

## SEÇÃO 6 — SISTEMA DE INTERAÇÃO

### 6.1 Descrição da Interação Principal
Ao aproximar o avatar (ou mirar o raio do controle) em um **painel holográfico específico**, um **visor digital** é ativado mostrando:
1) um **texto informativo** (insight rápido), e/ou  
2) a alternância entre **gráficos de performance financeira** (ex.: Receita, Lucro, Custos) ao executar uma ação de seleção.

### 6.2 Lógica da Interação (Passo a Passo)
1. O usuário aponta o **Ray Interactor** do controle para o painel (ou entra em um *trigger* de proximidade).  
2. O painel detecta **Hover (XR Interaction Toolkit)** e ativa a UI do visor (Canvas em World Space).  
3. Se o usuário pressionar **Select/Trigger**, o painel alterna o gráfico exibido.  
4. Um som curto confirma a ação e o texto do visor atualiza junto com o gráfico.

### 6.3 Script C# — `PainelHolograficoUI.cs`
> Script exemplo para usar com **XRSimpleInteractable** no painel.  
> Ajuste nomes/refs conforme sua cena.

```csharp
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class PainelHolograficoUI : MonoBehaviour
{
    [Header("Referências UI (Canvas World Space)")]
    [SerializeField] private GameObject visorRoot;        // objeto pai do visor
    [SerializeField] private TMP_Text tituloTxt;
    [SerializeField] private TMP_Text descricaoTxt;
    [SerializeField] private RawImage graficoImg;         // pode ser RawImage ou Renderer

    [Header("Conteúdo")]
    [SerializeField] private string tituloBase = "Performance Financeira";
    [SerializeField, TextArea] private string textoBase =
        "Aponte para o painel para ver os indicadores. Aperte o gatilho para alternar o gráfico.";

    [SerializeField] private List<Texture> graficos = new List<Texture>(); // Q1/Q2/Q3 ou Receita/Lucro/Custos
    [SerializeField] private List<string> labelsGraficos = new List<string>();

    [Header("Áudio (opcional)")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sfxHover;
    [SerializeField] private AudioClip sfxTroca;

    private XRSimpleInteractable interactable;
    private int indexGrafico = 0;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void OnEnable()
    {
        if (!interactable) return;
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnDisable()
    {
        if (!interactable) return;
        interactable.hoverEntered.RemoveListener(OnHoverEnter);
        interactable.hoverExited.RemoveListener(OnHoverExit);
        interactable.selectEntered.RemoveListener(OnSelect);
    }

    private void Start()
    {
        // Estado inicial: visor desligado
        if (visorRoot) visorRoot.SetActive(false);
        AtualizarVisor();
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (visorRoot) visorRoot.SetActive(true);
        Tocar(sfxHover);
        AtualizarVisor();
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (visorRoot) visorRoot.SetActive(false);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (graficos == null || graficos.Count == 0) return;
        indexGrafico = (indexGrafico + 1) % graficos.Count;
        Tocar(sfxTroca);
        AtualizarVisor();
    }

    private void AtualizarVisor()
    {
        if (tituloTxt) tituloTxt.text = $"{tituloBase} — {NomeGraficoAtual()}";
        if (descricaoTxt) descricaoTxt.text = textoBase;

        if (graficoImg && graficos != null && graficos.Count > 0)
            graficoImg.texture = graficos[indexGrafico];
    }

    private string NomeGraficoAtual()
    {
        if (labelsGraficos != null && labelsGraficos.Count == graficos.Count)
            return labelsGraficos[indexGrafico];
        return $"Gráfico {indexGrafico + 1}";
    }

    private void Tocar(AudioClip clip)
    {
        if (!audioSource || !clip) return;
        audioSource.PlayOneShot(clip);
    }
}
```

### Como configurar no Unity (Checklist rápido)
1. No GameObject do painel, adicionar:
   - `Collider` (BoxCollider, por exemplo)  
   - `XRSimpleInteractable`  
   - Script `PainelHolograficoUI`  
2. Criar um `Canvas` em **World Space** e posicionar como visor do painel.  
3. Dentro do Canvas, adicionar:
   - `TextMeshPro` para título/descrição  
   - `RawImage` (ou `MeshRenderer`) para mostrar a textura do gráfico  
4. Importar 2–3 imagens de gráficos (pode ser PNG) e ligar na lista `graficos`.  
5. Testar no Editor com `XR Device Simulator`: mirar com o ray e apertar o botão de Select.

---

## SEÇÃO 7 — PLANEJAMENTO DO REPOSITÓRIO GITHUB

### 7.1 Nome do Repositório
`[Ex.: Projeto-Metaverso-TIC29-SalaDeSituacao]`

### 7.2 Estrutura de Pastas (Unity)
- `Assets/` (Scenes, Scripts, Prefabs, Materials, Textures, Audio)  
- `ProjectSettings/`  
- `Packages/`  

**Importante:** configurar `.gitignore` para Unity (ignorar `Library/`, `Temp/`, etc.).

---

## SEÇÃO 8 — PLANO DE EXECUÇÃO PASSO A PASSO

1. Criar projeto 3D e configurar URP (se necessário).  
2. Instalar XR Interaction Toolkit e XR Device Simulator.  
3. Importar e configurar Meta XR SDK / OpenXR.  
4. Montar a sala: chão, mesa, cadeiras, paredes e iluminação.  
5. Adicionar skybox (Golden Hour/Cyberpunk) e ajustar pós-processamento (opcional).  
6. Criar painéis holográficos (mesh + material holográfico + Canvas World Space).  
7. Adicionar `XRSimpleInteractable` e implementar `PainelHolograficoUI.cs`.  
8. Testar interação no Editor e ajustar colisores/alcance do ray.  
9. Preparar build Android (Quest) e testar desempenho (iluminação, shaders, texturas).  
10. Subir para GitHub com README completo.

---

## SEÇÃO 9 — REFLEXÃO FINAL

### 9.1 Aprendizado
[Ex.: Aprendi a estruturar uma cena XR com hierarquia limpa e a usar eventos de Hover/Select do XR Interaction Toolkit para criar interações coerentes com o tema.]

### 9.2 Dificuldades Previstas
[Ex.: Ajustar materiais holográficos para manter boa performance no Quest; evitar excesso de draw calls; organizar UI em Canvas World Space sem ficar tremendo ou fora de escala.]

### 9.3 Melhorias Futuras
[Ex.: Adicionar dashboard com dados “ao vivo” (simulados) atualizando ao longo do tempo; adicionar multiusuário; adicionar animações de transição e voice-over explicando os indicadores.]

