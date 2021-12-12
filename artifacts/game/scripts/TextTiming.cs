using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTiming : MonoBehaviour
{

    float measure = 2.7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        // changes text on beat of intro sequence music 
        GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(measure * 2);
        GetComponent<UnityEngine.UI.Text>().text = "MATTHEW KING";
        yield return new WaitForSeconds(measure);
        GetComponent<UnityEngine.UI.Text>().text = "CHASE KERR";
        yield return new WaitForSeconds(measure);
        GetComponent<UnityEngine.UI.Text>().text = "BRAYDEN LANE";
        yield return new WaitForSeconds(measure);
        GetComponent<UnityEngine.UI.Text>().text = "";
        yield return null;
    }
}
