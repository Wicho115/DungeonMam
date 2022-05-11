using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class puntuacion : MonoBehaviour
    
{
    private float score;
    private TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = score.ToString("f0");
        score+=Time.deltaTime;
        
    }
}
