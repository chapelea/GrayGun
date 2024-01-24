using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;

    public SpriteRenderer spriteRenderer;

    public Sprite defaultSprite;
    public Sprite Var1Sprite;
    public Sprite Var2Sprite;
    public Sprite Var3Sprite;
    public Sprite Var4Sprite;
    public Sprite AlienEE;

    public bool isAlien = false;

    private bool gameOver = false;

    [SerializeField] private GameObject RiflePrefab = null;
    [SerializeField] private GameObject ShotgunPrefab = null;
    [SerializeField] private GameObject ShieldPrefab = null;

    private UIManager UI = null;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f,8.0f), 6, 0);
            ChangeSprite();
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
                P.TakeDamage();                
            }
        }
        else if (collision.tag == "Bullet")
        {
            Bullet B = collision.GetComponent<Bullet>();
            if (B != null)
            {
                B.Die();
            }
        }
        else if (collision.tag == "KillBar")
        {
            KillBar K = collision.GetComponent<KillBar>();
            if (K != null && K.gameOver)
            {
                gameOver = true;
                Die();
            }
        }
        if(UI != null && collision.tag != "KillBar")
        {
            if(isAlien)
            {
                UI.updateScore(500);
            }
            else
            {
                UI.updateScore(10);
            }
            Die();
        }
    }

    private void ChangeSprite()
    {
        int odds = Random.Range(1, 601);

        if(odds >= 1 && odds <= 100)
        {
            spriteRenderer.sprite = defaultSprite;
        }
        else if(odds <= 200)
        {
            spriteRenderer.sprite = Var1Sprite;
        }
        else if(odds <= 300)
        {
            spriteRenderer.sprite = Var2Sprite;
        }
        else if(odds <= 400)
        {
            spriteRenderer.sprite = Var2Sprite;
        }
        else if(odds <= 500)
        {
            spriteRenderer.sprite = Var3Sprite;
        }
        else if(odds < 600)
        {
            spriteRenderer.sprite = Var4Sprite;
        }
        else
        {
            spriteRenderer.sprite = AlienEE;
            isAlien = true;
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
        int odds = Random.Range(1, 21);
        if (gameOver)
        {
            odds = 5;
        }
        if (odds == 1)
        {
            Instantiate(RiflePrefab, transform.position, Quaternion.identity);
        }
        else if (odds == 10)
        {
            Instantiate(ShotgunPrefab, transform.position, Quaternion.identity);
        }
        else if (odds == 20)
        {
            Instantiate(ShieldPrefab, transform.position, Quaternion.identity);
        }
    }
}
