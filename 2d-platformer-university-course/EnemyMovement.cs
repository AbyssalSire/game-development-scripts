using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] CircleCollider2D capsuleCollider;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] private bool dir = false;
    [SerializeField] private float timeToReload = 2f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponentInChildren<BoxCollider2D>();
        capsuleCollider = GetComponent<CircleCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            rigidbody.velocity = new Vector2(3, rigidbody.velocity.y);
        } else if (!dir)
        {
            rigidbody.velocity = new Vector2(-3, rigidbody.velocity.y);
        }

        if (rigidbody.velocity == new Vector2(0, rigidbody.velocity.y))
        {
            dir = !dir;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = !dir;
        Debug.Log("bateu");
        if (collision.gameObject.name == "Player_Character")
        {
            Destroy(collision.gameObject);
            StartCoroutine(PlayerKilled());
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private IEnumerator PlayerKilled()
    {
        yield return new WaitForSeconds(timeToReload);
        SceneManager.LoadScene(0);
    }

}
