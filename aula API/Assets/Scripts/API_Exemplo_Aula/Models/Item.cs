using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Jogador player = other.GetComponent<Jogador>();
        if (player != null)
        {
            player.ColetarItem();
            Destroy(gameObject);
        }
    }
}
