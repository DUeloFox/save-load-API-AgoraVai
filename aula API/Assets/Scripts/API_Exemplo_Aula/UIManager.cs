using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject mensagemSalvamento;
    public GameObject menuESC;
    public TextMeshProUGUI textoInfoPlayer;

    private Jogador player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<Jogador>();
        if (mensagemSalvamento != null) mensagemSalvamento.SetActive(false);
        if (menuESC != null) menuESC.SetActive(false);
    }

    private void Update()
    {
        // tecla ESC para abrir/fechar o menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AlternarMenu();
        }
    }

    public void MostrarMensagemSalvamento()
    {
        StartCoroutine(MostrarMensagemTemporaria());
    }

    private IEnumerator MostrarMensagemTemporaria()
    {
        mensagemSalvamento.SetActive(true);
        yield return new WaitForSeconds(2f);
        mensagemSalvamento.SetActive(false);
    }

    public void AlternarMenu()
    {
        if (menuESC == null) return;

        bool ativo = !menuESC.activeSelf;
        menuESC.SetActive(ativo);

        if (ativo && player != null)
        {
            textoInfoPlayer.text =
                $"Vida: {player.dados.vida}\n" +
                $"Itens: {player.dados.quantidadeItens}\n" +
                $"Posição: ({player.dados.posicaoX:F1}, {player.dados.posicaoY:F1}, {player.dados.posicaoZ:F1})";
        }
    }

    public void RecarregarPlayer()
    {
        if (player != null)
        {
            player.Carregar();
            AlternarMenu();
        }
    }
}
