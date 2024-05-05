using UnityEngine;
using UnityEngine.EventSystems;

public class BoosterPackButton : MonoBehaviour, IPointerUpHandler
{
    private BoosterPackGenerator packGenerator;
    private void Start()
    {
        packGenerator = GetComponent<BoosterPackGenerator>();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        packGenerator.GenerateBoosterPack();
    }
}
