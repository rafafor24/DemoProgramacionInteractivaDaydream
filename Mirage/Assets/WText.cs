using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TextMesh mesht = gameObject.GetComponent<TextMesh>();
        Text textreal = GameObject.Find("VarShowW").GetComponent<Text>();
        mesht.text = textreal.text;
    }
}
