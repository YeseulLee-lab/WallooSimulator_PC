using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance { get; private set; } = null;
    private Coroutine _loadingCor { get; set; } = null;
    public Define.SceneName curSceneName { get; set; } = Define.SceneName.None;
    private Define.SceneName _targetSceneName = Define.SceneName.None;
    public Define.SceneName targetSceneName
    {
        get
        {
            return _targetSceneName;
        }
        set
        {
            _targetSceneName = value;
        }
    }

    #region Unity Life Cycle
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            curSceneName = Define.SceneName.Login;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        _loadingCor = null;
        Instance = null;
    }

    private void Start()
    {
        Invoke(nameof(SetFrame), 1f);
    }
    #endregion

    private void SetFrame()
    {
        Application.targetFrameRate = 60;
    }

    /// <summary>
    /// 게임 씬 제외 일반적인 씬 이동
    /// </summary>
    /// <param name="targetScene">이동할 씬 이름(게임씬 제외)</param>
    /// <param name="delay">forced delay 설정</param>
    public void SwitchScene(Define.SceneName targetScene, float delay = 0f)
    {
        targetSceneName = targetScene;

        _loadingCor = StartCoroutine(LoadSceneWithDelay(Define.SceneName.Loading, delay));
    }

    /// <summary>
    /// 이미 이동할 씬 위치가 설정되어 있는 경우 호출(ex 로딩씬) 
    /// </summary>
    /// <param name="delay"></param>
    public void SwitchScene(float delay = 0f)
    {
        if (targetSceneName == Define.SceneName.None)
        {
            Debug.Log("이동 씬 설정 안 되어있음");
            return;
        }
        _loadingCor = StartCoroutine(LoadSceneWithDelay(targetSceneName, delay));
    }

    private IEnumerator LoadSceneWithDelay(Define.SceneName targetScene, float delay)
    {
        yield return new WaitForSeconds(delay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene.ToString());

        // 씬 로드가 완료될 때까지 대기
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        curSceneName = targetSceneName;
    }
}
