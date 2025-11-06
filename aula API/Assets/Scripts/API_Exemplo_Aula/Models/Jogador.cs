using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float vida;
    public int quantidadeItens;
    public float posicaoX;
    public float posicaoY;
    public float posicaoZ;
}

public class Jogador : MonoBehaviour
{
    public PlayerData dados = new PlayerData();

    private void Start()
    {
        dados.vida = 100f;
        dados.quantidadeItens = 0;
        AtualizarPosicao();
    }

    private void Update()
    {
        AtualizarPosicao();
    }

    private void AtualizarPosicao()
    {
        dados.posicaoX = transform.position.x;
        dados.posicaoY = transform.position.y;
        dados.posicaoZ = transform.position.z;
    }

    public void ReceberDano(float dano)
    {
        dados.vida -= dano;
        if (dados.vida < 0) dados.vida = 0;
        Salvar();
    }

    public void ColetarItem()
    {
        dados.quantidadeItens++;
        Salvar();
        UIManager.instance.MostrarMensagemSalvamento();
    }

    public void Salvar()
    {
        string json = JsonUtility.ToJson(dados);
        PlayerPrefs.SetString("playerData", json);
        PlayerPrefs.Save();
    }

    public void Carregar()
    {
        if (PlayerPrefs.HasKey("playerData"))
        {
            string json = PlayerPrefs.GetString("playerData");
            dados = JsonUtility.FromJson<PlayerData>(json);
            transform.position = new Vector3(dados.posicaoX, dados.posicaoY, dados.posicaoZ);
        }
    }
}