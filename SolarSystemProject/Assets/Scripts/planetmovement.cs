using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetmovement : MonoBehaviour
{

    public float rotationvel = 20f;
    public float traslationvel = 20f;
    public float traslationangle = 5f;
    public Transform pivot;

    void Update()
    {
        this.transform.Rotate(new Vector3(0,rotationvel,0)*Time.deltaTime);
        this.transform.RotateAround(pivot.transform.position, Vector3.up, traslationvel*Time.deltaTime);
        this.transform.RotateAround(pivot.transform.position, Vector3.right, traslationangle*Time.deltaTime);
    }
}
