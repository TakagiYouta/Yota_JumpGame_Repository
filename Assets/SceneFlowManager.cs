using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshProを使用する場合。通常のTextを使う場合は 「using UnityEngine.UI;」 に変更

public class SceneFlowManager : MonoBehaviour
{
    [Header("GameScene用設定")]
    [Tooltip("「ゲームスタート！」と表示するテキスト")]
    public TextMeshProUGUI gameStartText;

    private void Start()
    {
        // 現在開いているシーン名を取得
        string currentScene = SceneManager.GetActiveScene().name;

        // GameScene が読み込まれた時の処理
        if (currentScene == "GameScene")
        {
            StartCoroutine(HandleGameSceneRoutine());
        }
    }

    /// <summary>
    /// ゲームシーンでの1秒間メッセージ表示処理
    /// </summary>
    private IEnumerator HandleGameSceneRoutine()
    {
        if (gameStartText != null)
        {
            gameStartText.text = "ゲームスタート！";
            gameStartText.gameObject.SetActive(true);

            // 1秒間待機
            yield return new WaitForSeconds(1.0f);

            // テキストを非表示にする
            gameStartText.gameObject.SetActive(false);
        }
    }

    // --- ボタンから呼び出す関数 ---

    /// <summary>
    /// TitleScene -> GameScene へ移動
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// GameScene -> ClearScene へ移動 (ゲームクリア時に呼び出す)
    /// </summary>
    public void LoadClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }

    /// <summary>
    /// ClearScene -> TitleScene へ移動
    /// </summary>
    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

