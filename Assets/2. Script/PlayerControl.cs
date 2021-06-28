using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    public bool isJump = false; // ÷�� �������̾ƴϴϱ� false
    // Start is called before the first frame update
    public GameObject map; //3��° �� ���� ���� ����
    public GameObject coin;
    public Text UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward* speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)//�������� �ƴҶ��� �����̽������� ���� �� �� �ְ�
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 7f, ForceMode.Impulse);
            isJump = true;
        }
        
}
    private void OnCollisionEnter(Collision collision)
    {
        //�ƹ�������Ʈ
        //�浹������Ʈ�� �ٴ��̶�� �������¸� false���ش�.
        //==���� �������̾ƴϴ�. �ٴڿ� ���� ������ �� �±׷� 
        if (collision.transform.tag == "Floor")
        {
            isJump = false;
        }

        if (collision.transform.tag == "Key")
        {
            map.SetActive(true);
        }

        if (collision.transform.tag == "Coin")
        {
            coin.SetActive(false);
            UI.text = "����";
        }
        

    }
}
