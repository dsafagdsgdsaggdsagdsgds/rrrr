using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1;
    public bool isJump = false; // 첨엔 점프중이아니니까 false
    // Start is called before the first frame update
    public GameObject map; //3번째 맵 담을 공간 만듦
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

        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)//점프중이 아닐때만 스페이스누르면 점프 할 수 있게
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 7f, ForceMode.Impulse);
            isJump = true;
        }
        
}
    private void OnCollisionEnter(Collision collision)
    {
        //아무오브젝트
        //충돌오브젝트가 바닥이라면 점프상태를 false로준다.
        //==지금 점프중이아니다. 바닥에 별명 지어줄 것 태그로 
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
            UI.text = "성공";
        }
        

    }
}
