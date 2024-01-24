using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField] private GameObject EnemyPrefab = null;
    [SerializeField] private GameObject GrayPrefab = null;
    private float time = 0.0f;
    private int count = 0;
    public float interpolationPeriod = 2.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            time += Time.deltaTime;
 
            if (time >= interpolationPeriod)
            {
                time = 0.0f;
                Instantiate(EnemyPrefab, new Vector3(Random.Range(-8.0f,8.0f), 5, 0), Quaternion.identity);
                count++;

                if(count % 20 == 0 && count != 0)
                {
                    interpolationPeriod /= 1.1f;
                }
            } 
        }       
    }

    public void BirthPlayer()
    {
        Instantiate(GrayPrefab, new Vector3(Random.Range(-8.0f,8.0f), 5, 0), Quaternion.identity);
        interpolationPeriod = 2.5f;
    }
}
