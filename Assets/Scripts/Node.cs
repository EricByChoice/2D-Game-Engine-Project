using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject player;
    private Grapple GrappleScript;
    private Node node;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        node=null;
        GrappleScript = player.GetComponent<Grapple>();  

    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        node = this;
        GrappleScript.SelectNode(node);
    }

    public void OnMouseUp()
    { 
       node = null;
        GrappleScript.DeselectNode();
    }
}
