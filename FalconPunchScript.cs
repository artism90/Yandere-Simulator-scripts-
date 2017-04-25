using System;
using UnityEngine;

// Token: 0x02000091 RID: 145
[Serializable]
public class FalconPunchScript : MonoBehaviour
{
	// Token: 0x0600035C RID: 860 RVA: 0x000468B0 File Offset: 0x00044AB0
	public FalconPunchScript()
	{
		this.Strength = 100f;
		this.TimeLimit = 0.5f;
	}

	// Token: 0x0600035D RID: 861 RVA: 0x000468D0 File Offset: 0x00044AD0
	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.TimeLimit)
		{
			this.MyCollider.enabled = false;
		}
	}

	// Token: 0x0600035E RID: 862 RVA: 0x00046904 File Offset: 0x00044B04
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null && studentScript.StudentID > 1)
			{
				UnityEngine.Object.Instantiate(this.FalconExplosion, this.transform.position, Quaternion.identity);
				studentScript.Dead = true;
				studentScript.BecomeRagdoll();
				studentScript.Ragdoll.AllRigidbodies[0].isKinematic = false;
				if (this.Falcon)
				{
					studentScript.Ragdoll.AllRigidbodies[0].AddForce((studentScript.Ragdoll.AllRigidbodies[0].transform.position - this.transform.position) * this.Strength);
				}
				else
				{
					studentScript.Ragdoll.AllRigidbodies[0].AddForce((studentScript.Ragdoll.AllRigidbodies[0].transform.root.position - this.transform.root.position) * this.Strength);
					studentScript.Ragdoll.AllRigidbodies[0].AddForce(Vector3.up * (float)10000);
				}
			}
		}
	}

	// Token: 0x0600035F RID: 863 RVA: 0x00046A58 File Offset: 0x00044C58
	public virtual void Main()
	{
	}

	// Token: 0x0400087C RID: 2172
	public GameObject FalconExplosion;

	// Token: 0x0400087D RID: 2173
	public Collider MyCollider;

	// Token: 0x0400087E RID: 2174
	public float Strength;

	// Token: 0x0400087F RID: 2175
	public bool Falcon;

	// Token: 0x04000880 RID: 2176
	public float TimeLimit;

	// Token: 0x04000881 RID: 2177
	public float Timer;
}
