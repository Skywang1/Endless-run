using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Highscore : MonoBehaviour
{
    [SerializeField] Text highscoreText;

    int highscore;

    public void DisplayHighscore (int score)
    {
        highscore = score;
        StartCoroutine(PlayTextAnimation());
    }

    IEnumerator PlayTextAnimation ()
    {
        float score = 0;
        float t = 0;
        while (t < 2f)
        {
            t += Time.deltaTime;
            float t2 = t / 2f;
            score = Mathf.Lerp(0, highscore, t2);
            highscoreText.text = $"{Mathf.CeilToInt(score):0000}";
            yield return null;
        }

        highscoreText.text = $"{(int)highscore:0000}";
    }
}