using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{
    // 사용자 입력을 총괄하는 클래스 (스크립트)



    private void Update()
    {
        // 게임 객체 이동, 공격, 게임 전반적인 이동 등이 해당

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //위로 이동
            Logics.Instance.DIR = Logics.PLAYER_DIR.UP;
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //아래로 이동
            Logics.Instance.DIR = Logics.PLAYER_DIR.DOWN;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //왼쪽 이동
            Logics.Instance.DIR = Logics.PLAYER_DIR.LEFT;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            //오른쪽 이동
            Logics.Instance.DIR = Logics.PLAYER_DIR.RIGHT;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }

        //대각선 이동
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.U_LEFT;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.U_RIGHT;
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.D_LEFT;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.D_RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //공격할 것
            Logics.Instance.Fire();
        }
    }
}
