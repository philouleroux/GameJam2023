using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_PlayerPos");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material WallMaterial;
    public Camera Camera;
    public LayerMask LayerMask;

    void Update()
    {
        var dir = (Camera.transform.position - transform.position).normalized;
        var ray = new Ray(transform.position, dir);

        if (Physics.Raycast(ray, 3000f, LayerMask))
        {
            WallMaterial.SetFloat(SizeID, 1f);
        }
        else
        {
            WallMaterial.SetFloat(SizeID, 0f);
        }

        var view = Camera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PosID, view);
    }
}
