using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectVar : MonoBehaviour
{
    public TextMesh text;
    //Z=X+Y
    //Z
    public int[] ids=new int[100];
    private int posActual;
    public string idstring;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        ids = new int[100];
        ids[0] = -1;
        posActual = 0;
        resetIds();
        idstring = "";
    }
    private void Update()
    {
        
    }
    public void OnEnter()
    {
        foreach (int id in ids)
        {
            idstring += id;

        }
        text.color = Color.yellow;
    }

    public void OnExit()
    {
        text.color = Color.white;
    }

    public void OnClick()
    {
        text.color = Color.blue;
    }   

    public void setids(int param)
    {
        ids[posActual] = param;
        posActual++;
    }

    public void resetIds()
    {
        for(var i =0;i<99;i++)
        {
            ids[i] = -1;
        }
        posActual = 0;
    }

    public int getid(int pos)
    {
        return ids[pos];
    } 

    public int[] getAllIds()
    {
        return ids;
    }

}
