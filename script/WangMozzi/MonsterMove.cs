using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterMove : MonoBehaviour
{
    Rigidbody rigid;
    public Vector3 nextMove;

    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        //float time = Random.Range(2f, 5f);
        Invoke("Think", 1);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = nextMove;
        Vector3 frontVec = rigid.position + nextMove;

        //��ĭ �� �κоƷ� ������ ray�� ��
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        // ���̸� ���� ���� ������Ʈ�� Ž�� 
        // RaycastHit raycast;
        // if (Physics.Raycast(frontVec, Vector3.down, out raycast, 0.5f, LayerMask.GetMask("Platform")))
        // raycast <-             

        if (Physics.Raycast(frontVec, Vector3.down, 0.5f, LayerMask.GetMask("Platform")))
        {

        }
        else 
        {
            Debug.Log("���! �� ���� ��������");
        }
        

        //Ž���� ������Ʈ�� null : �� �տ� ������ ����
        //if (raycast.collider == null)
        //{
            
        //}

    }

    void Think()
    {
        int randX = Random.Range(-1, 2);
        int randZ = Random.Range(-1, 2);
        nextMove = new Vector3(randX, 0, randZ);
        float time = Random.Range(2f, 5f);
        Invoke("Think", time);


       

    }

}
