using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

sealed class Player : MonoBehaviour
{
    private int coins = 0;
    public Text showCoins;
    public AudioSource audioSource;
    public AudioClip coinSound;

    // gun inv
    public List<Gun> gunInv = new List<Gun>();
    public Gun gun;
    public int selectedGunIndex;

    // crystals
    public List<Crystal> crystalInv = new List<Crystal>();
    public Crystal crystal;
    public int selectedCrystalIndex;

    public Transform gunContainer;
    public Transform crystalContainer;
    public GameObject hand;

    public static bool allowShoot = true;
    static public int ammos = 0;

    public Text ammoAmount;
    public Text blockWarning;
    public Image esc;
    public Sprite esc1;
    public Sprite esc2;
    private bool isEscClicked = false;
    public bool isAllowedToEsc = false;

    public bool wait = false;
    public bool waitWarning = false;

    public List<GameObject> gunSkins = new List<GameObject>();
    public List<GameObject> pickaxeSkins = new List<GameObject>();

    public GameObject fadeEffect;
    public GameObject fadeEffectCanvas;
    public UnityEvent onEnterArea;
    public UnityEvent onStartArena;

    bool started = false;

    public UnityEvent onArenaDeath;

    public UnityEvent LoadLevelOne;
    public UnityEvent LoadLevelTwo;
    public UnityEvent LoadLevelThree;
    public UnityEvent LoadArena;
    public UnityEvent LoadMain;


    public void Kill()
    {
        if(coins > 0)
        {
            PlayerData data = SaveSystem.LoadCoins();
            coins = coins + data.coins;
            SaveSystem.SaveCoins(coins);
        }
        if (SceneManager.GetActiveScene().name == "Main")
        {
            LoadMain.Invoke();
        }
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            SceneManager.LoadScene(2);
        }
        if (SceneManager.GetActiveScene().name == "Arena")
        {
            onArenaDeath.Invoke();

            SceneManager.LoadScene(4);
        }
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            SceneManager.LoadScene(5);
        }
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            SceneManager.LoadScene(6);
        }
    }

    

    public void SwitchToGun(int index)
    {
        if (index > gunInv.Count) { return; }
        if (gunInv.Count == 0) { return; }

        for (int i = 0; i < gunInv.Count; i++)
        {
            gunInv[i].gameObject.SetActive(false);
        }
        gunInv[index].gameObject.SetActive(true);
        gun = gunInv[index];
        if(index == 0)
        {
            ammoAmount.text = "";
        }
    }

    public void SwitchToCrystal(int index)
    {
        if (index > crystalInv.Count) return;
        if (crystalInv.Count == 0) { return; }

        for (int i = 0; i < crystalInv.Count; i++)
        {
            if (crystalInv[i] == null)
            {
                crystalInv.Remove(crystalInv[i]);
            }
            else
            {
                crystalInv[i].gameObject.SetActive(false);
                hand.SetActive(false);
            }
        }
        crystalInv[index].gameObject.SetActive(true);
        hand.SetActive(true);
        crystal = crystalInv[index];
    }


    void Start()
    {
        if(showCoins != null)
        { showCoins.text = coins.ToString(); }
        SwitchToGun(0);
        SwitchToCrystal(0);

        PlayerData data = SaveSystem.LoadCurrentPickaxeSkin();
        if(data == null) { SaveSystem.SaveCurrentPickaxeSkin(0); }
        data = SaveSystem.LoadCurrentPickaxeSkin();
        Gun newGun = Instantiate(pickaxeSkins[data.currentPickaxeSkin], gunContainer).GetComponent<Gun>();
        newGun.gameObject.GetComponent<Pickaxe>().enabled = true;
        gunInv.Add(newGun);
        selectedGunIndex = gunInv.Count - 1;
        SwitchToGun(selectedGunIndex);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCrystalInput();

        if (Input.GetMouseButtonDown(1))
        {
            gun.ToggleAim();
        }
        if (Input.GetMouseButtonDown(0))
        {
            gun.Shoot();
     
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hand.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isAllowedToEsc)
        {
            if (!isEscClicked)
            {
                isEscClicked = true;
                esc.sprite = esc2;
                blockWarning.text = "Click the Esc button again to get back to menu!";
                Invoke("ClearEscButton", 3);
            }
            else
            {
                LoadMain.Invoke();
            }
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            selectedGunIndex += (int)Input.mouseScrollDelta.y;
            selectedGunIndex = selectedGunIndex % gunInv.Count;
            if (selectedGunIndex < 0) selectedGunIndex = gunInv.Count - 1;
            SwitchToGun(selectedGunIndex);
        }


    }
    void ClearEscButton()
    {
        isEscClicked = false;

        esc.sprite = esc1;
        blockWarning.text = "";

    }

    void CheckCrystalInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && crystalInv.Count > 0)
        {
             selectedCrystalIndex = 0;
             SwitchToCrystal(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && crystalInv.Count > 1)
        {
            selectedCrystalIndex = 1;
            SwitchToCrystal(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && crystalInv.Count > 2)
        {
            selectedCrystalIndex = 2;
            SwitchToCrystal(2);
        }
    }
    void waitSome()
    {
        wait = false;
    }
    void EnterArea()
    {
        SaveSystem.SaveCoins(coins);
        onEnterArea.Invoke();
    }

    void ClearWaitAndWarning()
    {
        blockWarning.text = string.Empty;
        waitWarning = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            coins = coins + 1;
            showCoins.text = coins.ToString();
            audioSource.clip = coinSound;
            audioSource.Play();
        }
        if (other.tag == "CoinOf5")
        {
            Destroy(other.gameObject);
            coins = coins + 5;
            showCoins.text = coins.ToString();
            audioSource.clip = coinSound;
            audioSource.Play();
        }
        if (other.tag == "GunItem")
        {
            if (Input.GetKey(KeyCode.E) && wait == false)
            {
                wait = true;
                Destroy(other.gameObject);
                Destroy(other);
                Gun newGun;
                if (other.GetComponent<GunItem>().gunPrefeb.tag == "AR")
                {
                    PlayerData data = SaveSystem.LoadCurrentGunSkin();
                    if (data == null) { SaveSystem.SaveCurrentGunSkin(0); data = SaveSystem.LoadCurrentGunSkin(); }
                    newGun = Instantiate(gunSkins[data.currentGunSkin], gunContainer).GetComponent<Gun>();
                }
                else
                {
                    newGun = Instantiate(other.GetComponent<GunItem>().gunPrefeb, gunContainer).GetComponent<Gun>();
                }
                gunInv.Add(newGun);
                selectedGunIndex = gunInv.Count - 1;
                SwitchToGun(selectedGunIndex);
                Invoke("waitSome", 0.3f);
            }
        }
        if (other.tag == "CrystalItem")
        {
            if (Input.GetKey(KeyCode.E) && other.GetComponent<CrystalItem>().pickable && wait == false)
            {
                wait = true;
                Invoke("waitSome", 0.3f);
                Destroy(other.gameObject);
                Destroy(other);
                hand.SetActive(true);
                Crystal newCrystal = Instantiate(other.GetComponent<CrystalItem>().crystalPrefeb, crystalContainer).GetComponent <Crystal>();
                crystalInv.Add(newCrystal);
                selectedCrystalIndex = crystalInv.Count - 1;
                SwitchToCrystal(selectedCrystalIndex);
                
            }
        }

        if(other.tag == "EnterArea")
        {
            if(wait == false)
            {
                wait = true;
                fadeEffectCanvas.SetActive(true);
                fadeEffect.SetActive(true);
                Invoke("EnterArea",1f);
            }
        }

        if (other.tag == "InteractableObject")
        {
            if (Input.GetMouseButton(0))
            {
                other.GetComponent<InteractableObject>().Act(gunInv[selectedGunIndex].toolID) ;
            }
        }

        if (other.tag == "Block")
        {
            if (!waitWarning)
            {
                blockWarning.text = "Barriar! You cant pass it without killing all the robot guards!";
                waitWarning = true;
                Invoke("ClearWaitAndWarning", 3f);
            }
        }
        if (other.tag == "Start" && !started)
        {
            started = true;
            onStartArena.Invoke();
        }
    }

}
