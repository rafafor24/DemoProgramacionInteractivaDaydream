using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{
    public int id;
    public string value;
    public string nombre;
    public bool isArr;
    // Start is called before the first frame update
    void Start()
    {

   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getId()
    {
        return id;
    }

    public void setId(int param)
    {
        id = param;
    }

    public string getNombre()
    {
        return nombre;
    }

    public void setNombre(string param)
    {
        nombre = param;
        TextMesh nombreMesh = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        nombreMesh.text =":"+ param;

    }

    public string getValue()
    {
        return value;
    }

    public void setValue(string param)
    {
        value = param;
        TextMesh valorMesh = gameObject.transform.GetChild(1).GetComponent<TextMesh>();
        valorMesh.text = param;
    }

    public bool isArray()
    {
        return isArr;
    }

    public void setIsArray(bool param)
    {
        isArr = param;
    }

}
