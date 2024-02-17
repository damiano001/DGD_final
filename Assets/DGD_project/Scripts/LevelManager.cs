using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaves 
{
    public float timeToStart;
    public GameObject wave;
}

public class LevelManager : MonoBehaviour 
{
    public EnemyWaves[] enemyWaves; 
    public GameObject powerUp;
    public float timeForNewPowerup;
    public GameObject[] planets;
    public float timeBetweenPlanets;
    public float planetsSpeed;
    List<GameObject> planetsList = new List<GameObject>();
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        powerUp.SetActive(true);
        StartCoroutine(GenerateWaves());
        StartCoroutine(PowerupBonusCreation());
        StartCoroutine(PlanetsCreation());
    }

    IEnumerator GenerateWaves()
    {
        int waveIndex = 0;
        float currentTime = 0;

        while (true)
        {
            float timeToNextWave = enemyWaves[waveIndex].timeToStart - currentTime;

            if (timeToNextWave > 0)
                yield return new WaitForSeconds(timeToNextWave);

            if (Player.instance != null)
                Instantiate(enemyWaves[waveIndex].wave);

            currentTime = enemyWaves[waveIndex].timeToStart;

            waveIndex = (waveIndex + 1) % enemyWaves.Length;
        }
    }

    IEnumerator PowerupBonusCreation() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(timeForNewPowerup);
            Instantiate(
                powerUp,
                new Vector2(
                    Random.Range(PlayerMovement.instance.borders.minX, PlayerMovement.instance.borders.maxX), 
                    mainCamera.ViewportToWorldPoint(Vector2.up).y + powerUp.GetComponent<Renderer>().bounds.size.y / 2
                ),
                Quaternion.identity
            );
        }
    }

    IEnumerator PlanetsCreation()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            planetsList.Add(planets[i]);
        }
        yield return new WaitForSeconds(10);
        while (true)
        {
            int randomIndex = Random.Range(0, planetsList.Count);
            GameObject newPlanet = Instantiate(planetsList[randomIndex]);
            planetsList.RemoveAt(randomIndex);

            if (planetsList.Count == 0)
            {
                for (int i = 0; i < planets.Length; i++)
                {
                    planetsList.Add(planets[i]);
                }
            }
            newPlanet.GetComponent<VerticalMovement>().speed = planetsSpeed;

            yield return new WaitForSeconds(timeBetweenPlanets);
        }
    }
}
