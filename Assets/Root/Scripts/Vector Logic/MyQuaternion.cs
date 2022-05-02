/*
 * DANTE
 */
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public struct MyQuaternion
{
    //VALOR ESCALAR DE MI QUATERNION, ES DECIR UN NUMERO REAL
    public float w { get; set; }

    //VALORES COMPLEJOS, SE USAN PARA HACER LA "PARTE VECTOR" DEL QUATERNION
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }

    public MyVector3 Vector;

    public static MyQuaternion identidad => _identidad;
    private static readonly MyQuaternion _identidad = new MyQuaternion(1,0,0,0);

    private MyQuaternion conjugado => Conjugar(this);

    public MyQuaternion(float w, MyVector3 vector)
    {
        this.w = w;

        x = vector.x;
        y = vector.y;
        z = vector.z;

        Vector = vector;
        _builder = default;
        _builder = CreateBuilder();
    }

    public MyQuaternion(float w, float x, float y, float z) : this(w, new MyVector3(x, y, z)){}

    public static MyQuaternion AngleRotation(float angle, AngleAxis angleAxis)
    {
        var radAngle = Mathf.Deg2Rad * (angle / 2f);
        var newW = Mathf.Cos(radAngle);
        var newVector = angleAxis.axis;
        newVector *= Mathf.Sin(radAngle);

        return new MyQuaternion(newW, newVector);
    }

    //ROTA UN PUNTO Y A TRAVES DE UN QUATERNION 
    public MyVector3 Rotate(MyVector3 v) => Rotate(this, v);
    public static MyVector3 Rotate(MyQuaternion q, MyVector3 v)
    {
        /*useless?
        var vectorQuaternion = new MyQuaternion(0, v);
        var newq = q * vectorQuaternion * q.conjugado;

        return newq.Vector;
        */
       
        var (x, y, z) = v;
        var (qX, qY, qZ, w) = q;

        var doubleX = qX * 2f;
        var doubleY = qY * 2f;
        var doubleZ = qZ * 2f;

        var doublePowX = doubleX * qX;
        var doublePowY = doubleY * qY;
        var doublePowZ = doubleZ * qZ;

        var xy2 = doubleX * qY;
        var xz2 = doubleX * qZ;
        var yz2 = doubleY * qZ;
        var wx2 = doubleX * w;
        var wz2 = doubleZ * w;
        var wy2 = doubleY * w;

        var newX = ((1 - doublePowY - doublePowZ) * x) + ((xy2 - wz2) * y) + ((xz2 + wy2) * z);
        var newY = ((xy2 + wz2) * x) + ((1 - doublePowX - doublePowZ) * y) + ((yz2 - wx2) * z);
        var newZ = ((xz2 - wy2) * x) + ((yz2+wx2) * y) + ((1 - doublePowX - doublePowY) * z);
        return new MyVector3(newX, newY, newZ);
        
    }


    #region METODOS_ESTATICOS
    public static MyQuaternion Conjugar(MyQuaternion q)
    {
        return new MyQuaternion(q.w, -q.Vector);
    }

    #endregion

    #region DECONSTRUCT
    public void Deconstruct(out float x, out float y, out float z, out float w)
    {
        x = this.x;
        y = this.y;
        z = this.z;
        w = this.w;
    }
    #endregion

    #region INDEXER
    // ESTO ES UN "indexer" ES UNA MANERA DE USAR LA ESTRUCTURA CON INDICADORES DE POSICION
    // PARA PODER AGARRAR UN VALOR DEL MISMO, POR EJEMPLO:
    /* 
     * MyQuaternion q = new MyQuaternion(1,0,0,1);
     * q[0]; (DEVOLVERA 1)
    */
    public float this[int index]
    {
        get 
        {
            return index switch
            {
               0 => w,
               1 => x,
               2 => y,
               3 => z,
               _ => throw new System.IndexOutOfRangeException("No existe un componente con ese index")
            };
        }
    }
    #endregion

    //ESTA REGI�N DIVIDE LOS OPERADORES LOGICOS PARA PODER HACER OPERACIONES ENTRE TIPOS DE DATOS
    #region OPERADORES
    public static MyQuaternion operator *(MyQuaternion q1, MyQuaternion q2)
    {
        var newVector = (q1.w * q2.Vector) + (q2.w * q1.Vector) + MyVector3.ProductoCruzado(q1.Vector, q2.Vector);
        var newW = (q1.w * q2.w) - MyVector3.ProductoPunto(q1.Vector, q2.Vector);
        return new MyQuaternion(newW, newVector);
    }

    public static MyVector3 operator *(MyQuaternion q,  MyVector3 v) => Rotate(q, v);

    public static explicit operator Quaternion(MyQuaternion q) => new Quaternion(q.x,q.y,q.z,q.w);
    public static explicit operator MyQuaternion(Quaternion q) => new MyQuaternion(q.w, q.x, q.y, q.z);

    #endregion

    #region TO_STRING
    //SOBRESCRITURA DEL METODO "ToString()" PARA PODER IMPRIMIR EN CONSOLA
    // SE USA LA CLASE STRINGBUILDER PARA GENERAR EL STRING DE NUESTRO QUATERNION
    private readonly StringBuilder _builder;
    private StringBuilder CreateBuilder()
    {
        var builder = new StringBuilder("MyQuaternion()");
        for (int i = 0; i < 4; i++)
        {
            builder.Insert(builder.Length - 1, i < 3 ? this[i].ToString() + "," : this[i].ToString());
        }

        return builder;
    }
    public override string ToString()
    {
        return _builder.ToString();
    }
    #endregion
}
