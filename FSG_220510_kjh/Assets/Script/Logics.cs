using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logics : MonoBehaviour
{
    // 게임의 상태 값
    public enum GameState {Init = 0, Ready =1, Play = 2, Pause = 3, Fail = 4};
    private GameState gamestate = GameState.Init;

    public Button startBtn;
    public Text countText;
    public Text scoreText;

    // 상태 값 관리
    public GameState GetState{
        get{
            return this.gamestate;
        }
    }

    public void SetGamestate(GameState state){
        this.gamestate = state;
    }

    public enum PLAYER_DIR { NONE = 0, LEFT = 1, RIGHT = 2, UP = 3, DOWN = 4, U_LEFT = 5, U_RIGHT = 6, D_LEFT = 7, D_RIGHT = 8 };

    [Header("GAME UI")]
    public GameObject readyUI;
    public GameObject gameoverUI;

    [Header("상태")]
    public PLAYER_DIR DIR = PLAYER_DIR.NONE;

    [Header("게임 스피드")]
    public float speed = 10f;
    // 총알 스피드 값
    public float bulletspeed;
    public GameObject bullet;
    public GameObject player;

    private int score;

    private static Logics instance = null;


    // 총알을 저장할 배열.
    private GameObject[] bullets = new GameObject[100];
    // 총알의 인덱스 값.
    private int bulletPrimaryNumber = 0;

    private int hp = 3; 
    public int HP{
        get{
            return this.hp;
        }
    }

    // 피격시 HP 감소
    public void Destroyplayer() {

        if (this.hp <= 0) {
            SetGamestate(GameState.Fail);
            return;
        }
            this.hp--;
    }

    public static Logics Instance {
        get {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate(bullet, Vector3.zero, Quaternion.identity, this.transform);
            bullets[i].SetActive(false);
        }
    }

    private void FixedUpdate(){
        switch (gamestate){
            case GameState.Init: 
                
                break;
            case GameState.Ready: 
                
                break;
            case GameState.Play:
                PlayMovementLogic();
                break;
            case GameState.Pause: 
                
                break;
            case GameState.Fail: 
                
                break;
        }

        
    }
    private void Update(){

        Debug.Log("==> " + count);

        switch (gamestate){
            case GameState.Init:
                InitGame();
                break;
            case GameState.Ready:
                ReadyGame();
                break;
            case GameState.Play:
                PlayUI();
                break;
            case GameState.Pause:
                PauseGame();
                break;
            case GameState.Fail:
                FailGame();
                break;
        }
    }

    public void InitGame() {
        if (!readyUI.gameObject.activeSelf){
            readyUI.gameObject.SetActive(true);
        }
        scoreText.gameObject.SetActive(false);
        startBtn.enabled = true;
        startBtn.interactable = true;

        this.hp = 3;
        SetGamestate(GameState.Ready);
    }

    public void ReadyGame() {

    }

    public void PlayUI(){
        if (!scoreText.gameObject.activeSelf) scoreText.gameObject.SetActive(true);
        scoreText.text = $"Score : {score.ToString()}";

    }

    public void PlayMovementLogic() {
        if (DIR == PLAYER_DIR.LEFT)
        {
            player.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
        if (DIR == PLAYER_DIR.RIGHT)
        {
            player.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
        if (DIR == PLAYER_DIR.UP)
        {
            player.transform.position += new Vector3(0, speed * Time.fixedDeltaTime, 0);
        }
        if (DIR == PLAYER_DIR.DOWN)
        {
            player.transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
        }

        if (DIR == PLAYER_DIR.U_LEFT)
        {
            player.transform.position -= new Vector3(speed * Time.fixedDeltaTime, -(speed * Time.fixedDeltaTime), 0);
        }
        else if (DIR == PLAYER_DIR.U_RIGHT)
        {
            player.transform.position += new Vector3(speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime, 0);
        }
        if (DIR == PLAYER_DIR.D_LEFT)
        {
            player.transform.position -= new Vector3(speed * Time.fixedDeltaTime, speed * Time.fixedDeltaTime, 0);
        }
        else if (DIR == PLAYER_DIR.D_RIGHT)
        {
            player.transform.position += new Vector3(speed * Time.fixedDeltaTime, -(speed * Time.fixedDeltaTime), 0);
        }
    }

    public void PauseGame() {

    }

    public void FailGame() {
        if (!gameoverUI.gameObject.activeSelf){
            scoreText.gameObject.SetActive(false);
            gameoverUI.gameObject.SetActive(true);
        }
    }

    public void Fire()
    { // 총알이 생성되어 발사되는 함수.
        if (bulletPrimaryNumber >= bullets.Length) bulletPrimaryNumber = 0;
        bullets[bulletPrimaryNumber].SetActive(true);
        bullets[bulletPrimaryNumber].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        bullets[bulletPrimaryNumber].transform.position = player.transform.position;
        bullets[bulletPrimaryNumber].GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        bulletPrimaryNumber++;
    }

    private float count = 4f;
    public void StartGame(){
        startBtn.enabled = false;
        startBtn.interactable = false;
        StartCoroutine(StartCountCourutine());
        countText.gameObject.SetActive(true);
    }

    IEnumerator StartCountCourutine(){

        while (true)
        {

            countText.text = count.ToString("0");

            if (count < 1)
            {
                count = 4f;
                SetGamestate(GameState.Play);
                readyUI.gameObject.SetActive(false);
                countText.gameObject.SetActive(false);
                break;
            }
            count -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    public void LoadScore(){

    }

    public void InitScore(){
        score = 0;
    }

    public void IncreaseScore(){
        score += 100;
    }

    public void SaveScore(){

    }
}
