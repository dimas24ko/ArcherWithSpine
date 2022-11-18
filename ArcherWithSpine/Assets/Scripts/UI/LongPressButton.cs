using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   [SerializeField] private Button MoveButton;

    private bool isPressing;
        
    private void FixedUpdate()
    {
        if(isPressing)
            MoveButton.onClick.Invoke();
    }
        
    public void OnPointerDown(PointerEventData eventData) => 
        isPressing = true;

    public void OnPointerUp(PointerEventData eventData) => 
        isPressing = false;
}