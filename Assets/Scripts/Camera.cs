
using UnityEngine;

// Classe da Câmera que segue a bola (ou qualquer objeto)
public class Camera : MonoBehaviour
{
    // objeto a ser seguido
    public GameObject ball;

    // velocidade da câmera
    public float speed = 3;

    // distância da câmera pro objeto
    public float distance = 9;

    // altura da câmera pro objeto
    public float height = 0.1f;

    // essa função executa a cada quadro
    void FixedUpdate()
    {
        // vamos normalizar o tempo com deltaTime
        // esse é o tempo que a câmera vai levar pra chegar no objeto
        float time = speed * Time.deltaTime;

        // vamos armazenar a posição atual
        Vector3 position = transform.position;

        // para o movimento da câmera, usaremos a função Lerp
        // Lerp move um objeto do ponto A ao ponto B em um tempo T.
        // faremos isso pra cada eixo

        // no valor de partida do eixo Y vamos adicionar o valor da altura
        // isso evita que a câmera fique no "chão"
        position.y =
            Mathf.Lerp(
                transform.position.y + height,
                ball.transform.position.y,
                time);

        position.z =
            Mathf.Lerp(
                transform.position.z,
                ball.transform.position.z,
                time);

        // no valor de chegada do eixo Z vamos subtrair o valor de distance
        // isso evita que a câmera fique muito perto do alvo
        position.x =
            Mathf.Lerp(
                transform.position.x,
                ball.transform.position.x + distance,
                time);

        // no final, devolvemos os valores calculados para o Transform
        transform.position = position;
    }
}
