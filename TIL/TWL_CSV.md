# TIL_CSV


```c#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

[System.Serializable]
public class ItemData
{
    public int      ID;
    public string   Name;
    public string   Type;
    public string   Rairty;
    public string   Descripton;
    public float    Attack;
    public bool     AttackPercent;
    public float    Defence;
    public bool     DefencePercent;
    public float    Health;
    public bool     HealthPercent;
    public float    CritChance;
    public bool     CritChancePercent;
    public float    CritDamage;
    public bool     CritDamagePercent;
    public string   Effect;
    public int      Cost;
    public int      StackMaxCount;
}
[System.Serializable]
public class SellItemData
{
    public int ProductID;
    public List<int> OriginID;
    public string ProductName;
    public string ProductDescription;
    public string PriceType;
    public int Price;
    public bool IsStack;
    public int StackCount;
}
[System.Serializable]
public class EnemyData
{
    public int      ID;
    public string   Name;
    public string   Descripton;
    public List<int> DropItemID;
    public int      DropGold;
    public float    Attack;
    public float    AttackSpeed;
    public float    Defence;
    public float    MoveSpeed;
    public float    Health;
    public float    CritChance;
    public float    CritDamage;
}
[System.Serializable]
public class StagaData
{
    public int       ID;
    public int       ChapterNum;
    public int       StageNum;
    public float     CurStageModifier;
    public string    StageName;
    public int       SlayEnemyCount;
    public List<int> SummonEnemyIDList;

}

[Serializable]
public class UserData
{
    public int       UserID;
    public string    Nickname;
    public int       Level;
    public int       Experience;
    public int       Gold;
    public int       Diamonds;
    public int       PlayTimeInSeconds;
    //public string    LastLogin;         // Unity의 JsonUtolity는 DataTime 자료형 지원 안함
    public Inventory Inventory;
    public ClearStageData ClearStage;
}

[Serializable]
public class Inventory
{
    public List<ItemData> Items;
    //public Equipment Equipment;
}

[Serializable]
public class ClearStageData
{

    
}

public class DataManager : SingletonDDOL<DataManager>
{
    private readonly string csvItemDBPath = "CSV/ItemDB";
    private readonly string csvSellItemDBPath = "CSV/SellItemDB";
    private readonly string csvEnemyDBPath = "CSV/EnemyDB";
    private readonly string csvStageDBPath = "CSV/StageDB";

    private readonly string jsonUserDataPath = Application.dataPath + "/userdata.json";

    private StringBuilder strBuilder = new StringBuilder();
    public CSVController CsvController = new CSVController();
    public JsonController JsonController = new JsonController();

    private Dictionary<int, ItemData> itemDB = new Dictionary<int, ItemData>();
    private Dictionary<int, EnemyData> enemyDB = new Dictionary<int, EnemyData>();
    private Dictionary<int, StagaData> stageDB = new Dictionary<int, StagaData>();
    private Dictionary<int, SellItemData> sellItemDB = new Dictionary<int, SellItemData>();
    public Dictionary<int, ItemData> ItemDB { get => itemDB; }
    public Dictionary<int, SellItemData> SellItemDB { get => sellItemDB; }
    public Dictionary<int, EnemyData> EnemyDB { get => enemyDB; }
    public Dictionary<int, StagaData> StageDB { get => stageDB; }

    Inventory inventory = new Inventory();
    UserData userData = new UserData();

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        itemDB = CsvController.ItemCSVRead(csvItemDBPath);
        sellItemDB = CsvController.SellItemCSVRead(csvSellItemDBPath);
        enemyDB = CsvController.EnemyCSVRead(csvEnemyDBPath);
        stageDB = CsvController.StageCSVRead(csvStageDBPath);

        inventory.Items = new List<ItemData>();
        inventory.Items.Add(ItemDB[1000]);
        inventory.Items.Add(ItemDB[2000]);

        userData.UserID = 12345;
        userData.Nickname = "지존 감자탕";
        userData.Level = 10;
        userData.Experience = 100052;
        userData.Gold = 999999;
        userData.Diamonds = 9999;
        userData.PlayTimeInSeconds = 72000;
        userData.Inventory = inventory;

    

        ////ToDoCode : 저장할데이터를 쓰는 코드 테스트 부분

        strBuilder.Clear();
        //strBuilder.Append(csvSaveFilePath);
        //CsvController.Write(strBuilder.ToString(), saveData);
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.S)) //데이터 세이브
        {
            JsonController.SaveUserData(userData, jsonUserDataPath);
        }
        else if (Input.GetKeyDown(KeyCode.L)) //데이터 로드
        {
            userData = JsonController.LoadUserData(jsonUserDataPath);

            Debug.Log($"로드한 닉네임  : {userData.Nickname}");
            Debug.Log($"로드한 레벨  : {userData.Level}");
        }
        else if(Input.GetKeyDown(KeyCode.D)) // 데이터 갱신
        {
            userData.Nickname += "1";
            userData.Level += 10;

            Debug.Log($"닉네임 변경 : {userData.Nickname}");
            Debug.Log($"레벨 변경 : {userData.Level}");
        }
    }

}

using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public class CSVController
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))"; //한 행에 대한 데이터 분리를 위한 세퍼레이트(분리자)
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";//가져온 CSV데이터를 엔터단위로 끊기위한 분리자
    static char[] TRIM_CHARS = { '\"' }; //

    public Dictionary<int, ItemData> ItemCSVRead(string file)
    {
        Dictionary<int, ItemData> list = new Dictionary<int, ItemData>();
        TextAsset data = Resources.Load(file) as TextAsset;

        //가져온 텍스트 덩어리를 해당 분리자를 통해 분리한다.
        string[] lines = Regex.Split(data.text, LINE_SPLIT_RE);

        //해당 CSV 데이터에 헤더(카테고리) + 해당 자료형만 입력되있는 상태이므로 List 반환
        if (lines.Length <= 2) return list;


        string[] header = Regex.Split(lines[0], SPLIT_RE);  //해당 CSV 데이터에 헤더(카테고리)입력 -> Dictonary의 키값으로 사용
        string[] typeHeader = Regex.Split(lines[1], SPLIT_RE);   //해당 CSV 데이터에 자료형 입력 -> 해당 자료의 자료형 선정시 사용됨
        for (int i = 2; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue; //정보가 없으면 다음 행으로 이동

            ItemData item = new ItemData();
            item.ID = (int)DataTypeCheck(typeHeader[0], values[0]);
            item.Name = (string)DataTypeCheck(typeHeader[1], values[1]);
            item.Type = (string)DataTypeCheck(typeHeader[2], values[2]);
            item.Rairty = (string)DataTypeCheck(typeHeader[3], values[3]);
            item.Descripton = (string)DataTypeCheck(typeHeader[4], values[4]);
            item.Attack = (float)DataTypeCheck(typeHeader[5], values[5]); ;
            item.AttackPercent = (bool)DataTypeCheck(typeHeader[6], values[6]); ;
            item.Defence = (float)DataTypeCheck(typeHeader[7], values[7]);
            item.DefencePercent = (bool)DataTypeCheck(typeHeader[8], values[8]);
            item.Health = (float)DataTypeCheck(typeHeader[9], values[9]);
            item.HealthPercent = (bool)DataTypeCheck(typeHeader[10], values[10]);
            item.CritChance = (float)DataTypeCheck(typeHeader[11], values[11]);
            item.CritChancePercent = (bool)DataTypeCheck(typeHeader[12], values[12]);
            item.CritDamage = (float)DataTypeCheck(typeHeader[13], values[13]);
            item.CritDamagePercent = (bool)DataTypeCheck(typeHeader[14], values[14]);
            item.Effect = (string)DataTypeCheck(typeHeader[15], values[15]);
            item.Cost = (int)DataTypeCheck(typeHeader[16], values[16]);
            item.StackMaxCount = (int)DataTypeCheck(typeHeader[17], values[17]);
            list[item.ID] = item;

        }
        return list;
    }
    public Dictionary<int, EnemyData> EnemyCSVRead(string file)
    {
        Dictionary<int, EnemyData> list = new Dictionary<int, EnemyData>();
        TextAsset data = Resources.Load(file) as TextAsset;

        //가져온 텍스트 덩어리를 해당 분리자를 통해 분리한다.
        string[] lines = Regex.Split(data.text, LINE_SPLIT_RE);

        //해당 CSV 데이터에 헤더(카테고리) + 해당 자료형만 입력되있는 상태이므로 List 반환
        if (lines.Length <= 2) return list;

        string[] header = Regex.Split(lines[0], SPLIT_RE);  //해당 CSV 데이터에 헤더(카테고리)입력 -> Dictonary의 키값으로 사용
        string[] typeHeader = Regex.Split(lines[1], SPLIT_RE);   //해당 CSV 데이터에 자료형 입력 -> 해당 자료의 자료형 선정시 사용됨
        for (int i = 2; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue; //정보가 없으면 다음 행으로 이동

            EnemyData enemy = new EnemyData();
            enemy.ID = (int)DataTypeCheck(typeHeader[0], values[0]);
            enemy.Name = (string)DataTypeCheck(typeHeader[1], values[1]);
            enemy.Descripton = (string)DataTypeCheck(typeHeader[2], values[2]);
            enemy.DropItemID = (List<int>)DataTypeCheck(typeHeader[3], values[3]);
            enemy.DropGold = (int)DataTypeCheck(typeHeader[4], values[4]);
            enemy.Attack = (float)DataTypeCheck(typeHeader[5], values[5]); ;
            enemy.AttackSpeed = (float)DataTypeCheck(typeHeader[6], values[6]);
            enemy.Defence = (float)DataTypeCheck(typeHeader[7], values[7]);
            enemy.MoveSpeed = (float)DataTypeCheck(typeHeader[8], values[8]);
            enemy.Health = (float)DataTypeCheck(typeHeader[9], values[9]);
            enemy.CritChance = (float)DataTypeCheck(typeHeader[10], values[10]);
            enemy.CritDamage = (float)DataTypeCheck(typeHeader[11], values[11]);
            list[enemy.ID] = enemy;

        }
        return list;
    }
    public Dictionary<int, StagaData> StageCSVRead(string file)
    {
        Dictionary<int, StagaData> list = new Dictionary<int, StagaData>();
        TextAsset data = Resources.Load(file) as TextAsset;

        //가져온 텍스트 덩어리를 해당 분리자를 통해 분리한다.
        string[] lines = Regex.Split(data.text, LINE_SPLIT_RE);

        //해당 CSV 데이터에 헤더(카테고리) + 해당 자료형만 입력되있는 상태이므로 List 반환
        if (lines.Length <= 2) return list;

        string[] header = Regex.Split(lines[0], SPLIT_RE);  //해당 CSV 데이터에 헤더(카테고리)입력 -> Dictonary의 키값으로 사용
        string[] typeHeader = Regex.Split(lines[1], SPLIT_RE);   //해당 CSV 데이터에 자료형 입력 -> 해당 자료의 자료형 선정시 사용됨
        for (int i = 2; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue; //정보가 없으면 다음 행으로 이동

            StagaData stage = new StagaData();
            stage.ID = (int)DataTypeCheck(typeHeader[0], values[0]);
            stage.ChapterNum = (int)DataTypeCheck(typeHeader[1], values[1]);
            stage.StageNum = (int)DataTypeCheck(typeHeader[2], values[2]);
            stage.CurStageModifier = (float)DataTypeCheck(typeHeader[3], values[3]);
            stage.StageName = (string)DataTypeCheck(typeHeader[4], values[4]);
            stage.SlayEnemyCount = (int)DataTypeCheck(typeHeader[5], values[5]); ;
            stage.SummonEnemyIDList = (List<int>)DataTypeCheck(typeHeader[6], values[6]);
            list[stage.ID] = stage;

        }
        return list;
    }
    public Dictionary<int, SellItemData> SellItemCSVRead(string file)
    {
        Dictionary<int, SellItemData> list = new Dictionary<int, SellItemData>();
        TextAsset data = Resources.Load(file) as TextAsset;

        //가져온 텍스트 덩어리를 해당 분리자를 통해 분리한다.
        string[] lines = Regex.Split(data.text, LINE_SPLIT_RE);

        //해당 CSV 데이터에 헤더(카테고리) + 해당 자료형만 입력되있는 상태이므로 List 반환
        if (lines.Length <= 2) return list;


        string[] header = Regex.Split(lines[0], SPLIT_RE);  //해당 CSV 데이터에 헤더(카테고리)입력 -> Dictonary의 키값으로 사용
        string[] typeHeader = Regex.Split(lines[1], SPLIT_RE);   //해당 CSV 데이터에 자료형 입력 -> 해당 자료의 자료형 선정시 사용됨
        for (int i = 2; i < lines.Length; i++)
        {
            string[] values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue; //정보가 없으면 다음 행으로 이동

            SellItemData sellitem = new SellItemData();
            sellitem.ProductID = (int)DataTypeCheck(typeHeader[0], values[0]);
            sellitem.OriginID = (List<int>)DataTypeCheck(typeHeader[1], values[1]);
            sellitem.ProductName = (string)DataTypeCheck(typeHeader[2], values[2]);
            sellitem.ProductDescription = (string)DataTypeCheck(typeHeader[3], values[3]);
            sellitem.PriceType = (string)DataTypeCheck(typeHeader[4], values[4]);
            sellitem.Price = (int)DataTypeCheck(typeHeader[5], values[5]); ;
            sellitem.IsStack = (bool)DataTypeCheck(typeHeader[6], values[6]); ;
            sellitem.StackCount = (int)DataTypeCheck(typeHeader[7], values[7]);
            list[sellitem.ProductID] = sellitem;

        }
        return list;
    }

    private object DataTypeCheck(string type, string value)
    {
        switch (type)
        {
            case "int":
                return int.Parse(value);  //int
            case "float":
                return float.Parse(value); //float
            case "double":
                return double.Parse(value);  //double
            case "bool":
                return bool.Parse(value);  //bool
            case "string":
                return value;  //string
            //default:
            //    throw new Exception($"지원하지 않는 자료형 타입입니다.: {type}");
        }

        if (type.StartsWith("List<"))
        {
            var itemType = type.Substring(5, type.Length - 6);

            //CSV 데이터 셀 서식이 Text이기에 \" 철자를 제거해야된다. 
            value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");

            switch (itemType)
            {
                case "int":
                    return value.Split(',').Select(int.Parse).ToList();  //List<int>
                case "float":
                    return value.Split(',').Select(float.Parse).ToList(); //List<float>
                case "double":
                    return value.Split(',').Select(double.Parse).ToList(); //List<double>
                case "bool":
                    return value.Split(',').Select(bool.Parse).ToList();  //List<bool>
                case "string":
                    return value.Split(',').Select(v => v.Trim()).ToList();  //List<string>

            }
        }


        return null;
    }

}
```