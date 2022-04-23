using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebasQuaterniones : MonoBehaviour
{
    
    void Start()
    {
        MyVector3 v1 = new MyVector3(4,1,-2);
        MyVector3 v2 = new MyVector3(3,-4,2);

        print(MyVector3.ProductoCruzado(v1,v2));

        MyQuaternion q1 = new MyQuaternion(1,2,3,4);
        MyQuaternion q2 = new MyQuaternion(5,6,7,8);

        print(q2.Vector);

        var q3 = q1 * q2;
        print(q3);
        
    }
}
