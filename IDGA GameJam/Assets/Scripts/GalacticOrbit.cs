using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalacticOrbit : MonoBehaviour
{
    [SerializeField]
    private float rangeOfInfluence = 0.5f;
    [SerializeField]
    private float bodyMass = 0;
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private List<GameObject> BodiesOfInfluence = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        //Debug.Log("hit");
        gameObject.GetComponent<SphereCollider>().radius = rangeOfInfluence;
    }

    void OnTriggerEnter(Collider go)
    {
        //Debug.Log("TriggerEnter Hit");
        BodiesOfInfluence.Add(go.gameObject);
    }

    void OnTriggerExit(Collider go)
    {
        //Debug.Log("TriggerExit Hit");
        BodiesOfInfluence.Remove(go.gameObject);
    }

    void FixedUpdate()
    {
        transform.position += GravityPull();
    }

    private Vector3 GravityPull()
    {
        Vector3 t = Vector3.zero;

        foreach(GameObject g in BodiesOfInfluence)
        {
            t.x += (2 * Mathf.PI * rangeOfInfluence) / speed;
            t.z += (2 * Mathf.PI * rangeOfInfluence) / speed;
        }

        return t;
    }
}
