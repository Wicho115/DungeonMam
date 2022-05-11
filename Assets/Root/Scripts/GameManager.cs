using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private LevelManager[] levels;
    private int actualLevel = -1;

    private bool isWaiting = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        levels = FindObjectsOfType<LevelManager>();
        var list = levels.ToList();
        list.Sort();
        levels = list.ToArray();
    }

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        actualLevel++;
        if(actualLevel >= levels.Length)
        {
            //TERMINA EL JUEGO
        }
        else
        {
            StartCoroutine(NextLevelCoroutine(levels[actualLevel]));
        }
    }

    private IEnumerator NextLevelCoroutine(LevelManager level)
    {
        while (isWaiting)
        {
            yield return null;
        }

        isWaiting = true;

        if (actualLevel > 0) 
            levels[actualLevel - 1].gameObject.SetActive(false);

        levels[actualLevel].gameObject.SetActive(true);

        level.StartLevel();
        yield return new WaitForSeconds(5f);
        isWaiting = false;
    }
}
