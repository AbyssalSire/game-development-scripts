using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    float offset = 3f;
    private void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.name == "Mirror1")
        {
            offset = -offset;
        }
        Debug.Log(this.gameObject.name);
        collision.gameObject.transform.position = otherPortal.transform.position + new Vector3(offset, 0, 0);
    }
}
