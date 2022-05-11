using System.Linq;
using System.Collections;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour, IComparable
{
    [Header("Level parameters")]
    [SerializeField, Range(1, 6)] private int level;
    [Space]
    [SerializeField] private Transform[] doors;
    [SerializeField] private Transform[] initialPos;
    
    [Header("Level Active Parameters")]
    [SerializeField] private bool isActive;
    
    private Wave[] waves;
    private CollisionSystem col;

    private int actualWave;

    private void Awake()
    {
        col = CollisionSystem.Instance;
        waves = Resources.LoadAll<Wave>("Waves/Level" + level);
    }

    public void StartLevel()
    {
        if (isActive) return;
        isActive = true;
        actualWave = -1;
        NextWave();
    }

    private IEnumerator WaveCoroutine(Wave wave, bool isLastWave)
    {
        //guarda el arreglo de enemigos en una variable local
        var enemies = wave.enemies;

        //declara el tiempo y el tiempo objetivo de cada "oleada" para hacer un contador
        var time = Time.time;
        var targetTime = time + wave.waveTime;

        for (int i = 0; i < enemies.Length; i++)
        {
            var enemyObj = enemies[i];
            var enemy = enemyObj.enemy;

            yield return new WaitForSeconds(enemyObj.waitForSpawnSeconds);

            var actualEnemy = Instantiate(enemy, doors[i % doors.Length].position, (Quaternion)MyQuaternion.identidad);
            col.enemies.Add(actualEnemy);

            actualEnemy.inicialPosition = initialPos[i % initialPos.Length];
        }

        if (isLastWave) yield return StartCoroutine(LastWaveCoroutine());
        else yield return StartCoroutine(DefaultWaveCoroutine(time, targetTime));

        NextWave();
    }

    private IEnumerator DefaultWaveCoroutine(float time, float targetTime)
    {
        do
        {
            time += Time.deltaTime;
            yield return null;
        } while (time < targetTime && col.enemies.Any());
    }

    private IEnumerator LastWaveCoroutine()
    {
        while(col.enemies.Any())
        {
            yield return null;
        }
    }

    private void StartWave(Wave wave, bool isLastWave)
    {
        StartCoroutine(WaveCoroutine(wave, isLastWave));
    }

    private void NextWave()
    {
        actualWave++;
        if(actualWave >= waves.Length)
        { 
            GameManager.Instance.NextLevel();
        }
        else
        {
            StartWave(waves[actualWave], actualWave == waves.Length - 1);
        }
    }

    public int CompareTo(object obj)
    {
        if(obj is LevelManager)
        {
            var manager = (LevelManager)obj;
            return manager.level > this.level ? -1 : 1;
        }
        else
        {
            return 1;
        }
    }
}
