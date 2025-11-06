using UnityEngine;

public class Dano : MonoBehaviour
{
    public float dano = 10f;
    private void OnTriggerEnter(Collider other)
    {
        Jogador player = other.GetComponent<Jogador>();
        if (player != null)
        {
            player.ReceberDano(dano);
        }
    }
}