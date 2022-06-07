using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public Sprite[] sprs;

    float speed = 0;
    public enum EnemyType { EnemyTypeA = 0, EnemyTypeB = 1, EnemyTypeC = 2 };
    public EnemyType enmeyType = EnemyType.EnemyTypeA;

    private void FixedUpdate()
    {
        // 그래서 적 객체가 포지션  Y값이 -3 보다 작으면 자동으로 비활성화 해주는 코드.
        if (this.transform.position.y <= -5f) this.gameObject.SetActive(false);

        this.transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }

    // 적 객체 초기화 해주는 코드.
    public void InitEnemy(EnemyType type, Vector3 pos)
    {
        // 스프라이트 변경해주는 코드
        this.GetComponent<SpriteRenderer>().sprite = sprs[(int)type];

        switch (type)
        {
            case EnemyType.EnemyTypeA: this.GetComponent<BoxCollider2D>().size = new Vector2(0.45f, 0.45f);
                break;
            case EnemyType.EnemyTypeB: this.GetComponent<BoxCollider2D>().size = new Vector2(0.3f, 0.8f);
                break;
            case EnemyType.EnemyTypeC:this.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
                break;
        }

        this.transform.position = pos;

        speed = (float)Random.Range(1, 5);

        // 비활성된녀석을 활성화 해주는것
        if (!this.gameObject.activeSelf) this.gameObject.SetActive(true);
    }

    public void DestroyEnemy(){
        this.gameObject.SetActive(false);
    }

}
