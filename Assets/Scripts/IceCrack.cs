using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceCrack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isCracked = false;

    public GameObject penguinNpc;

    public ParticleSystem crackParticles;

    public GameObject helpBubble;

    [Header("Ice Crack Sprites")]
    public Sprite crackedSprite;
    public Sprite notCrackedSprite;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        penguinNpc.SetActive(false);
        spriteRenderer.sprite = isCracked ? crackedSprite : notCrackedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     AddPenguin();
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            if (!isCracked && other.transform.parent.GetComponent<Movement>().GetGroundedStatus() == false && other.transform.parent.GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<Animal>().getName() == "Bear")
            {
                Debug.Log("jumped on this as bear");
                helpBubble.SetActive(false);
                isCracked = true;
                penguinNpc.SetActive(true);
                penguinNpc.GetComponent<Animator>().SetTrigger("cracked");

                crackParticles.Play();
                spriteRenderer.sprite = crackedSprite;
            }

            if (isCracked && other.transform.parent.GetComponent<SwitchAnimals>().GetCurrentAnimal().GetComponent<Animal>().getName() == "Penguin")
            {
                Debug.Log("underwater scene");
                SceneManager.LoadScene("Penguin_Underwater");
            }
        }
    }

    public void AddPenguin()
    {
        SwitchAnimals.instance.AddAnimal(AnimalPrefabHolder.instance.penguin);
    }
}
