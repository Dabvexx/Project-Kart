using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject go;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = go.transform.position;
    }
}
