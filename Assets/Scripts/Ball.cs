using UnityEngine;

// classe da bola, que é o nosso player
public class Ball : MonoBehaviour
{

    bool gameOver;
    public float speed = 2f;
    Rigidbody rb; // o componente Rigidbody da bola
    bool bouncing; // um marcador para indicar o pulo da bola

    // essa função ocorre antes do Start
    void Awake ()
    {
        // primeiro vamos pegar o Rigidbody deste objeto
        rb = GetComponent<Rigidbody>();
    }

    // essa função executa a cada quadro e é reservada para a física do jogo
    private void FixedUpdate()
    {
        // se falharmos em obter o Rigidbody, encerramos por aqui
        if (!rb) return;
        if (gameOver) return;

        // vamos armazenar o imput do eixo horizontal em um float
        float horizontal = Input.GetAxis("Horizontal");

        // vamos armazenar o imput do eixo vertical em um float
        float vertical = Input.GetAxis("Vertical");

        // agora, adicionamos uma força no eixo Z duas
        // vezes o valor de vertical para mover para frente e para trás
        rb.AddForce(0, 0, speed*horizontal, ForceMode.Force);

        // depois, adicionamos uma força no eixo X duas
        // vezes o valor de horizontal para mover para os lados
        //rb.AddForce(speed*vertical, 0, 0, ForceMode.Force);

        // se o usuário apertar a barra de espaço, a bola pula
        if (Input.GetKey(KeyCode.Space))
        {
            // se a bola já estiver pulando, vamos cancelar este comando
            // isso evita múltiplos pulos.
            if (bouncing) return;

            // para pular, adicionamos uma força no eixo Y
            //rb.velocity = Vector3.up * speed;
            rb.AddForce (0, speed, 0, ForceMode.Impulse);
        }
    }

    // tocou o chão
    // essa função é chamada sempre que encostamos em um outro collider
    private void OnCollisionEnter(Collision collision)
    {
        // definimos então que a bola não está pulando
        bouncing = false;

        if (collision.gameObject.name.Contains("Finish")) {
            gameOver = true;
            GameController.Instance.StageClear();
        }     
    }

    // saiu do chão
    // essa função é chamada sempre que saímos de um outro collider
    private void OnCollisionExit(Collision collision)
    {
        // definimos então que a bola não está pulando
        bouncing = true;
    }
}
