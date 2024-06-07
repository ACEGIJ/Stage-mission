using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    private int highScore;
    public Text resultTime;
    public Text bestTime;
    public GameObject resultUI;

    // Start is called before the first frame update
    void Start()
    {
        // HighScore를 초기화했는지 확인
        if (!PlayerPrefs.HasKey("HighScoreInitialized"))
        {
            PlayerPrefs.SetInt("HighScore", 999);
            PlayerPrefs.SetInt("HighScoreInitialized", 1); // 초기화 완료 표시
        }

        // HighScore 값을 가져오기
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Goal.goal) // Goal.goal이 적절하게 정의되었는지 확인 필요
        {
            resultUI.SetActive(true);
            int result = Mathf.FloorToInt(Timer.time); // Timer.time이 적절하게 정의되었는지 확인 필요
            resultTime.text = "ResultTime: " + result;
            bestTime.text = "BestTime: " + highScore;

            if (highScore > result)
            {
                PlayerPrefs.SetInt("HighScore", result);
                highScore = result; // 최신 값으로 업데이트
            }
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Reset HighScore")]
    public void ResetHighScore() // 메소드 이름 오타 수정
    {
        PlayerPrefs.DeleteKey("HighScoreInitialized");
        PlayerPrefs.SetInt("HighScore", 999);
        PlayerPrefs.SetInt("HighScoreInitialized", 1);
    }
}
