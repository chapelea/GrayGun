using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -6.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triggered by " + collision.name);
        if(collision.tag == "Player")
        {
            Gray P = collision.GetComponent<Gray>();
            if(P != null)
            {
                if(tag == "ShotgunPowerup") {
                    //P.canTripleShot = true;
                    P.TripleShotPowerUp();
                } else if(tag == "RiflePowerup") {
                    P.SpeedShotPowerUp();
                } else if(tag == "ShieldPowerup") {
                    P.ShieldPowerUp();
                }
                
            }
            Destroy(this.gameObject);
        }
        
    }
}
