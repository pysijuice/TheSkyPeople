using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text levelNameText;
    private float alpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelNameText.alpha = 0f;
        StartCoroutine(ChangeLevelNameText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeLevelNameText()
    {
        while (alpha <= 1)
        {
            alpha += 0.01f;
            levelNameText.alpha = alpha;
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(2f);
        while (alpha != 0)
        {
            alpha -= 0.01f;
            levelNameText.alpha = alpha;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
