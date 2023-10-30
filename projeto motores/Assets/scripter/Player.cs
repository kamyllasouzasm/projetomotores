
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    private Rigidbody rb;
    public bool noChão;
    

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag == "Chão") {)};
        {
            noChão = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //-1 esquerda,0 nada, 1 direita
        float v = Input.GetAxis("Vertical");// -1 pra tras, 0 nada, 1 pra frente

        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(Time.deltaTime * velocidade * direcao, ForceMode.Impulse);

        //pulo
        if (Input.GetKeyDown(KeyCode.Space) && noChão ) {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChão = false;
        }

        if(transform.position.y <= -10){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
  
}
