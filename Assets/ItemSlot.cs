using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class ItemSlot : MonoBehaviour, IDropHandler
{
 private Dictionary<Sprite, Vector3> ObjectPositionsBowlingBallsLane = new Dictionary<Sprite, Vector3>();

    public Transform[] PositionsBowlingBallsLane;
    
   void Start() 
   {
       if (PositionsBowlingBallsLane != null)
        {
            foreach (var positionBowlingBall in PositionsBowlingBallsLane)
            {
                ObjectPositionsBowlingBallsLane.Add(positionBowlingBall.GetComponent<Image>().sprite,
                    positionBowlingBall.position);
            }
        }
   }

   public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && ObjectPositionsBowlingBallsLane.Count > 0)
        { 
            this.GetComponent<Image>().sprite = null;
            this.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;

            eventData.pointerDrag.transform.position = ObjectPositionsBowlingBallsLane[this.GetComponent<Image>().sprite];
   }
    }
}
