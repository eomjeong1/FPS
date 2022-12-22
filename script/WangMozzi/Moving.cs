using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public string PlayerName;
    public float speed = 5;
    public float Pl_HP = 100;
    public int Pl_Atk = 20;
    public int Pmoney;
    public Text Havemoney;
    public Text NowAtk;
    public GameManager gameManager;
    UINickName uiNickname;
    bool IsLive = true;
    public GameObject store;
    public object effect;
    public Slider HPBar;
    Weapons wp;
    public StageManager stage;
    public Text NowHP;
    public int FullHP;
    public Text status;

    private void Start()
    {
        Havemoney.text = Pmoney + "골드";
        NowAtk.text = $"공격력 : {Pl_Atk}";
        NowHP.text = $"체력 : {Pl_HP}";
        uiNickname = GetComponentInChildren<UINickName>();
        uiNickname.Setname(PlayerName);
        Debug.Log("내 체력 :" + Pl_HP);
        Pmoney = 0;

        HPBar = GetComponentInChildren<Slider>();

        // 이 밑에는 seller로 옮김.
        //Weapon1.onClick.AddListener(() =>
        //{
        //    Weapons weapon = Weapon1.GetComponent<Weapons>();
        //    Btn1(weapon);
        //});
        //Weapon2.onClick.AddListener(() =>
        //{
        //    Weapons weapon = Weapon2.GetComponent<Weapons>();
        //    Btn2(weapon);
        //});
        //Weapon3.onClick.AddListener(() =>
        //{
        //    Weapons weapon = Weapon3.GetComponent<Weapons>();
        //    Btn3(weapon);
        //});
        //Weapon4.onClick.AddListener(() =>
        //{
        //    Weapons weapon = Weapon4.GetComponent<Weapons>();
        //    Btn4(weapon);
        //});
        //Weapon5.onClick.AddListener(() =>
        //{
        //    Weapons weapon = Weapon5.GetComponent<Weapons>();
        //    Btn5(weapon);
        //});
        //Weapon6.onClick.AddListener(() =>
        //{
        //    Weapons weapon = Weapon6.GetComponent<Weapons>();
        //    Btn6(weapon);
        //});
    }

    void Update()
    {

        if (IsLive)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            transform.position += new Vector3(h, 0, v) * 0.005f * speed;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();

        if (npc)
        {
            Debug.Log("NPC와 충돌했습니다. - " + npc.NPCName);

            uiNickname.SetColor(Color.magenta);
            npc.uiNickname.SetColor(Color.magenta);

            status.text = "안녕하세요. 회복을 드리는 NPC입니다.";
            if (Pmoney >= 10)
            {
                Pmoney -= 10;
                HPBar.value = (float)Pl_HP / FullHP;
                npc.heal = 30;
                Pl_HP += npc.heal;
                Pl_HP = Mathf.Clamp(Pl_HP, 0, 100);
                NowHP.text = $"체력 : {Pl_HP}";
                Havemoney.text = Pmoney + "골드";


                status.text = $"체력이 + {npc.heal} + 만큼 회복되었습니다.";
                Debug.Log("내 체력 :" + Pl_HP);

                Object effect = Resources.Load("healeffect");
                Instantiate(effect, transform);
            }

            if (Pmoney < 10)
            {
                status.text = "돈이 부족합니다. 돈벌어오세요";

            }
        }

        Cubeseller seller = collision.gameObject.GetComponent<Cubeseller>();
        if (seller)
        {
            ShopManager.OpenShopUI();

        }


        CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
        if (enemy)
        {



            Debug.Log("Enemy와 충돌했습니다. - " + enemy.EnemyName);

            uiNickname.SetColor(Color.red);
            enemy.uiNickname.SetColor(Color.red);

            Pl_HP -= enemy.En_Atk;
            Pl_HP = Mathf.Clamp(Pl_HP, 0, 100);
            HPBar.value = (float)Pl_HP / FullHP;
            NowHP.text = $"체력 : {Pl_HP}";

            enemy.En_HP -= Pl_Atk;
            enemy.HPBar.value = (float)enemy.En_HP / enemy.FullHP;
            status.text = $"적 체력 : {enemy.En_HP}";

            if (Pl_HP <= 0)
            {
                gameManager.Gameover();
                Destroy(gameObject);
                status.text = "나 사망";

                IsLive = false;
                return;
            }
            status.text = $"내 체력 : {Pl_HP}";


            /*enemy.En_HP -= Pl_Atk;
            enemy.HPBar.value = (float)enemy.En_HP / enemy.FullHP;
            Debug.Log("적 체력 :" + enemy.En_HP);*/

            if (enemy.En_HP <= 0)
            {
                status.text = "적 사망";
                enemy.EnemyDie();
                Pmoney += enemy.Mmoney;
                Havemoney.text = Pmoney + "골드";
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();

        if (npc)
        {
            status.text = "용사님의 안전을 기원합니다.";

            uiNickname.SetOriginColor();
            npc.uiNickname.SetOriginColor();
        }

        Cubeseller seller = collision.gameObject.GetComponent<Cubeseller>();
        if (seller)
        {
            ShopManager.CloseShopUI();

            CubeEnemy enemy = collision.gameObject.GetComponent<CubeEnemy>();
            if (enemy)
            {
                Debug.Log("Enemy와 떨어졌습니다. - " + enemy.EnemyName);

                uiNickname.SetOriginColor();
                enemy.uiNickname.SetOriginColor();
            }

        }
    }
}



