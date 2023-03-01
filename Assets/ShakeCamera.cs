using FirstGearGames.SmoothCameraShaker;
using UnityEngine;


public class ShakeCamera : MonoBehaviour
{
    public ShakeData MyShake;
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            CameraShakerHandler.Shake(MyShake);
            Debug.Log("StartDialogue");
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }
}
