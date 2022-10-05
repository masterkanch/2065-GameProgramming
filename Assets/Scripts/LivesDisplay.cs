using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LivesText;
    
    public void UpdateLives(int lives){
        LivesText.text = $"Lives:{lives}";
    }
}
