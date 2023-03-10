using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float lerpSpeed;

    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, playerTransform.position, lerpSpeed * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, lerpSpeed * Time.deltaTime);
        //transform.position = playerTransform.position;
    }
}
