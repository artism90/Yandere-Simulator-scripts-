using System;
using UnityEngine;

// Token: 0x02000092 RID: 146
[Serializable]
public class FallCheckerScript : MonoBehaviour
{
	// Token: 0x06000361 RID: 865 RVA: 0x00046A64 File Offset: 0x00044C64
	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.Ragdoll == null && other.gameObject.layer == 11)
		{
			this.Ragdoll = (RagdollScript)other.transform.root.gameObject.GetComponent(typeof(RagdollScript));
			this.Ragdoll.Prompt.Hide();
			this.Ragdoll.Prompt.enabled = false;
			this.Ragdoll.Prompt.MyCollider.enabled = false;
			this.Ragdoll.BloodPoolSpawner.enabled = false;
			this.Ragdoll.HideCollider = this.MyCollider;
			this.Ragdoll.Police.HiddenCorpses = this.Ragdoll.Police.HiddenCorpses + 1;
			this.Ragdoll.Hidden = true;
			this.Dumpster.Corpse = this.Ragdoll.gameObject;
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x00046B5C File Offset: 0x00044D5C
	public virtual void Update()
	{
		if (this.Ragdoll != null)
		{
			if (this.Ragdoll.Prompt.transform.localPosition.y > -10.5f)
			{
				this.Ragdoll.Prompt.transform.localEulerAngles = new Vector3((float)-90, (float)90, (float)0);
				this.Ragdoll.AllColliders[2].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)0);
				this.Ragdoll.AllColliders[7].transform.localEulerAngles = new Vector3((float)0, (float)0, (float)-80);
				float z = this.Dumpster.transform.position.z;
				Vector3 position = this.Ragdoll.Prompt.transform.position;
				float num = position.z = z;
				Vector3 vector = this.Ragdoll.Prompt.transform.position = position;
				float x = this.Dumpster.transform.position.x;
				Vector3 position2 = this.Ragdoll.Prompt.transform.position;
				float num2 = position2.x = x;
				Vector3 vector2 = this.Ragdoll.Prompt.transform.position = position2;
			}
			else
			{
				this.audio.Play();
				this.Ragdoll = null;
			}
		}
	}

	// Token: 0x06000363 RID: 867 RVA: 0x00046CDC File Offset: 0x00044EDC
	public virtual void Main()
	{
	}

	// Token: 0x04000882 RID: 2178
	public DumpsterLidScript Dumpster;

	// Token: 0x04000883 RID: 2179
	public RagdollScript Ragdoll;

	// Token: 0x04000884 RID: 2180
	public Collider MyCollider;
}
