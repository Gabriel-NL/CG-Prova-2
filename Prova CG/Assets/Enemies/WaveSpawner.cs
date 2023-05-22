using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject fallenbot;

    [SerializeField]
    private float interval = 10f;

    [SerializeField]
    public GameObject spawnerPivot;


    // Start is called before the first frame update
    void Start()
    {

        int x = 0;
        while (x < 10)
        {
            StartCoroutine(EnemySpawner(interval, fallenbot));
            x++;
        }

    }

    private IEnumerator EnemySpawner(float interval, GameObject enemy)
    {

        Vector3 pivotPosition = transform.position;
        yield return new WaitForSeconds(interval);
        float posX = pivotPosition.x + Random.Range(-10, 10);
        float posZ = pivotPosition.z + Random.Range(-10, 10);


        GameObject newEnemy = Instantiate(enemy, new Vector3(posX, pivotPosition.y, posZ), Quaternion.identity);
    }
}
