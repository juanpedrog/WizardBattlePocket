using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Controller : MonoBehaviour {
    public static Controller controller;
    public GameObject[] wizard;
    public GameObject[] heads;
    public GameObject[] headsEnemy;
    public GameObject[] wizardReserve;
    public GameObject[] wizardEnemy;
    public GameObject[] bosses;
    public GameObject[] backgrounds;
    public GameObject GameOver;
    public GameObject GameOverPlayer;
    public GameObject firstDiff,boss1Unblock,boss2Unblock,boss3Unblock;
    public int posPlayer,posEnemy;
    public string playerName,enemyName;
    public GameObject player;
    public bool isAlive = true,noDamage=true;
    public bool bossTime=false;
    public bool pause = true;
    public bool just1 = true;
    public bool just1player = true;
    public bool isAliveAgain = false;
    public bool boss1Block,boss2Block,boss3Block,boss1Image,boss2Image,boss3Image;
    public string datapath;
    public bool backgroundboss1,sound,music,principal,jumpenemy=true;
    public bool survivalMode;
    public float healthBar;
    public bool power,versus;
    public bool versusMode;
    public float score;
    public float score0 = 0;
    public bool floor;
    public BossesBlocks dataObject;
    public bool ending;
    // Use this for initialization
    void Start () {
        ending = false;
        boss1Block = false;
        backgroundboss1=false;
        survivalMode = false;
        versusMode = false;
        healthBar = 1;
        dataObject = new BossesBlocks();
        load();
	}
    void Awake()
    {
        datapath = Application.persistentDataPath + "/data.dat";
        principal = true;
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
        NotificationCenter.DefaultCenter().AddObserver(this, "soundBack");
        if (!sound)
        {
            AudioSource[] arr = GameObject.FindObjectsOfType<AudioSource>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!arr[i].tag.Equals("Music"))
                {
                    arr[i].mute = true;
                }
            }
        }
        else
        {
            AudioSource[] arr = GameObject.FindObjectsOfType<AudioSource>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!arr[i].tag.Equals("Music"))
                {
                    arr[i].mute = false;
                }
            }
            if (!music)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].tag.Equals("Music"))
                    {
                        arr[i].mute = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].tag.Equals("Music"))
                    {
                        arr[i].mute = false;
                    }
                }
            }
        }
	}
    void soundBack(Notification notification)
    {
        GetComponent<AudioSource>().Play();
    }
    public void charge()
    {
        Instantiate(wizard[posPlayer],new Vector3(-6.29f,0f,0f),Quaternion.identity);
    }
    public void jumpAndAttack()
    {
        player = GameObject.Find(playerName);

    }
    public void attack()
    {

    }
    public void unblockBoss1()
    {
        UnblockBoss1();
    }
    public void fillWizard()
    {
        for(int i = 0; i<wizardReserve.Length; i++)
        {
            wizardEnemy[i] = wizardReserve[i];
        }
    }
    //Methods to unblock bosses
    public void UnblockBoss1()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        boss1Block = true;
        dataObject.boss1 = boss1Block;
        bf.Serialize(file, dataObject);
        file.Close();
        boss1Image = true;

    }
    public void UnblockBoss2()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        boss2Block = true;
        dataObject.boss2 = boss2Block;
        bf.Serialize(file, dataObject);
        file.Close();
        boss2Image = true;

    }
    public void UnblockBoss3()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        boss3Block = true;
        dataObject.boss3 = boss3Block;
        bf.Serialize(file, dataObject);
        file.Close();
        boss3Image = true;
    }
    public void saveScore()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        if (score > dataObject.scoreMax)
        {
            dataObject.scoreMax = score;
        }
        bf.Serialize(file, dataObject);
        file.Close();

    }
    public void saveScoreSurvival()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        if (score > dataObject.scoreSurvival)
        {
            dataObject.scoreSurvival = score;
        }
        bf.Serialize(file, dataObject);
        file.Close();

    }
    public void saveScoreVersus()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        if (score > dataObject.scoreVersus)
        {
            dataObject.scoreVersus = score;
        }
        bf.Serialize(file, dataObject);
        file.Close();

    }
    public void load()
    {
        if (File.Exists(datapath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(datapath, FileMode.Open);
            dataObject = (BossesBlocks)bf.Deserialize(file);
            boss1Block = dataObject.boss1;
            boss2Block = dataObject.boss2;
            boss3Block = dataObject.boss3;
            file.Close();
        }
        else
        {
            Instantiate(firstDiff, new Vector3(-0.19f, -0.13356f, -4.64f),Quaternion.identity);
        }
    }
    public void unblockAttack()
    {
        Damage dam = GameObject.FindObjectOfType<Damage>();
        DamagePlayer play = GameObject.FindObjectOfType<DamagePlayer>();
        dam.enabled = true;
        play.enabled = true;
    }
    public float min()
    {
        switch (dataObject.difficulty)
        {
            case 1: return 2; 
            case 2: return 1; 
            case 3: return 0.5f;
        }
        return -1; 
    }
    public float max()
    {
        switch (dataObject.difficulty)
        {
            case 1: return 5f;
            case 2: return 3f;
            case 3: return 2.5f;
        }
        return -1;
    }
    public float minBoss()
    {
        switch (dataObject.difficulty)
        {
            case 1: return 1.5f;
            case 2: return 1;
            case 3: return 0.5f;
        }
        return -1;
    }
    public float maxBoss()
    {
        switch (dataObject.difficulty)
        {
            case 1: return 3.5f;
            case 2: return 2.1f;
            case 3: return 2.1f;
        }
        return -1;
    }
    public void saveDifficulty(int grade)
    {
        dataObject.difficulty = grade;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = new FileStream(datapath, FileMode.Create);
        bf.Serialize(file, dataObject);
        file.Close();
    }
    public int loadDifficulty()
    {
        return dataObject.difficulty;
    }
}
[Serializable]
public class BossesBlocks
{
    public bool boss1, boss2, boss3;
    public float scoreMax,scoreSurvival,scoreVersus;
    public int difficulty;
}
