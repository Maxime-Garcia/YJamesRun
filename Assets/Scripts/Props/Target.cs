using UnityEngine;
using utils;
public class Target : MonoBehaviour
{
    [SerializeField] private Activable obstacle;
    public Side side;
    private void Start() {
        side = transform.parent.position.x == -10 ? Side.Left : transform.parent.position.x == 0 ? Side.Center : Side.Right;
        GameManager.Instance.NewTarget(this);
    }

    private void OnDestroy() {
        GameManager.Instance.DeleteTarget(this);
    }
    public void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == Mathf.Log(GameManager.PlayerLayer.value, 2)) return;//Player Shouldn't trigger the target
		if (obstacle) obstacle.Activate();
        Destroy(other.gameObject);
    }
}
