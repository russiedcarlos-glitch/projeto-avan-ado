using UnityEngine;
using TMPro; // Biblioteca para manipular TextMeshPro

public class InteracaoPainel : MonoBehaviour
{
    [Header("Configurações do Painel")]
    public Renderer painelGrafico; // O modelo 3D que exibe o gráfico
    public Material[] materiaisGraficos; // Array com diferentes gráficos (materiais)
    
    [Header("Configurações de Texto")]
    public TextMeshProUGUI textoInformacao; // O texto que será atualizado
    public string[] dadosMercado; // Textos diferentes correspondentes aos gráficos

    [Header("Áudio (Opcional)")]
    public AudioSource audioSource;
    public AudioClip somClique;

    private int indiceAtual = 0;

    void Start()
    {
        // Garante que o painel inicie com o primeiro gráfico e texto
        AtualizarPainel();
    }

    // Essa é a função que o XR Simple Interactable vai chamar no evento "Select Entered"
    public void TrocarDados()
    {
        // Toca o som de clique, se configurado
        if (audioSource != null && somClique != null)
        {
            audioSource.PlayOneShot(somClique);
        }

        // Avança para o próximo índice. Se passar do limite, volta para 0.
        indiceAtual++;
        if (indiceAtual >= materiaisGraficos.Length)
        {
            indiceAtual = 0;
        }

        // Atualiza a tela com o novo gráfico e dado
        AtualizarPainel();
    }

    private void AtualizarPainel()
    {
        // Muda o material (gráfico visual)
        if (painelGrafico != null && materiaisGraficos.Length > 0)
        {
            painelGrafico.material = materiaisGraficos[indiceAtual];
        }

        // Muda o texto descritivo na UI
        if (textoInformacao != null && dadosMercado.Length > 0)
        {
            if (indiceAtual < dadosMercado.Length)
            {
                textoInformacao.text = dadosMercado[indiceAtual];
            }
        }
    }
}
