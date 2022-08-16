using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 350f;
    [SerializeField] private Camera cam;

    private float rotX = 0;
    private Quaternion rotInitial;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        rotInitial = GetComponentInParent<Transform>().localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rotSpeed;

        rotX = Mathf.Clamp(rotX, -60, 60);

        Quaternion rotHorizontal = Quaternion.AngleAxis(rotX, Vector3.left);

        transform.localRotation = rotHorizontal * rotInitial;
    }
}
