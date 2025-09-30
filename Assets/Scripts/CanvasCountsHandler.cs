using UnityEngine;
using TMPro;

public class CanvasCountsHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesDestroyedText;
    private InstantiateHandler _instantiateHandler;

    private void Start()
    {
        _instantiateHandler = FindObjectOfType<InstantiateHandler>();
    }
    private void Update()
    {
        _enemiesDestroyedText.text = _instantiateHandler.EnemiesCount.ToString();
    }
}