using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{
    // ����� �Է��� �Ѱ��ϴ� Ŭ���� (��ũ��Ʈ)



    private void Update()
    {
        // ���� ��ü �̵�, ����, ���� �������� �̵� ���� �ش�

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //���� �̵�
            Logics.Instance.DIR = Logics.PLAYER_DIR.UP;
        }

        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //�Ʒ��� �̵�
            Logics.Instance.DIR = Logics.PLAYER_DIR.DOWN;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //���� �̵�
            Logics.Instance.DIR = Logics.PLAYER_DIR.LEFT;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            //������ �̵�
            Logics.Instance.DIR = Logics.PLAYER_DIR.RIGHT;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
        }

        //�밢�� �̵�
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
            //������ ��
            Logics.Instance.Fire();
        }
    }
}
