using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Vector2 startingPosition;
    [SerializeField] float cont = 0;
    [SerializeField] float movement = 1f;
    private float x_offSet, y_offSet;
    [SerializeField] float distX = 3, distY = 2;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cont += movement * Time.deltaTime;

        if (cont > 2 * Mathf.PI)
            cont = cont - Mathf.PI * 2;

        x_offSet = Mathf.Sin(cont) * distX;
        y_offSet = Mathf.Cos(cont) * distY;

        transform.position = startingPosition + new Vector2(x_offSet, y_offSet);

    }
}
