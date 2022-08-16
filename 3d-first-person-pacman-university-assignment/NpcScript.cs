using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] waypoints = new GameObject[4];
    [SerializeField] float minDistanceWaypoint = 5f;
    [SerializeField] float minDistancePlayer = 15f;
    [SerializeField] GameObject spawPoint;
    [SerializeField] GameObject spawPointInimigo;
    bool pursuit = false;
    NavMeshAgent agent;
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NextLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < minDistancePlayer || pursuit)
        {
            agent.SetDestination(player.transform.position);
            //pursuit = true;
        }
        else
        {
            if (Vector3.Distance(transform.position, agent.destination) < minDistanceWaypoint)
            {
                NextLocation();
            }

        }
    }

    void NextLocation()
    {
        agent.SetDestination(waypoints[index++].transform.position);
        if (index > 3)
            index = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerScript>().powerUpEatEnemy)
            {
                collision.gameObject.GetComponent<PlayerScript>().comidasRemaining-=1;
                this.transform.position = spawPointInimigo.transform.position + new Vector3(0, 1, 0);

            } else
            {

            Debug.Log("Matou o player");
            collision.gameObject.transform.position = spawPoint.transform.position + new Vector3(0,1,0);
            collision.gameObject.GetComponent<PlayerScript>().numberOfLives--;
            }
        }
    }
}
