using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelBtnPrefab;
    [SerializeField] private Transform _scrolWiewTransform;

    private int _levelCount;

    private void Start()
    {
        _levelCount = SceneManager.sceneCountInBuildSettings - 1;

        InitializeLevelButtons();
    }
    private void InitializeLevelButtons()
    {
        for (int i = 0;i < _levelCount; i++)
        {
            int levelIndex = i + 1;
            GameObject btn = Instantiate(_levelBtnPrefab, _scrolWiewTransform.position, Quaternion.identity);
            btn.transform.parent = _scrolWiewTransform;
            btn.GetComponentInChildren<Text>().text = "" + levelIndex;
            Button btnComponent = btn.GetComponent<Button>();
            btnComponent.onClick.AddListener(()=> LevelButtonTrigger(levelIndex));
        }
    }
    private void LevelButtonTrigger(int level)
    {
        LevelManager.Instance.LoadLevelWithCoroutine(level);
    }
}
