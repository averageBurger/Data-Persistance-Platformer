using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(SpawnTimer());
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector2(25, -3), new Quaternion(0, 0, 0, 0));
    }

    IEnumerator SpawnTimer()
    {
        float time = 4f;
        while (player.gameIsRunning)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(time);
            time -= 0.1f;
            if (time < 1)
            {
                time = 1;
            }
        }
    }
}
