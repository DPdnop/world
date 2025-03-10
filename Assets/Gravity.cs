using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody rb;
    private const float G = 0.006674f;
    public static List<Gravity> planetList;

    private void FixedUpdate()
    {
        foreach (var planet in planetList)
        {
            if (planet != this)
            {
                Attract(planet);
            }
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetList == null)
        {
            planetList = new List<Gravity>();
        }
        planetList.Add(this);
    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;

        float distance = direction.magnitude;

        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));

        Vector3 finalForce = forceMagnitude * direction.normalized;

        otherRb.AddForce(finalForce);
    }


}
