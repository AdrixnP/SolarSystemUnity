using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 Offset;
    private Transform Target;
    [Range (0,1)] public float LerpValue;
    public float SensitivityX;
    public float SensitivityY;

    void Start()
    {
        Target=GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, LerpValue);
        Offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * SensitivityX, Vector3.up) * Offset;
        Offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * SensitivityY, Vector3.left) * Offset;

        transform.LookAt(Target);
    }
}
