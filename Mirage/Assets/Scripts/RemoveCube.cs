using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCube : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject objetoAMover;
    private Color colorinicial;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material.color;
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.yellow;
    }

    public void OnExit()
    {
        elRenderer.material.color = colorinicial;
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.blue;
        objetoAMover = GameObject.FindGameObjectWithTag("AsignacionEnBase");
        if (objetoAMover)
        {
            objetoAMover.transform.position= new Vector3(objetoAMover.transform.position.x, objetoAMover.transform.position.y + 8.5f, objetoAMover.transform.position.z+5f);
            objetoAMover.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z+5f);
            objetoAMover.transform.GetChild(0).transform.rotation = new Quaternion(0, -180, 0, 0);
            objetoAMover.tag = "Asignacion";
            var scriptCube = objetoAMover.GetComponentInChildren<AsignSelect>();
            scriptCube.clickeado = false;
            scriptCube.materialOriginal();
            var scriptBase = gameObject.transform.parent.GetComponentInChildren<Base>();
            scriptBase.deleteCube(scriptCube.getPosInBase());
            scriptCube.setPosInBase(0, false);
        }
        objetoAMover = GameObject.FindGameObjectWithTag("CondicionEnBase");
        if (objetoAMover)
        {
            objetoAMover.transform.position = new Vector3(objetoAMover.transform.position.x, objetoAMover.transform.position.y + 8.5f, objetoAMover.transform.position.z + 5f);
            objetoAMover.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z + 5f);
            objetoAMover.transform.GetChild(0).transform.rotation = new Quaternion(0, -180, 0, 0);
            objetoAMover.tag = "Condicion";
            var scriptCube = objetoAMover.GetComponentInChildren<CondSelect>();
            scriptCube.clickeado = false;
            scriptCube.materialOriginal();
            var scriptBase = gameObject.transform.parent.GetComponentInChildren<Base>();
            scriptBase.deleteCond();
            scriptCube.setInBase(false);
        }

    }
}
