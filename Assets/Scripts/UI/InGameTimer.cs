using TMPro;
using UnityEngine;

public class InGameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    public static float time { get; private set; }

    private void Update()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
