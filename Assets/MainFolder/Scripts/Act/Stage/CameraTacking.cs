using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTacking : MonoBehaviour
{

    public float smooth;
    public GameObject target;
    public Vector3 cameraPositionOffset;

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos+ cameraPositionOffset, smooth);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, smooth);
    }
}
