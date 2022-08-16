using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    //[SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 200f;
    Camera camera;
    //[SerializeField] float recoilOnHit = 500f;
    [SerializeField] float timeOfSpeedUp = 0f;

    [SerializeField] bool powerUpSpeed = false;
    [SerializeField] float speedBoost = 2f;
    //[SerializeField] bool powerUp2Vision = false;
    [SerializeField] public bool powerUpEatEnemy = false;
    [SerializeField] int numberOfComidas = 3;
    [SerializeField] public int comidasRemaining = 0;
    [SerializeField] public int numberOfLives = 3;
    [SerializeField] TextMeshProUGUI scoreGui;
    [SerializeField] TextMeshProUGUI timerGUI;
    [SerializeField] TextMeshProUGUI bulletsGui;
    [SerializeField] TextMeshProUGUI livesGUI;
    [SerializeField] int score = 0;
    [SerializeField] GameObject spawPointInimigo;

    private float speedMultiplier = 1;

    [SerializeField] LayerMask layerMask;

    private float rotY = 0;
    private Quaternion rotInitial;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        rotInitial = transform.localRotation;
        this.transform.position = new Vector3(5, 1, 5);
        timerGUI.enabled = false;
        bulletsGui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        scoreGui.text = "Pontos: " + score.ToString();
        timerGUI.text = "Tempo de velocidade: " + timeOfSpeedUp.ToString("0") + " segundos";
        bulletsGui.text = "Comer inimigos: " + comidasRemaining.ToString();
        livesGUI.text = "Vidas: " + numberOfLives.ToString() + "/3";
        ;
        rotY += Input.GetAxisRaw("Mouse X") * Time.deltaTime * rotSpeed;

        Quaternion rotHorizontal = Quaternion.AngleAxis(rotY, Vector3.up);

        transform.localRotation = rotHorizontal * rotInitial;

        rb.velocity = transform.TransformDirection(new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed * speedMultiplier));

        if (powerUpEatEnemy)
        {
            if(comidasRemaining <= 0)
            {
                powerUpEatEnemy = false;
                comidasRemaining = 0;
            }
        }

        if (powerUpSpeed)
        {
            if (timeOfSpeedUp > 0)
            {
                timeOfSpeedUp -= Time.deltaTime;
            }
            if (timeOfSpeedUp <= 0)
            {
                timerGUI.enabled = false;
                powerUpSpeed = false;
                speedMultiplier = 1;
                timeOfSpeedUp = 0;
            }
        }
        if (numberOfLives <= 0)
        {
            Debug.Log("Morreu de vez");
            SceneManager.LoadSceneAsync(3);
        }
        if (score >= 30)
        {
            SceneManager.LoadSceneAsync(2);
            Debug.Log("Venceu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            Debug.Log("Ganhou ponto");
            score += 1;
        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
            if (other.gameObject.name == "CheeseSlice1" || other.gameObject.name == "CheeseSlice3")
            {
                Destroy(other.gameObject);
                speedMultiplier = speedBoost;
                powerUpSpeed = true;
                timeOfSpeedUp = 30;
                Debug.Log("Queijo da velocidade");
                timerGUI.enabled = true;

            }
            if (other.gameObject.name == "CheeseSlice2" || other.gameObject.name == "CheeseSlice4")
            {
                Destroy(other.gameObject);
                comidasRemaining += numberOfComidas;
                bulletsGui.enabled = true;
                powerUpEatEnemy = true;
                Debug.Log("Queijo de comer inimigo");
            }
        }
    }


}
