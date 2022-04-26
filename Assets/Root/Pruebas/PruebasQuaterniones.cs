/*
 * DANTE
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasQuaterniones : MonoBehaviour
{
    public GameObject[] objects;
    MyQuaternion q;
    MyQuaternion suma;
    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        q = MyQuaternion.AngleRotation(10, AngleAxis.z);
        q *= MyQuaternion.AngleRotation(5, AngleAxis.y);
    }

    private void Update()
    {

        for (int i = 0; i < objects.Length; i++)
        {
            MyVector3 pos = (MyVector3)objects[i].transform.localPosition;
            pos = q.Rotate(pos);
            objects[i].transform.localPosition = (Vector3)pos;
        }

    }
}
