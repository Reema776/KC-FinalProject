using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Level2 : MonoBehaviour
{

    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00" + secondsLeft;

    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "target")
        {
            SceneManager.LoadScene(4);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 0)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;

        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;

        }
        takingAway = false;
    }
}
