using UnityEngine;
using UnityEngine.AI;
using AceDevelopment.Shared.AceUtil;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public abstract class MobileEntity : MonoBehaviour {

	public float RunSpeedThreshold = 6;

	public float Speed = 4;
	public float TurnSpeed = 1;
	//public Camera mCam;

	public NavMeshAgent agent;
	protected Animator mAnim;
	Vector3 destination;
	protected float mTimePassed = 0;
	protected int mMove = Animator.StringToHash("move");
	protected int mSpeed = Animator.StringToHash("speed");

    void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		mAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		if(agent==null || mAnim==null){
			print("Error: NavMeshAgent or Animator is missing");
			Destroy(this);
		}
		//clock - left foot or right foot
		mAnim.SetFloat("time", mAnim.GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(mAnim.GetCurrentAnimatorStateInfo(0).normalizedTime));
		
		mAnim.SetBool(mMove, (agent.remainingDistance < Util.Epsilon)?false:true);

		mTimePassed += Time.deltaTime;
	}
	

    internal void RouteTo(Vector3 point)
    {
        mAnim.SetBool(mMove, true);
		destination = point;
    }
}
