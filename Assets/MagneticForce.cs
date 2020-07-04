using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour
{
    public float forceFactor = 200f;
    List<Rigidbody> rbObjects = new List<Rigidbody>();
    Transform magnetPoint;
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        foreach (Rigidbody rgbBal in rbObjects)
        {
            rgbBal.AddForce((magnetPoint.position - rgbBal.position) * forceFactor * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodObjects") || other.CompareTag("BadObjects") || other.CompareTag("GoodObjects2") || other.CompareTag("TransitionObject"))
        {
            rbObjects.Add(other.GetComponent<Rigidbody>());

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GoodObjects") || other.CompareTag("BadObjects") || other.CompareTag("GoodObjects2") || other.CompareTag("TransitionObject"))
        {
            rbObjects.Remove(other.GetComponent<Rigidbody>());

        }
    }
}
