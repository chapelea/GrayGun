using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public bool gameOver = false;
    public float bgSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            transform.Translate(Vector3.up * bgSpeed * Time.deltaTime);
            if (transform.position.y < -2)//lower
            {
                transform.position = new Vector3(transform.position.x, 2.25f, 0);
            }
        }
    }
}
