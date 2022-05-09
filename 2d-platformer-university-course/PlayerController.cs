using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float vel = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private bool dir = true;
    [SerializeField] float jump = 300f;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject player_feet;

    [SerializeField] private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if ((x > 0 && !dir) || x < 0 && dir)
        {
            this.transform.Rotate(new Vector2(0, 180));
            dir = !dir;
        }


        if (x == 0)
        {
            animator.SetBool("movement", false);
        }
        else
            animator.SetBool("movement", true);

        rigidbody.velocity = new Vector2(x * vel, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody.AddForce(new Vector2(0, jump));
        }

        RaycastHit2D hit;

        hit = Physics2D.Raycast(player_feet.transform.position, -player_feet.transform.up, 0.1f, mask);

        if (hit.collider != null)
        {
            grounded = true;
            transform.parent = hit.collider.transform;
        }
        else
        {
            grounded = false;
            transform.parent = null;
        }
    }


}
