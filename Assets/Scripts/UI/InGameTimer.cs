using TMPro;
using UnityEngine;

public class InGameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    public static float ElapsedTime { get; private set; }

    private void Awake()
    {
        ElapsedTime = 0f;
    }

    private void Update()
    {
            ElapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(ElapsedTime / 60);
            int seconds = Mathf.FloorToInt(ElapsedTime % 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
