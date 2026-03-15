
using UnityEngine;

public class Grapple : MonoBehaviour
{
    Rigidbody2D rb;
    private LineRenderer lineRend;
    private DistanceJoint2D distJoint;
    private Node selectedNode;

    private void Start()
    {
            rb = GetComponent<Rigidbody2D>();
        lineRend = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();

        lineRend.enabled = false;
        distJoint.enabled = false;
        selectedNode = null;
    }

    private void Update()
    {
        NodeBehavior();
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;    
    }

    public void DeselectNode()
    {
        selectedNode = null;
    }

    private void NodeBehavior()
    {
        if (selectedNode == null)
        {
            lineRend.enabled = false;
            distJoint.enabled = false;

            return;
        }

        lineRend.enabled = true;
        distJoint.enabled = true;

        distJoint.connectedBody = selectedNode.GetComponent<Rigidbody2D>();

        if (selectedNode != null)
        {

            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, selectedNode.transform.position);
        }
    }
}
