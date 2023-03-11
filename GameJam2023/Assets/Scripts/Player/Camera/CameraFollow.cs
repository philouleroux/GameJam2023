using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float lerpSpeed;

    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, playerTransform.position, lerpSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, lerpSpeed * Time.deltaTime);

    }
}
