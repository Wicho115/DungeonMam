using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MyVector3
{
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }
    
    public float magnitud => Mathf.Sqrt(x * x + y * y + z * z);
    public float magnitudCuadrada => x * x + y * y + z * z;
    public MyVector3 normalizado => Normalizar(this);

    public static MyVector3 cero => vectorCero;

    public MyVector3(float x, float y, float z = 0)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /* METODOS PARA CALCULOS DE VECTORES */

    /*
     * ESTOS METODOS SIRVEN PARA HACER CALCULOS ESPECIFICOS DE TIPO VECTOR COMO:
     * - NORMALIZACION DEL VECTOR
     * - MAGNITUD DEL VECTOR
     * - PRODUCTO PUNTO
     * - PRODUCTO CRUZ
     * - DISTANCIA ENTRE VECTORES
     */
    public static MyVector3 Normalizar(MyVector3 vector)
    {
        var magnitud = vector.magnitud;
        if(magnitud > 1E-05f)
        {
            return vector / magnitud;
        }
        return cero;
    }

    public void Normalizar()
    {
        var mag = magnitud;
        if (mag > 1E-05f)
        {
            this /=  magnitud;
        }
        this = cero;
    }

    // LA DISTANCIA ENTRE 3 VECTORES
    public static float Distancia(MyVector3 vector1, MyVector3 vector2)
    {
        var newX = vector1.x - vector2.x;
        var newY = vector1.y - vector2.y;
        var newZ = vector1.z - vector2.z;

        return Mathf.Sqrt(newX * newX + newY * newY + newZ * newZ);
    }

    public static float ProductoPunto(MyVector3 vector1, MyVector3 vector2)
    {
        return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
    }

    public static MyVector3 ProductoCruzado(MyVector3 vector1, MyVector3 vector2)
    {
        return new MyVector3((vector1.y * vector2.z) - (vector1.z * vector2.y),
                            (vector1.z * vector2.x) - (vector1.x * vector2.z),
                            (vector1.x * vector2.y) - (vector1.y * vector2.x));
    }

    #region MIEMBROS_SOLO_LECTURA
    /*
     * 
     * ESTOS MIEMBROS SON DE SOLO LECTURA, ES DECIR NO SE PUEDE VOLVER A ESCRIBIR SOBRE ELLOS
     * UNA VEZ INICIALIZADA SU INSTANCIA.
     * 
     * AL SER ALGUNOS MIEMBROS DE TIPO "static" GARANTIZAS POR PARTE DEL CÓDIGO QUE SOLO EXISTIRA
     * *UNA* SOLA INSTANCIA DEL TIPO, POR LO QUE SOLO SE INICIALIZA 1 VEZ Y ESE VALOR SE MANTENDRÁ PARA SIEMPRE
     * 
     */

    // Vector cero, sirve para denotar un vector sin valor
    private static readonly MyVector3 vectorCero = new MyVector3(0, 0);
    #endregion

    #region OPERADORES
    #region OPERADORES_GENERALES
    /*
     * ESTOS OPERADORES SON DE USO GENERAL, SIRVEN PARA COSAS ESPECIFICAS COMO ALTERNAR
     * EL SIGNO DE EL VECTOR
     */

    public static MyVector3 operator -(MyVector3 vector)
    {
        return new MyVector3(-vector.x, -vector.y, -vector.z);
    }
    #endregion

    #region OPERADORES_ESCALARES
    /*
     * 
     *  LOS OPERADORES SIRVEN PARA HACER OPERACIONES CON EL VECTOR SIN NECESIDAD DE UNA FUNCION
     *  SOLO SE REQUIERE HACER USO DE ELLOS ( "+" , "-" , "*" , "/")
     * 
     *  ESTOS OPERADORES SIRVEN SOLO PARA UNIDADES ESCALARES, ES DECIR
     *  "float", ESTOS OPERADORES NO PUEDEN SER USADOS ENTRE VECTORES   
     */
    public static MyVector3 operator +(MyVector3 vector, float valor)
    {
        return new MyVector3(vector.x + valor, vector.y + valor, vector.z + valor);
    }

    public static MyVector3 operator -(MyVector3 vector, float valor)
    {
        return new MyVector3(vector.x - valor, vector.y - valor, vector.z - valor);
    }

    public static MyVector3 operator *(MyVector3 vector, float valor)
    {
        return new MyVector3(vector.x * valor, vector.y * valor, vector.z * valor);
    }

    public static MyVector3 operator /(MyVector3 vector, float valor)
    {
        return new MyVector3(vector.x / valor, vector.y / valor, vector.z / valor);
    }
    #endregion

    #region OPERADORES_VECTORIALES
    /*
     * 
     *  LOS OPERADORES SIRVEN PARA HACER OPERACIONES CON EL VECTOR SIN NECESIDAD DE UNA FUNCION
     *  SOLO SE REQUIERE HACER USO DE ELLOS ( "+" , "-" , "*")
     * 
     *  ESTOS OPERADORES SIRVEN SOLO PARA UNIDADES VECTORIALES, ES DECIR
     *  "MyVector3", ESTOS OPERADORES NO PUEDEN SER USADOS ENTRE VALORES ESCALARES
     */
    public static MyVector3 operator +(MyVector3 vector1, MyVector3 vector2)
    {
        return new MyVector3(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
    }
    public static MyVector3 operator -(MyVector3 vector1, MyVector3 vector2)
    {
        return new MyVector3(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
    }
    public static MyVector3 operator *(MyVector3 vector1, MyVector3 vector2)
    {
        return new MyVector3(vector1.x * vector2.x, vector1.y * vector2.y, vector1.z * vector2.z);
    }
    #endregion
    #endregion
}
