using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    public GameObject enemy;

    float flag = 0;
    GameObject[] enemys = new GameObject[50];

    int enmyIndex = 0;

    public void Start()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i] = Instantiate(enemy, Vector3.zero, Quaternion.identity, this.transform);
            enemys[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Logics.Instance.GetState != Logics.GameState.Play) return;

        flag += Time.fixedDeltaTime;
        if (flag >= 4f)
        {
            int rd = Random.Range(0, 3);
            float x = Random.Range(-2f, 3);
            if (enmyIndex >= enemys.Length - 1) enmyIndex = 0;
            enemys[enmyIndex].GetComponent<Enemy>().InitEnemy((Enemy.EnemyType)rd, new Vector3(x, 7f, 0));
            flag = 0f;
            enmyIndex++;
        }
    }
}
