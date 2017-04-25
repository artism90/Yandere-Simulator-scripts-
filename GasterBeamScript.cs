using System;
using UnityEngine;

// Token: 0x0200009C RID: 156
[Serializable]
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x0600038B RID: 907 RVA: 0x00048E20 File Offset: 0x00047020
	public GasterBeamScript()
	{
		this.Strength = 1000f;
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00048E34 File Offset: 0x00047034
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null)
			{
				studentScript.Dead = true;
				studentScript.BecomeRagdoll();
				studentScript.Ragdoll.AllRigidbodies[0].isKinematic = false;
				studentScript.Ragdoll.AllRigidbodies[0].AddForce((studentScript.Ragdoll.AllRigidbodies[0].transform.root.position - this.transform.root.position) * this.Strength);
				studentScript.Ragdoll.AllRigidbodies[0].AddForce(Vector3.up * (float)1000);
			}
		}
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00048F0C File Offset: 0x0004710C
	public virtual void Main()
	{
	}

	// Token: 0x040008E4 RID: 2276
	public float Strength;
}
