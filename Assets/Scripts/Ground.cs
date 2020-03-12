using System.Collections; // importante para usar o IEnumerator
using UnityEngine;

// classe do chão invisível que "mata" o player
public class Ground : MonoBehaviour
{
    // este é o ponto de partida do jogador
    // pode ser um objeto vazio na cena
    public Transform startPoint;

    // essa função é chamada quando entramos em um
    // collider marcado com isTrigger.
    private void OnTriggerEnter(Collider other)
    {
        // other é o collider que entrou em contato
        // vamos tentar pegar o Rigidbody desse collider invasor
        Rigidbody rb = other.GetComponent<Rigidbody>();

        // se tivermos sucesso, vamos chamar a co-rotina Reset
        if (rb) StartCoroutine(Reset(rb));
    }

    // Reset recebe como parâmetro um Rigidbody
    // para zerar suas forças e devolvê-lo ao início do jogo
    IEnumerator Reset (Rigidbody rb)
    {
        // zeramos as forças lineares e angulares
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // aguardamos o FixedUpdate que é
        //quando as forças serão atualizadas
        yield return new WaitForFixedUpdate();

        // resetamos a posição para o início
        rb.transform.position = startPoint.position;

        // resetamos a rotação para zero
        rb.transform.rotation = Quaternion.identity;
    }
}
