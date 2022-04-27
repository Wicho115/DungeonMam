/*
 * DANTE
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasQuaterniones : MonoBehaviour
{
    MyQuaternion q;

    Mesh mesh;
    Vector3[] vertices;
    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        q = MyQuaternion.AngleRotation(10, AngleAxis.y);
        //q *= MyQuaternion.AngleRotation(5, AngleAxis.y);

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
    }

    private void Update()
    {

        for (int i = 0; i < vertices.Length; i++)
        {
            MyVector3 pos = (MyVector3)vertices[i];
            pos = q.Rotate(pos);
            vertices[i] = (Vector3)pos;
        }

        mesh.vertices = vertices;
    }
}
