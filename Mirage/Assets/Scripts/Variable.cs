using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour
{
    public int id;
    public string value;
    public string nombre;
    public bool isArr;
    public TextMesh textNombre;
    private TextMesh texto;
    public TextMesh textValue;

    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.FindGameObjectWithTag("Valor").GetComponent<TextMesh>();

    }

    public void OnEnter()
    {
        textNombre.color = Color.yellow;
        textValue.color = Color.yellow;
    }

    public void OnExit()
    {
        textNombre.color = Color.white;
        textValue.color = Color.white;
    }

    public void OnClick()
    {
        textNombre.color = Color.blue;
        textValue.color = Color.blue;
        texto.text += nombre;
        var scriptTablero = texto.GetComponent<SelectVar>();
        scriptTablero.setids(id);
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
        textNombre.text =param+"=";
    }

    public string getValue()
    {
        return value;
    }

    public void setValue(string param)
    {
        value = param;
        textValue.text = param;
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
