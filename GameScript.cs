using UnityEngine;
using System.Collections;
using System.Resources;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

    public NetworkScript network;

    public class Ability
    {
        public string name = "";
        public int range = 0;
        public int cooldown = 1;
        public int damage = 0;
        public bool toggleable = false;
        public bool aoe = false;
        public bool block = false;
    }

    public Text[] AbilityTexts = new Text[4]; //store the texts in the UI for the abilities

    public class Hero
    {
        public string heroClassName;
        public int armor;
        public int health;
        public Ability[] abilityList = new Ability[2];
        public GameObject gameObject; //this is a reference to the game object to use for instantiating this hero type
    }

    public class PlayerHero
    {
        public Hero heroType;
        public GameObject gameObject;

        public void SetHero(Hero herotype)
        {
            heroType = herotype;
        }

    }
    
    public Ability wand = new Ability();
    public Ability blast = new Ability();

    public Ability swing = new Ability();
    public Ability block = new Ability();

    public Hero mage = new Hero();
    public Hero warrior = new Hero();

    public Hero[] heroList;

    public PlayerHero player;

    public Camera gameCamera;

    // Use this for initialization
    void Start () {

        SetAbilityText(); //were putting this in a function cos we probably want to move it around later (ie when we show the main UI after picking a class)

        network = GetComponent<NetworkScript>();

        gameCamera = GameObject.Find("GameCamera").GetComponent<Camera>();

        //abilities
        wand.name = "Wand";
        wand.range = 3;
        wand.cooldown = 1;
        wand.damage = 10;
        wand.toggleable = true;

        blast.name = "Blast";
        blast.range = 2;
        blast.cooldown = 5;
        blast.damage = 10;
        blast.toggleable = false;
        blast.aoe = true;

        swing.name = "Swing";
        swing.range = 1;
        swing.cooldown = 1;
        swing.damage = 10;
        swing.toggleable = true;

        block.name = "Block";
        block.cooldown = 5;
        block.block = true;

        //classes
        warrior.heroClassName = "Warrior";
        warrior.armor = 10;
        warrior.health = 100;
        warrior.abilityList[0] = swing;
        warrior.abilityList[1] = block;
        warrior.gameObject = (GameObject)Resources.Load("Players/Warrior", typeof(GameObject));

        mage.heroClassName = "Mage";
        mage.armor = 0;
        mage.health = 50;
        mage.abilityList[0] = wand;
        mage.abilityList[1] = blast;
        mage.gameObject = (GameObject)Resources.Load("Players/Mage", typeof(GameObject));

        heroList = new Hero[2] { warrior, mage };
    }

    public void ChooseHero(int heroType)
    {
        player = new PlayerHero();
        player.SetHero(heroList[heroType]);

        player.gameObject = Instantiate(player.heroType.gameObject);

        //picking is done, hide canvas
        GameObject.Find("ClassChoiceCanvas").SetActive(false);
        gameCamera.transform.SetParent(player.gameObject.transform);
        gameCamera.transform.localPosition = new Vector3(0, .5f, .5f);
        gameCamera.transform.localEulerAngles = new Vector3(60, 180, 180);

        
    }

    void SetAbilityText() //where we actually get references to the text objects
    {

    }

    void UpdateAbilityText() //where we update the values of the text objects to the right abilities
    {

    }

    // Update is called once per frame
    void Update ()
    {
    }
}
