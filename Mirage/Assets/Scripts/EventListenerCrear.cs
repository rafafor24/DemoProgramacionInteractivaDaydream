using UnityEngine;
using UnityEngine.UI;

public class EventListenerCrear : MonoBehaviour
{
    private Renderer elRenderer;
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.red;
    }

    public void OnExit()
    {
        elRenderer.material.color = new Color(0.26f, 0.81f, 0.7f);
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.green;
        Instantiate(myPrefab, new Vector3(-7f, 4.5f, 0), Quaternion.identity);
    }
}
