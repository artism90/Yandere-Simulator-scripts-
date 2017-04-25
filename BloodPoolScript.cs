using System;
using UnityEngine;

// Token: 0x0200004A RID: 74
[Serializable]
public class BloodPoolScript : MonoBehaviour
{
	// Token: 0x060001FF RID: 511 RVA: 0x00026108 File Offset: 0x00024308
	public BloodPoolScript()
	{
		this.Blood = true;
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00026118 File Offset: 0x00024318
	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("PantiesEquipped") == 7)
		{
			this.TargetSize *= 0.5f;
		}
		this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		if (this.transform.position.x > (float)125 || this.transform.position.x < (float)-125 || this.transform.position.z > (float)200 || this.transform.position.z < (float)-100)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x000261E0 File Offset: 0x000243E0
	public virtual void Update()
	{
		if (this.Grow)
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(this.TargetSize, this.TargetSize, this.TargetSize), Time.deltaTime * (float)1);
			if (this.transform.localScale.x > this.TargetSize * 0.99f)
			{
				this.Grow = false;
			}
		}
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00026260 File Offset: 0x00024460
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
			this.Grow = true;
		}
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00026284 File Offset: 0x00024484
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x000262A0 File Offset: 0x000244A0
	public virtual void Main()
	{
	}

	// Token: 0x04000443 RID: 1091
	public float TargetSize;

	// Token: 0x04000444 RID: 1092
	public bool Blood;

	// Token: 0x04000445 RID: 1093
	public bool Grow;
}
