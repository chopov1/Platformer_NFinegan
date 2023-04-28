using UnityEngine;
using TMPro;


public class UIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    public float Score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"{Score}";
    }
}
