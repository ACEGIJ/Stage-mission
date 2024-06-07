using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    
    void RestartGame()
    {
        // 현재 활성화된 씬의 이름을 가져와서 다시 로드합니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
