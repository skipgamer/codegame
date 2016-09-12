using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

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

    public class Hero
    {
        public string heroClassName;
        public int armor;
        public int health;
        public Ability[] abilityList = new Ability[2];
    }

    public Ability wand = new Ability();
    public Ability blast = new Ability();

    public Ability swing = new Ability();
    public Ability block = new Ability();

    public Hero mage = new Hero();
    public Hero warrior = new Hero();

    // Use this for initialization
    void Start () {

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
        mage.heroClassName = "Mage";
        mage.armor = 0;
        mage.health = 50;
        mage.abilityList[0] = wand;
        mage.abilityList[1] = blast;
        
        warrior.heroClassName = "Warrior";
        warrior.armor = 10;
        warrior.health = 100;
        warrior.abilityList[0] = swing;
        warrior.abilityList[1] = block;
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
}
