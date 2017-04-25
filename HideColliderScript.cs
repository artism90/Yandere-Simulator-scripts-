using System;
using UnityEngine;

// Token: 0x020000AA RID: 170
[Serializable]
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x060003C1 RID: 961 RVA: 0x0004B5BC File Offset: 0x000497BC
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11 && ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Dead)
		{
			this.Corpse = (RagdollScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(RagdollScript));
			if (!this.Corpse.Hidden)
			{
				this.Corpse.HideCollider = this.MyCollider;
				this.Corpse.Police.HiddenCorpses = this.Corpse.Police.HiddenCorpses + 1;
				this.Corpse.Hidden = true;
			}
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x0004B690 File Offset: 0x00049890
	public virtual void Main()
	{
	}

	// Token: 0x0400094E RID: 2382
	public RagdollScript Corpse;

	// Token: 0x0400094F RID: 2383
	public Collider MyCollider;
}
