using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CageScene : MonoBehaviour
{

    [Header("Managed Objects")]
    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject talkingFox_;
    [SerializeField] private GameObject talkingBear_;
    [SerializeField] private GameObject talkingHare_;
    [SerializeField] private GameObject foxSpeechBubble_;
    [SerializeField] private GameObject bearSpeechBubble_;
    [SerializeField] private GameObject hareSpeechBubble_;
    [SerializeField] private GameObject timer_;
    //[SerializeField] private GameObject speech_;

    private bool sceenPlaying = false;
    private float bubbleShowTime = 4f;
    private Queue<string> dialogSequence = new Queue<string>();

    public void StartAnimation()
    {
        timer_.GetComponent<LevelTimer>().StopTimer();
        SwitchAnimals.instance.AddAnimal(AnimalPrefabHolder.instance.fox);
        talkingFox_.GetComponent<SpriteRenderer>().sortingOrder = 5;
        LoadStory();
        sceenPlaying = true;
    }

    void Update()
    {
        if (sceenPlaying)
        {
            talkingBear_.SetActive(true);
            talkingFox_.SetActive(true);
            talkingHare_.SetActive(true);
            player_.SetActive(false);
            if (dialogSequence.Count != 0)
            {
                bubbleShowTime -= Time.deltaTime;
                if (bubbleShowTime > 0)
                {
                    bubbleShowTime -= Time.deltaTime;
                }
                else 
                {
                    ShowBubble();
                    bubbleShowTime = 4f;
                }
            }
            else
            {
                bearSpeechBubble_.SetActive(false);
                foxSpeechBubble_.SetActive(false);
                hareSpeechBubble_.SetActive(false);
                talkingBear_.SetActive(false);
                talkingFox_.SetActive(false);
                talkingHare_.SetActive(false);
                player_.SetActive(true);
                sceenPlaying = false;
            }
        }
    }

    void ShowBubble(){
        string[] dialogInfo = dialogSequence.Dequeue().Split(char.Parse("-"));
        string talkingAnimal = dialogInfo[0];
        string text = dialogInfo[1];
        if (talkingAnimal=="Bear")
        {
            bearSpeechBubble_.SetActive(true);
            foxSpeechBubble_.SetActive(false);
            hareSpeechBubble_.SetActive(false);
            TMP_Text bearText = bearSpeechBubble_.GetComponentInChildren<TMP_Text>();
            bearText.text = text;
        } else if (talkingAnimal=="Hare")
        {
            bearSpeechBubble_.SetActive(false);
            foxSpeechBubble_.SetActive(false);
            hareSpeechBubble_.SetActive(true);
            TMP_Text hareText = hareSpeechBubble_.GetComponentInChildren<TMP_Text>();
            hareText.text = text;
        } else if (talkingAnimal=="Fox")
        {
            bearSpeechBubble_.SetActive(false);
            foxSpeechBubble_.SetActive(true);
            hareSpeechBubble_.SetActive(false);
            TMP_Text foxText = foxSpeechBubble_.GetComponentInChildren<TMP_Text>();
            foxText.text = text;
        }
    }

    private void LoadStory(){
        dialogSequence.Enqueue("Fox-Thank you so much for saving me!");
        dialogSequence.Enqueue("Bear-Of course, I am just happy we made it in time. How did you end in this situation?");
        dialogSequence.Enqueue("Fox-It is because of my fur, humans love it a little bit too much.");
        dialogSequence.Enqueue("Fox-As if I didn't have enough problems with the red foxes, which invade my territory due to the climate warming....");
        dialogSequence.Enqueue("Hare-I feel you.");
        dialogSequence.Enqueue("Fox-Ohh yummy, you brought a snack Mrs. Icebear?");
        dialogSequence.Enqueue("Hare-AHHHH DON'T EAT ME I DO NOT TASTE AS CUTE AS I LOOK LIKE!");
        dialogSequence.Enqueue("Bear-Please refrain from eating my friend here, we are on a mission to save me kids.");
        dialogSequence.Enqueue("Fox-After you set me free, I guess I can't say no.");
        dialogSequence.Enqueue("Fox-Can we go to a water at least so I can catch some fish or at least fill my belly with seaweed.");
        dialogSequence.Enqueue("Bear-For this we have to go further. But if there are traps here, there are certainly people on the move.");
        dialogSequence.Enqueue("Fox-Don't worry, I'm an expert at sneaking past people.");
        dialogSequence.Enqueue("Hare-Uhhuh, yeah sure...");
        dialogSequence.Enqueue("Fox-Just watch, with R I am almost invisible and can sneak past people right in front of my nose.");
        dialogSequence.Enqueue("Fox-Unfortunately, this only works for a few seconds...");
        dialogSequence.Enqueue("Bear-A few seconds are enough if we time it well. Let's go!");
        dialogSequence.Enqueue("Bear-A few seconds are enough if we time it well. Let's go!");
    }

}
