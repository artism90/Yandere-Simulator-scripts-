using System;
using UnityEngine;

// Token: 0x02000061 RID: 97
[Serializable]
public class CirnoIceAttackScript : MonoBehaviour
{
	// Token: 0x06000261 RID: 609 RVA: 0x0002B150 File Offset: 0x00029350
	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(18, 13, true);
		Physics.IgnoreLayerCollision(18, 18, true);
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0002B168 File Offset: 0x00029368
	public virtual void OnCollisionEnter(Collision collision)
	{
		UnityEngine.Object.Instantiate(this.IceExplosion, this.transform.position, Quaternion.identity);
		if (collision.gameObject.layer == 9)
		{
			StudentScript studentScript = (StudentScript)collision.gameObject.GetComponent(typeof(StudentScript));
			if (studentScript != null)
			{
				studentScript.SpawnAlarmDisc();
				studentScript.BecomeRagdoll();
			}
		}
		UnityEngine.Object.Destroy(this.gameObject);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x0002B1E4 File Offset: 0x000293E4
	public virtual void Main()
	{
	}

	// Token: 0x04000519 RID: 1305
	public GameObject IceExplosion;
}
