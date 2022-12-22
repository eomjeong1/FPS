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
        Havemoney.text = Pmoney + "���";
        NowAtk.text = $"���ݷ� : {Pl_Atk}";
        NowHP.text = $"ü�� : {Pl_HP}";
        uiNickname = GetComponentInChildren<UINickName>();
        uiNickname.Setname(PlayerName);
        Debug.Log("�� ü�� :" + Pl_HP);
        Pmoney = 0;

        HPBar = GetComponentInChildren<Slider>();

        // �� �ؿ��� seller�� �ű�.
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
            Debug.Log("NPC�� �浹�߽��ϴ�. - " + npc.NPCName);

            uiNickname.SetColor(Color.magenta);
            npc.uiNickname.SetColor(Color.magenta);

            status.text = "�ȳ��ϼ���. ȸ���� �帮�� NPC�Դϴ�.";
            if (Pmoney >= 10)
            {
                Pmoney -= 10;
                HPBar.value = (float)Pl_HP / FullHP;
                npc.heal = 30;
                Pl_HP += npc.heal;
                Pl_HP = Mathf.Clamp(Pl_HP, 0, 100);
                NowHP.text = $"ü�� : {Pl_HP}";
                Havemoney.text = Pmoney + "���";


                status.text = $"ü���� + {npc.heal} + ��ŭ ȸ���Ǿ����ϴ�.";
                Debug.Log("�� ü�� :" + Pl_HP);

                Object effect = Resources.Load("healeffect");
                Instantiate(effect, transform);
            }

            if (Pmoney < 10)
            {
                status.text = "���� �����մϴ�. �����������";

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



            Debug.Log("Enemy�� �浹�߽��ϴ�. - " + enemy.EnemyName);

            uiNickname.SetColor(Color.red);
            enemy.uiNickname.SetColor(Color.red);

            Pl_HP -= enemy.En_Atk;
            Pl_HP = Mathf.Clamp(Pl_HP, 0, 100);
            HPBar.value = (float)Pl_HP / FullHP;
            NowHP.text = $"ü�� : {Pl_HP}";

            enemy.En_HP -= Pl_Atk;
            enemy.HPBar.value = (float)enemy.En_HP / enemy.FullHP;
            status.text = $"�� ü�� : {enemy.En_HP}";

            if (Pl_HP <= 0)
            {
                gameManager.Gameover();
                Destroy(gameObject);
                status.text = "�� ���";

                IsLive = false;
                return;
            }
            status.text = $"�� ü�� : {Pl_HP}";


            /*enemy.En_HP -= Pl_Atk;
            enemy.HPBar.value = (float)enemy.En_HP / enemy.FullHP;
            Debug.Log("�� ü�� :" + enemy.En_HP);*/

            if (enemy.En_HP <= 0)
            {
                status.text = "�� ���";
                enemy.EnemyDie();
                Pmoney += enemy.Mmoney;
                Havemoney.text = Pmoney + "���";
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        CubeNPC npc = collision.gameObject.GetComponent<CubeNPC>();

        if (npc)
        {
            status.text = "������ ������ ����մϴ�.";

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
                Debug.Log("Enemy�� ���������ϴ�. - " + enemy.EnemyName);

                uiNickname.SetOriginColor();
                enemy.uiNickname.SetOriginColor();
            }

        }
    }
}



