using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalacticOrbit : MonoBehaviour
{
    // List of all objects that affect Gravitational pull
    [SerializeField]
    private float rangeOfInfluence = 0.5f;

    [SerializeField]
    private float bodyMass = 0;
    [SerializeField]
    private float speed = 0.2f;
    [SerializeField]
    public Vector3 velocity;
    [SerializeField]
    private float velocityLimit = 0.4f;
    [SerializeField]
    private List<GameObject> BodiesOfInfluence = new List<GameObject>();

    public float seperationMod = 0;
    public float cohesionMod = 0;

    // Use this for initialization
    void Start()
    {
        velocity = Vector3.zero;
        gameObject.GetComponent<SphereCollider>().radius = rangeOfInfluence;
        transform.up = velocity;
    }

    void OnTriggerEnter(Collider go)
    {
        //Debug.Log("TriggerEnter Hit");
        if (!go.isTrigger)
        BodiesOfInfluence.Add(go.gameObject);
    }

    void OnTriggerExit(Collider go)
    {
        //Debug.Log("TriggerExit Hit");
        if (BodiesOfInfluence.Contains(go.gameObject))
        BodiesOfInfluence.Remove(go.gameObject);
    }


    void FixedUpdate()
    {
        foreach(GameObject g in BodiesOfInfluence)
        {
            if (g == null)
                BodiesOfInfluence.Remove(g);
        }

        //velocity += (Cohesion() * cohesionMod) + (Seperation() * seperationMod);

        Cohesion();
        velocity *= (speed *Time.deltaTime);
        Velocitylimiter();
        transform.position += velocity;
        
        //velocity = Vector3.zero;
    }

    private void Cohesion()
    {
        // r = Return Velocity
        Vector3 r = Vector3.zero;
        foreach (GameObject g in BodiesOfInfluence)
        {
            g.GetComponent<GalacticOrbit>().velocity += (transform.position / 100 );
        }
        //r = ((r - transform.position) / 100);
        ////r.y = 0;
        ////r = r / count;
        //return r;
    }

    private Vector3 Seperation()
    {
        Vector3 r = Vector3.zero;

        foreach (GameObject g in BodiesOfInfluence)
        {
            if (Distance(g.transform.position, transform.position) < 2)
            {
                r += (transform.position - g.transform.position) / 2;
            }
        }
        r.y = 0;
        return r;
    }

    private void Velocitylimiter()
    {
        if (velocity.x >= velocityLimit)
        {
            velocity.x -= (velocity.x % velocityLimit);
        }

        if (velocity.z >= velocityLimit)
        {
            velocity.z -= (velocity.z % velocityLimit);
        }
    }

    public float Distance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt   (((a.x - b.x) * (a.x - b.x)) +          // X^2 
                            ((a.y - b.y) * (a.y - b.y)) +           // Y^2
                            ((a.z - b.z) * (a.z - b.z)));           // Z^2

    }
}
