using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{

    private float pollingTime = 1f;
    private float time;
    private int frameCount;
    public Text FpsText;

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString();

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
