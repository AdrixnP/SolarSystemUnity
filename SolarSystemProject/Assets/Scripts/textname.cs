using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textname : MonoBehaviour
{
    public Transform maincamera;
    public Transform obj;
    public Transform WorldSpaceCanvas;
    public Vector3 offset;
    void Start()
    {
        maincamera=Camera.main.transform;
        WorldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(WorldSpaceCanvas);
    }

    void Update()
    {
        transform.rotation=Quaternion.LookRotation(transform.position - maincamera.transform.position);
        transform.position=obj.position+offset;
    }
}
