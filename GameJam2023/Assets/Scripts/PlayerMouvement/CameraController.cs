using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;

    [SerializeField] private Transform[] points;

    [SerializeField] private Transform[] transformsToFollow;

    [SerializeField] private float minDistanceBetweenPlayers;

    [SerializeField] private float maxDistanceBetweenPlayers;

    [SerializeField] private float lerpSpeedGoingBackwards;
    [SerializeField] private float lerpSpeedBetweenPlayers;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        //camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, GetPointBetweenPlayers(), lerpSpeed * Time.deltaTime);

        
        float distanceBetweenPlayers = Vector3.Distance(transformsToFollow[0].position, transformsToFollow[1].position);
        Vector3 positionToMoveTowards;
        if (distanceBetweenPlayers < minDistanceBetweenPlayers)
        {
            positionToMoveTowards = points[0].localPosition;
        }
        else if (distanceBetweenPlayers > maxDistanceBetweenPlayers)
        {
            positionToMoveTowards = points[1].localPosition;
        }
        else
        {
            positionToMoveTowards = Vector3.Lerp(points[0].localPosition, points[1].localPosition, InterpelationBetween2Points(distanceBetweenPlayers));
        }

        //camera.transform.localPosition = Vector3.Lerp(positionToMoveTowards, GetPointBetweenPlayers(), lerpSpeedBetweenPlayers * Time.deltaTime);
        camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, positionToMoveTowards, lerpSpeedGoingBackwards * Time.deltaTime);
        
    }

    private float InterpelationBetween2Points(float distanceBetweenPlayers)
    {
        return (distanceBetweenPlayers - minDistanceBetweenPlayers) /
            (maxDistanceBetweenPlayers - minDistanceBetweenPlayers);
    }


    private Vector3 GetPointBetweenPlayers()
    {
        Vector3 finalPosition = Vector3.zero;
        foreach (Transform vec in transformsToFollow)
        {
            finalPosition += vec.position;
        }
         return finalPosition / transformsToFollow.Length;
    }
}
