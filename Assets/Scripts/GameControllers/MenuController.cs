using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool IsGreenBirdUnlocked, IsRedBirdUnlocked;

    void Awake() {
        MakeInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        birds[GameController.instance.GetSelectedBird ()].SetActive (true);
        CheckIfBirdsAreUnlucked ();
    }

    void MakeInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    void CheckIfBirdsAreUnlucked() {
        if (GameController.instance.IsRedBirdUnlocked () == 1) {
            IsRedBirdUnlocked = true;
        }

        if (GameController.instance.IsGreenBirdUnlocked () == 1) {
            IsGreenBirdUnlocked = true;
        }
    }

    public void PlayGame() {
        SceneFader.instance.FadeIn ("Gameplay");
    }

    public void ChangeBird() {
        if (GameController.instance.GetSelectedBird () == 0) {

            if ( IsGreenBirdUnlocked) {
                birds[0].SetActive(false);
                GameController.instance.SetSelectedBird(1);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        } else if (GameController.instance.GetSelectedBird () == 1) {
            if(IsRedBirdUnlocked) {

                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(2);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);

            } else {

                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(0);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);

            }
        } else if (GameController.instance.GetSelectedBird () == 2) {
            birds[2].SetActive(false);
                GameController.instance.SetSelectedBird(0);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
        }
    }

}
