using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gray : MonoBehaviour
{
    public float speed = 5.0f;// Movement speed.
    private float fireRate = 0.25f;// Time between shots.
    private float canFire = 0.05f;// Time to check.

    [SerializeField] public bool canTripleShot  = false;
    [SerializeField] public bool canSpeedShot  = false;

    private bool damage1 = false;
    private bool damage2 = false;
    private bool garrison = false;
    private bool dress = false;
    private bool hasRifle = false;
    private bool hasShotgun = false;
    private bool hasShield = false;
    private bool ShieldD1 = false;
    private bool ShieldD2 = false;
    public bool isDead = false;

    public SpriteRenderer spriteRenderer;
    public GameHandeler G;

    // Default sprites.
    public Sprite defaultSprite;
    public Sprite damage1Sprite;
    public Sprite damage2Sprite;
    public Sprite shotgunSprite;
    public Sprite SgD1;
    public Sprite SgD2;
    public Sprite rifleSprite;
    public Sprite RiD1;
    public Sprite RiD2;
    public Sprite Shield1;
    public Sprite Shield1D1;
    public Sprite Shield1D2;
    public Sprite Shield2;
    public Sprite Shield2D1;
    public Sprite Shield2D2;
    public Sprite Shield3;
    public Sprite Shield3D1;
    public Sprite Shield3D2;

    // Garrison sprites.
    public Sprite garrisonSprite;
    public Sprite garrisonD1;
    public Sprite garrisonD2;
    public Sprite garrisonSg;
    public Sprite garrisonSgD1;
    public Sprite garrisonSgD2;
    public Sprite garrisonRi;
    public Sprite garrisonRiD1;
    public Sprite garrisonRiD2;
    public Sprite garrisonShield1;
    public Sprite garrisonShield1D1;
    public Sprite garrisonShield1D2;
    public Sprite garrisonShield2;
    public Sprite garrisonShield2D1;
    public Sprite garrisonShield2D2;
    public Sprite garrisonShield3;
    public Sprite garrisonShield3D1;
    public Sprite garrisonShield3D2;

    // Dress blues sprites.
    public Sprite dressSprite;
    public Sprite dressD1;
    public Sprite dressD2;
    public Sprite dressSg;
    public Sprite dressSgD1;
    public Sprite dressSgD2;
    public Sprite dressRi;
    public Sprite dressRiD1;
    public Sprite dressRiD2;
    public Sprite dressShield1;
    public Sprite dressShield1D1;
    public Sprite dressShield1D2;
    public Sprite dressShield2;
    public Sprite dressShield2D1;
    public Sprite dressShield2D2;
    public Sprite dressShield3;
    public Sprite dressShield3D1;
    public Sprite dressShield3D2;
    

    [SerializeField] private GameObject BulletPrefab = null;
    [SerializeField] private GameObject TripleShotPrefab = null;


    [SerializeField] private AudioClip pistolShot = null;
    [SerializeField] private AudioClip shotgunCock = null;
    [SerializeField] private AudioClip shotgunShot = null;
    [SerializeField] private AudioClip rifleReload = null;
    [SerializeField] private AudioClip grayDamage = null;
    [SerializeField] private AudioClip grayDeath = null;
    [SerializeField] private AudioClip shieldBlock = null;
    [SerializeField] private AudioClip grayDeath2 = null;

    public AudioSource audioSource;
    public float volume=0.5f;

    void Start()
    {
        transform.position = new Vector3(0,0,0);
        G = GameObject.Find("GameHandeler").GetComponent<GameHandeler>();
        audioSource = GameObject.Find("MainCamera").GetComponent<AudioSource>();
    }

    void Update()
    {
        Move(); // Moves the character.
        Bounds(); // Stops the player from going out of bounds.
        Shoot(); // Allows the player to shoot.
        Keys(); // Checks certain key inputs.
        ChangeSprite(); // Changes sprite when needed.

        
    }
     private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // -1 to 1
        // left to right
        // a to d

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        // deltaTime - converts from frames to actual seconds

    }
    void Bounds()
    {
        if (transform.position.y > 5)//upper
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
        if (transform.position.y < -5)//lower
        {
            transform.position = new Vector3(transform.position.x, -5, 0);
        }
        if (transform.position.x > 9)//right
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
        if (transform.position.x < -9)//left
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
    }
    private void Shoot()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > canFire && !isDead)
            {
                if(!canTripleShot && !canSpeedShot)
                {
                    audioSource.PlayOneShot(pistolShot, volume);
                    Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                }
                else if(canSpeedShot)
                {
                    fireRate = 0;
                    audioSource.PlayOneShot(pistolShot, volume);
                    Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                } 
                else
                {
                    audioSource.PlayOneShot(shotgunShot, volume);
                    Instantiate(TripleShotPrefab, transform.position, Quaternion.identity);
                }
                canFire = Time.time + fireRate;
            }
            
        }
    }
    private void Keys()
    {
        if (Input.GetKey(KeyCode.Equals) && Input.GetKeyDown(KeyCode.B))
        {
            dress = true;
            garrison = false;
        }
        if (Input.GetKey(KeyCode.Equals) && Input.GetKeyDown(KeyCode.G))
        {
            garrison = true;
            dress = false;
        }
        if (Input.GetKey(KeyCode.Equals) && Input.GetKey(KeyCode.Backspace))
        {
            garrison = false;
            dress = false;
        }
    }
    private void ChangeSprite()
    {
        if(!garrison && !dress)
        {
            spriteRenderer.sprite = defaultSprite;
        }
        if(damage1)
        {
            spriteRenderer.sprite = damage1Sprite;
        }
        else if(damage2)
        {
            spriteRenderer.sprite = damage2Sprite;
        }
        if(hasShotgun)
        {
            spriteRenderer.sprite = shotgunSprite;
            if(damage1)
            {
                spriteRenderer.sprite = SgD1;
            }
            else if(damage2)
            {
                spriteRenderer.sprite = SgD2;
            }
        }
        if(hasRifle)
        {
            spriteRenderer.sprite = rifleSprite;
            if(damage1)
            {
                spriteRenderer.sprite = RiD1;
            }
            else if(damage2)
            {
                spriteRenderer.sprite = RiD2;
            }
        }
        if (hasShield)
        {
            spriteRenderer.sprite = Shield1;
            if(damage1)
            {
                spriteRenderer.sprite = Shield1D1;
            }
            else if(damage2)
            {
                spriteRenderer.sprite = Shield1D2;
            }

            if (ShieldD1)
            {
                spriteRenderer.sprite = Shield2;
                if (damage1)
                {
                    spriteRenderer.sprite = Shield2D1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = Shield2D2;
                }
            }
            else if (ShieldD2)
            {
                spriteRenderer.sprite = Shield3;
                if (damage1)
                {
                    spriteRenderer.sprite = Shield3D1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = Shield3D2;
                }
            }
        }

        if(garrison)
        {
            spriteRenderer.sprite = garrisonSprite;
            if(damage1)
            {
                spriteRenderer.sprite = garrisonD1;
            }
            else if(damage2)
            {
                spriteRenderer.sprite = garrisonD2;
            }
            if(hasShotgun)
            {
                spriteRenderer.sprite = garrisonSg;
                if(damage1)
                {
                    spriteRenderer.sprite = garrisonSgD1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = garrisonSgD2;
                }
            }
            if(hasRifle)
            {
                spriteRenderer.sprite = garrisonRi;
                if(damage1)
                {
                    spriteRenderer.sprite = garrisonRiD1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = garrisonRiD2;
                }
            }
            if (hasShield)
            {
                spriteRenderer.sprite = garrisonShield1;
                if(damage1)
                {
                    spriteRenderer.sprite = garrisonShield1D1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = garrisonShield1D2;
                }

                if (ShieldD1)
                {
                    spriteRenderer.sprite = garrisonShield2;
                    if (damage1)
                    {
                        spriteRenderer.sprite = garrisonShield2D1;
                    }
                    else if(damage2)
                    {
                        spriteRenderer.sprite = garrisonShield2D2;
                    }
                }
                else if (ShieldD2)
                {
                    spriteRenderer.sprite = garrisonShield3;
                    if (damage1)
                    {
                        spriteRenderer.sprite = garrisonShield3D1;
                    }
                    else if(damage2)
                    {
                        spriteRenderer.sprite = garrisonShield3D2;
                    }
                }
            }
        }

        if(dress)
        {
            spriteRenderer.sprite = dressSprite;
            if(damage1)
            {
                spriteRenderer.sprite = dressD1;
            }
            else if(damage2)
            {
                spriteRenderer.sprite = dressD2;
            }
            if(hasShotgun)
            {
                spriteRenderer.sprite = dressSg;
                if(damage1)
                {
                    spriteRenderer.sprite = dressSgD1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = dressSgD2;
                }
            }
            if(hasRifle)
            {
                spriteRenderer.sprite = dressRi;
                if(damage1)
                {
                    spriteRenderer.sprite = dressRiD1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = dressRiD2;
                }
            }
            if (hasShield)
            {
                spriteRenderer.sprite = dressShield1;
                if(damage1)
                {
                    spriteRenderer.sprite = dressShield1D1;
                }
                else if(damage2)
                {
                    spriteRenderer.sprite = dressShield1D2;
                }

                if (ShieldD1)
                {
                    spriteRenderer.sprite = dressShield2;
                    if (damage1)
                    {
                        spriteRenderer.sprite = dressShield2D1;
                    }
                    else if(damage2)
                    {
                        spriteRenderer.sprite = dressShield2D2;
                    }
                }
                else if (ShieldD2)
                {
                    spriteRenderer.sprite = dressShield3;
                    if (damage1)
                    {
                        spriteRenderer.sprite = dressShield3D1;
                    }
                    else if(damage2)
                    {
                        spriteRenderer.sprite =dressShield3D2;
                    }
                }
            }
        }
        
    }

    public IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
        hasShotgun = false;
    }

    public void TripleShotPowerUp()
    {
        audioSource.PlayOneShot(shotgunCock, 1.5f);
        hasRifle = false;
        canSpeedShot = false;
        hasShield = false;
        fireRate = 0.25f;
        hasShotgun = true;
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }

    public IEnumerator SpeedShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedShot = false;
        hasRifle = false;
        fireRate = 0.25f;
    }

    public void SpeedShotPowerUp()
    {
        audioSource.PlayOneShot(rifleReload, volume);
        hasShotgun = false;
        canTripleShot = false;
        hasShield = false;
        hasRifle = true;
        canSpeedShot = true;
        StartCoroutine(SpeedShotPowerDown());
    }

    public void ShieldPowerUp()
    {
        hasRifle = false;
        canSpeedShot = false;
        hasShotgun = false;
        canTripleShot = false;
        fireRate = 0.25f;
        hasShield = true;
        ShieldD1 = false;
        ShieldD2 = false;
    }

    public void TakeDamage()
    {
        if(!damage1 && !damage2) {
            if (hasShield)
            {
                if (!ShieldD1 && !ShieldD2)
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    ShieldD1 = true;
                }
                else if (ShieldD1)
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    ShieldD1 = false;
                    ShieldD2 = true;
                }
                else
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    hasShield = false;
                }
            }
            else
            {
                audioSource.PlayOneShot(grayDamage, 1.0f);
                damage1 = true;
            }
        } else if(damage1) {
            if (hasShield)
            {
                if (!ShieldD1 && !ShieldD2)
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    ShieldD1 = true;
                }
                else if (ShieldD1)
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    ShieldD1 = false;
                    ShieldD2 = true;
                }
                else
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    hasShield = false;
                }
            }
            else
            {
                audioSource.PlayOneShot(grayDamage, 1.0f);
                damage1 = false;
                damage2 = true;
            }
            
        } else {
            if (hasShield)
            {
                if (!ShieldD1 && !ShieldD2)
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    ShieldD1 = true;
                }
                else if (ShieldD1)
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    ShieldD1 = false;
                    ShieldD2 = true;
                }
                else
                {
                    audioSource.PlayOneShot(shieldBlock, volume);
                    hasShield = false;
                }
            }
            else
            {
                audioSource.PlayOneShot(grayDeath, volume);
                audioSource.PlayOneShot(grayDeath2, volume);
                isDead = true;
                G.gameOver();
                Destroy(this.gameObject);
            }
        }
    }
}
