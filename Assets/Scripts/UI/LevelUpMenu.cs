using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    [field: SerializeField] public bool isLevelUpScreen { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLevelUpScreen()
    {
        isLevelUpScreen = true;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideLevelUpScreen()
    {
        isLevelUpScreen = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
