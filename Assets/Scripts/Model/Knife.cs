using UnityEngine.UI;
using UnityEngine;


public class Knife : MonoBehaviour
{
    [SerializeField] private GameObject airMonster;
    [SerializeField] private GameObject rocet;
    [SerializeField] private GameObject air;
    [SerializeField] private GameObject lightW;
    [SerializeField] private Image molot;
    [SerializeField] private AudioSource luser;
    [SerializeField] private AudioSource ai;
    [SerializeField] private AudioSource tzong;
    [SerializeField] private AudioSource tsssss;
    [SerializeField] private AudioSource blyak;
    [SerializeField] private GameObject smoke;
    [SerializeField] private CircleCollider2D ballCollaider;
    private TouchScreenSystem touchScreenSystem;
    private LevelController levelController;
    private Animator anim;
    //public bool isGo;
    bool stopLine;
    private Rigidbody2D rg;
    private Image img;
    private AudioSource soundKnifeInTree;    
    [SerializeField] float speed = 0.1f;
    private GameObject halfMonster;
    private bool win;
    public bool _knife;
    public bool _superKnife;
    public bool _stone;
    public bool _poop;
    public bool _egg;
    public bool _tomate;
    public bool _ches;
    public bool _fire;
    public bool _water;
    public bool _racet;
    public bool _tykw;
    public bool _shark;
    public bool _meduza;
    public bool _carrot;
    public bool _bullet;
    public bool _silverBullet;
    public bool _bomb;
    public bool _churik;
    public bool _blessedSword;
    public bool _gas;
    public bool _cactus;
    public bool _papir;
    public bool _lightsaber;
    public bool _ball;
    public bool _arrow;
    public bool _pArrow;
    public bool _spear;
    public bool _molot;
    public bool _acid;
    public bool _glue;
    public bool _peel;
    public bool _molotov;
    public bool _waterGun;
    public bool _pepperGas;
    public bool _smellySock;
    public bool _rocet;
    public bool _forest;
    public bool _magic;
    public bool _word;
    public bool _air;
    public bool _firework;
    public bool _nuclear;
    public bool _godzy;
    public bool _light;
    public bool _dark;
    private bool isRotate;
    public bool inDrive;
    private bool scale1;
    private bool scale2;
    private bool scale3;
    private bool scale4;
    private bool scale5;
    private bool gameOver;
    void Awake()
    {
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
        rg = GetComponent<Rigidbody2D>();
        touchScreenSystem = FindObjectOfType<TouchScreenSystem>();
        levelController = FindObjectOfType<LevelController>();
        touchScreenSystem.GetKnife(this);
        soundKnifeInTree = GetComponent<AudioSource>();
        halfMonster = touchScreenSystem._halfMonster;
    }
    private void OnEnable()
    {
        if (levelController.data.sound)
        {
            ai.volume = PlayerPrefs.GetFloat(Constants.SOUND);
            tzong.volume = PlayerPrefs.GetFloat(Constants.SOUND);
            tsssss.volume = PlayerPrefs.GetFloat(Constants.SOUND);
            luser.volume = PlayerPrefs.GetFloat(Constants.SOUND);
            blyak.volume = PlayerPrefs.GetFloat(Constants.SOUND);
        }
    }
    public void SetTykw()
    {
        _tykw = true;
        smoke.SetActive(true);
    }
    public void SetAir()
    {
        _air = true;
        air.SetActive(true);

    }
    public void SetLight()
    {
        _light = true;
        lightW.SetActive(true);

    }
    public void SetBall()
    {
        _ball = true;
        ballCollaider.enabled = true;
    }
    public void KnifeGo()
    {
        if (gameOver)
            return;
        if (_word)
        {
            if (levelController.data.sound)
               luser.Play();
        }
        if (_rocet)
        {
            rocet.SetActive(true);
            Invoke(nameof(ResetFire), 0.5f);
        }

        if (  levelController.thisStageName =="Game" && levelController.data.gameStage == 4 && (_acid || _air || _arrow || _blessedSword || _bullet || _cactus || _churik || _dark || _ches || _fire || _forest || _glue || _godzy
            || _knife || _light || _lightsaber || _magic || _meduza || _molot || _papir || _pArrow || _peel || _shark || _silverBullet
            || _smellySock || _spear || _stone || _superKnife || _tykw || _water || _word || _bomb || _gas || _pepperGas))
        {
            levelController.IsMor();
        }
        if (levelController.thisStageName == "Technopolis" && levelController.data.technoStage == 1 && !_bullet && !_silverBullet
            && !_rocet && !_nuclear && levelController.monster.gameObject.transform.localPosition.x < 120
            && levelController.monster.gameObject.transform.localPosition.x > -120)
        {
            Debug.Log("Attac");
            levelController.IsMor();
        }

        if (_waterGun||_magic)
        {
            gameObject.transform.localScale = Vector3.one;
        }
        levelController.ResetBlessedPartikl();
        inDrive = true;
        rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        if (_knife) levelController.PlaySound(0);
        else if (_tomate||_stone||_poop) levelController.PlaySound(1);
        else if (_bullet || _silverBullet)
        {
            levelController.Bullet();
            levelController.PlayBoom();
        }
            
    }
    private void ResetFire()
    {
        rocet.SetActive(false);
    }
    void FixedUpdate()
    {
        if (isRotate||_churik)
        {
            rg.gameObject.transform.Rotate(Vector3.forward, 30f);
        }
        /*if (isGo)
        {
            rg.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            inDrive = true;
        }*/
        if (inDrive)
        {
            var scaleGO = transform.localScale;
            var pos = transform.localPosition;
            if(pos.y > -500 && pos.y < -250 && !scale1)
            {
                scale1 = true;
                scaleGO.x = 0.9f;
                scaleGO.y = 0.9f;
                transform.localScale = scaleGO;
            }
            if (pos.y > -250 && pos.y < 0 && !scale2)
            {
                scale2 = true;
                scaleGO.x = 0.8f;
                scaleGO.y = 0.8f;
                transform.localScale = scaleGO;
            }
            if (pos.y > 0 && pos.y < 250 && !scale3)
            {
                scale3 = true;
                scaleGO.x = 0.7f;
                scaleGO.y = 0.7f;
                transform.localScale = scaleGO;
            }
            if (pos.y >250 && pos.y < 500 && !scale4)
            {
                scale4 = true;
                scaleGO.x = 0.6f;
                scaleGO.y = 0.6f;
                transform.localScale = scaleGO;
            }
            if (pos.y > 500 && !scale5)
            {
                scale5 = true;
                scaleGO.x = 0.5f;
                scaleGO.y = 0.5f;
                transform.localScale = scaleGO;
            }
        }
    }

    private void GetWin()
    {
        gameOver = true;
        levelController.Win();
        Destroy(gameObject);       
    }
    private void GetFall()
    {
        gameOver = true;
        isRotate = false;
        levelController.Fall();
        Destroy(gameObject);        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ring"))
        {
            if (win)
                return;
            Invoke(nameof(GetFall), 1f);
            return;
        }
        if (collision.gameObject.CompareTag("Hero"))
        {
            if (levelController.data.sound)
            {
                ai.Play();
            }
            return;
        }
        if (_knife)
        {
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Forest")
                || collision.gameObject.CompareTag("Sprut") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Nag")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                win = true;
                levelController.JustTomate();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
        }
        if (_superKnife)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                levelController.JustTomate();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon") )
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_tomate)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                //levelController.ResetAnim();
                levelController.currentAnim.SetBool("Stone", true);
                img.enabled = false;
                levelController.IsTomate();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.3f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsTomate();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_carrot)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                //rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                //levelController.ResetAnim();
                levelController.IsStone();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsCarrot();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_stone)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                rg.velocity = Vector2.zero;
                img.enabled = false;
                //rg.gravityScale = 1.5f;
                levelController.IsStone();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsStoneOut();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_poop || _smellySock)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                if (_smellySock)
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rg.velocity = Vector2.zero;
                    img.enabled = false;
                    levelController.AirElement();
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    img.enabled = false;
                    levelController.IsPoop();
                    Invoke(nameof(GetFall), 3f);
                }

            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (_smellySock)
                {
                    levelController.IsChucha();
                    Invoke(nameof(GetFall), 3f);
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    img.enabled = false;
                    levelController.IsPoop();
                    Invoke(nameof(GetFall), 3f);
                }

            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                win = true;
                if (_smellySock)
                {
                    levelController.IsMor();
                    Invoke(nameof(GetFall), 3f);
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    img.enabled = false;
                    levelController.IsPoop();
                    Invoke(nameof(GetFall), 3f);
                }

            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (_smellySock)
                {
                    levelController.IsChost();
                    Invoke(nameof(GetFall), 3f);
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    img.enabled = false;
                    levelController.IsPoop();
                    Invoke(nameof(GetFall), 3f);
                }

            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                if (_smellySock)
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rg.velocity = Vector2.zero;
                    img.enabled = false;
                    levelController.Dark();
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    img.enabled = false;
                    levelController.IsPoop();
                    Invoke(nameof(GetFall), 3f);
                }

            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (_smellySock)
                {
                    levelController.ShowSock();
                }
                levelController.IsPoop();
                Invoke(nameof(GetFall), 3f);
            }

        }
        if (_tykw)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Tykw")
                || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_shark)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Tykw")
                || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                levelController.IsTomate();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_bullet)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                //levelController.ResetAnim();
                levelController.IsBullet();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.DronDy();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2f);
            }
        }
        if (_silverBullet)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Ches")
                || collision.gameObject.CompareTag("Tykw"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                //levelController.ResetAnim();
                levelController.IsSilverBullet();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.DronDy();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.VampirDy();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_egg)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                //levelController.ResetAnim();
                levelController.IsEgg();
                Invoke(nameof(GetFall), 3f);
            }

        }
        if (_bomb)
        {
            if (collision.gameObject.CompareTag("Forest") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Chucha")
                || collision.gameObject.CompareTag("Mor") || collision.gameObject.CompareTag("Demon"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;

                levelController.IsForest();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir")|| collision.gameObject.CompareTag("Death"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                levelController.IsForest();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                levelController.ResetGreenLine();
                levelController.IsBomb();
                Invoke(nameof(GetWin), 5f);
            }            
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                levelController.IsForest();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsForest();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsForest();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsBomb();
                Invoke(nameof(GetFall), 4f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsBomb();
                Invoke(nameof(GetWin), 3f);
            }            
        }
        if (_churik)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                levelController.JustTomate();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_gas)
        {
            if (collision.gameObject.CompareTag("Forest")|| collision.gameObject.CompareTag("Iron")
                || collision.gameObject.CompareTag("Sprut") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Nag")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor")
                || collision.gameObject.CompareTag("Chucha") || collision.gameObject.CompareTag("Chost")
                || collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Death"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                //levelController.ResetAnim();
                levelController.IsGas();
                Invoke(nameof(GetFall), 4f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                levelController.ResetGreenLine();
                levelController.IsGas();
                Invoke(nameof(GetWin), 5f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                levelController.IsGas();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsGas();
                Invoke(nameof(GetWin), 3f);
            }
        }
        if (_blessedSword)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark")|| collision.gameObject.CompareTag("Ches")
                || collision.gameObject.CompareTag("Tykw") || collision.gameObject.CompareTag("Chucha")
                || collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                levelController.JustTomate();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 2f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.VampirDy();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.AirElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else 
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1.5f);
            }
        }
        if (_cactus)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsTomate();
                levelController.IsCactus();
                Invoke(nameof(GetFall), 2f);
            }
            
        }
        if (_papir)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                rg.velocity = Vector2.zero;
                img.enabled = false;
                //rg.gravityScale = 1.5f;
                levelController.IsPapir();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death")|| collision.gameObject.CompareTag("Iron"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    blyak.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();               
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Nag")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tsssss.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsPapir();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_lightsaber)
        {
            if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();               
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Mor"))
            {
                //levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2.5f);
            }
            else
            {
                win = true;
                levelController.JustTomate();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            
        }
        if (_ball)
        {
            if (collision.gameObject.CompareTag("Monster"))
            {
                if (levelController.data.sound)
                {
                    ai.Play();
                }                    
                if(levelController.ballPower == 1)
                {
                    levelController.IsBall();
                    rg.constraints = RigidbodyConstraints2D.FreezePosition;
                    img.enabled = false;
                    Invoke(nameof(GetWin), 3f);
                }
                levelController.IsBall();
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();                
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_arrow || _pArrow)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    levelController.ResetGreenLine();
                }
                if (_pArrow)
                {
                    levelController.IsArrow(1);
                }
                else
                {
                    levelController.IsArrow(0);
                }                
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2f);
            }
        }
        if (_spear)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                if (levelController.data.sound)
                {
                    ai.Play();
                }
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                //levelController.ResetAnim();
                levelController.IsSpear();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2f);
            }
        }
        if (_molot)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                levelController.IsMolot();
                collision.gameObject.SetActive(false);
                molot.sprite = levelController.data.currentMonster;
                molot.gameObject.SetActive(true);
                if (levelController.data.sound)
                {
                    blyak.Play();
                }
                win = true;                
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                        img.enabled = false;
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                //levelController.ResetAnim();
                //levelController.IsMolot();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2f);
            }
        }
        if (_acid || _ches)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Iron"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.sound)
                {
                    ai.Play();
                }
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();

                levelController.ResetGreenLine();
                levelController.IsAcid();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if ( collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir"))
            {
                if (_acid)
                {
                    win = true;
                    if (levelController.data.vibro)
                        Handheld.Vibrate();
                    levelController.IsMor();
                    Invoke(nameof(GetFall), 3f);
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    rg.velocity = Vector2.zero;
                    img.enabled = false;
                    levelController.VampirDy();
                    Invoke(nameof(GetWin), 3f);
                }
                
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.AcidWater();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2f);
            }
        }
        if (_waterGun)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                //levelController.ResetAnim();
                levelController.IsWater();
                Invoke(nameof(GetFall), 3f);
            }
            
        }       
        if (_glue)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark"))
            {
                if (levelController.data.sound)
                {
                    ai.Play();
                }
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.IsGlue();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();               
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Ches"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                anim.enabled = true;
                if (levelController.data.sound)
                    tsssss.Play();
                levelController.IsChes();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsGlue();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_molotov)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Shark")
                || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Chucha")
                || collision.gameObject.CompareTag("Mor"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    levelController.ResetGreenLine();
                }
                levelController.IsMolotov();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsMolotov();
                Invoke(nameof(GetFall), 3f);
            }
        }
        if (_pepperGas)
        {
            if (collision.gameObject.CompareTag("Forest") || collision.gameObject.CompareTag("Iron") 
                || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Stone")
                || collision.gameObject.CompareTag("Sprut") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Nag") || collision.gameObject.CompareTag("Chucha")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor")
                || collision.gameObject.CompareTag("Chost") || collision.gameObject.CompareTag("Vampir")
                || collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Death"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsPepperGas();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                levelController.ResetGreenLine();
                levelController.IsPepperGas();
                Invoke(nameof(GetWin), 5f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                levelController.IsPepperGas();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsPepperGas();
                Invoke(nameof(GetWin), 3f);
            }
        }
        if (_rocet)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                levelController.ResetGreenLine();
                levelController.IsRocet();
                Invoke(nameof(GetWin), 4f);
            }
            else if (collision.gameObject.CompareTag("Demon")|| collision.gameObject.CompareTag("Death"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                levelController.IsRocet(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                levelController.IsRocet(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsRocet(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsRocet(1);
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsRocet(1);
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsRocet();
                Invoke(nameof(GetWin), 3f);
            }
            
        }
        if (_peel)
        {
            if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir")|| collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();               
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Forest")
                || collision.gameObject.CompareTag("Shark") || collision.gameObject.CompareTag("Stone")
                || collision.gameObject.CompareTag("Sprut") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Nag")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    blyak.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement(0);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.IsPeel();
                Invoke(nameof(GetFall), 3f);
            }
            
        }
        if (_magic)
        {
            if (collision.gameObject.CompareTag("Godzy") || collision.gameObject.CompareTag("Water")
                || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Fire")
                || collision.gameObject.CompareTag("Air") || collision.gameObject.CompareTag("Light") 
                || collision.gameObject.CompareTag("Dark") || collision.gameObject.CompareTag("Vampir")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor")
                || collision.gameObject.CompareTag("Death"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1.5f);
                
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if(collision.gameObject.CompareTag("Demon"))
            {
                int rand = Random.Range(1, 3);
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                    if (levelController.data.sound)
                        tzong.Play();
                    isRotate = true;
                    Invoke(nameof(GetFall), 3f);
                }
                else
                {
                    rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                    img.enabled = false;
                    levelController.ResetGreenLine();
                    levelController.IsMagic();
                    Invoke(nameof(GetWin), 2f);
                }
                
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsMagic();
                Invoke(nameof(GetWin), 3f);
            }            
        }
        if (_word)
        {
            if (collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Forest")
                || collision.gameObject.CompareTag("Sprut") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Stone")
                || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Air")
                || collision.gameObject.CompareTag("Light") || collision.gameObject.CompareTag("Dark")
                || collision.gameObject.CompareTag("Nag") || collision.gameObject.CompareTag("Mor")
                || collision.gameObject.CompareTag("Chost") || collision.gameObject.CompareTag("Vampir")
                || collision.gameObject.CompareTag("Demon") || collision.gameObject.CompareTag("Death")
                || collision.gameObject.CompareTag("Dron"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 2f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.IsWord();                
                Invoke(nameof(GetWin), 3.5f);
            }           
              
        }
        if (_firework)
        {
            if (collision.gameObject.CompareTag("Forest") || collision.gameObject.CompareTag("Iron")
                || collision.gameObject.CompareTag("Sprut") || collision.gameObject.CompareTag("Godzy")
                || collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Stone")
                || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Air")
                || collision.gameObject.CompareTag("Light") || collision.gameObject.CompareTag("Dark")
                || collision.gameObject.CompareTag("Nag") || collision.gameObject.CompareTag("Chucha")
                || collision.gameObject.CompareTag("Vasilisk") || collision.gameObject.CompareTag("Mor")
                || collision.gameObject.CompareTag("Chost") )
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                //levelController.ResetAnim();
                levelController.IsFirework(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                levelController.IsFirework(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir")|| collision.gameObject.CompareTag("Demon")
                || collision.gameObject.CompareTag("Death" ))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                levelController.IsFirework(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                //levelController.ResetAnim();
                levelController.IsFirework(1);
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                levelController.ResetGreenLine();
                levelController.IsFirework();
                Invoke(nameof(GetFall), 5f);
            }           
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsFirework();
                Invoke(nameof(GetWin), 3f);
            }
        }
        if (_nuclear)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                levelController.ResetGreenLine();
                levelController.IsNuclear();
                Invoke(nameof(GetWin), 4f);
            }
            else
            {
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                levelController.ResetGreenLine();
                levelController.IsNuclear();
                Invoke(nameof(GetWin), 5f);
            }
            
        }
        if (_water)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement(1);
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_forest)
        {
            if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Ches") || collision.gameObject.CompareTag("Shark"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 1f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Tykw"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.color = Color.green;
                if (levelController.data.sound)
                    ai.Play();
                levelController.IsChes();
                rg.constraints = RigidbodyConstraints2D.None;
                rg.gravityScale = 0.2f;
                //isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                levelController.IsScat();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirDy();                
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
        }
        if (_air)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();                
                levelController.IsScat();
                levelController.ResetAnim();
                airMonster.SetActive(true);
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();               
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;                
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;                
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.AirElement();
                Invoke(nameof(GetFall), 3f);

            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                win = true;
                levelController.ResetAnim();
                airMonster.SetActive(true);
                Invoke(nameof(GetWin), 3f);
            }

        }
        if (_godzy)
        {
            if (collision.gameObject.CompareTag("Water"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.WaterElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();               
                levelController.IsChucha();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                img.color = Color.red;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                levelController.AirElement();
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.LightDy();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Iron"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }

                isRotate = true;
                Invoke(nameof(GetFall), 1f);
            }
            else 
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    if (levelController.bossFirstFight == false)
                    {
                        levelController.bossFirstFight = true;
                        GetFall();
                        return;
                    }
                    else
                    {
                        levelController.ResetYellowLine();
                    }
                }
                levelController.ResetAnim();
                halfMonster.SetActive(true);
                Invoke(nameof(GetWin), 3f);
            }
        }
        if (_fire)
        {
            if (collision.gameObject.CompareTag("Scat"))
            {
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsScat();
                levelController.ResetAnim();
                airMonster.SetActive(true);
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Dron"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                //levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Death"))
            {
                levelController.IsMor();
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                int rand = Random.Range(1, 3);
                if (levelController.data.sound)
                    tzong.Play();
                if (rand == 1)
                {
                    rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
                isRotate = true;
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Vampir") || collision.gameObject.CompareTag("Demon"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsMor();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Chost"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.IsChost();
                Invoke(nameof(GetFall), 3f);
            }
            else if ( collision.gameObject.CompareTag("Chucha"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                if (levelController.bossFight)
                {
                    levelController.ResetGreenLine();
                }
                levelController.IsMolotov();
                Invoke(nameof(GetWin), 3f);
            }
            else if (collision.gameObject.CompareTag("Fire"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.FireElement();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Air"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.AirElement();
                Invoke(nameof(GetFall), 3f);

            }
            else if (collision.gameObject.CompareTag("Light"))
            {
                win = true;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Light();
                Invoke(nameof(GetFall), 3f);
            }
            else if (collision.gameObject.CompareTag("Dark"))
            {
                win = true;
                rg.constraints = RigidbodyConstraints2D.FreezePositionY;
                rg.velocity = Vector2.zero;
                img.enabled = false;
                if (levelController.data.vibro)
                    Handheld.Vibrate();
                levelController.Dark();
                Invoke(nameof(GetFall), 3f);
            }
            else
            {
                win = true;
                levelController.ResetAnim();
                airMonster.SetActive(true);
                Invoke(nameof(GetWin), 3f);
            }

        }
    }
}
