using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[Serializable]
public class BlasterScript : MonoBehaviour
{
	// Token: 0x060001F4 RID: 500 RVA: 0x00025C4C File Offset: 0x00023E4C
	public virtual void Start()
	{
		this.Skull.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Beam.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00025C88 File Offset: 0x00023E88
	public virtual void Update()
	{
		if (this.animation["Blast"].time > (float)1)
		{
			this.Beam.localScale = Vector3.Lerp(this.Beam.localScale, new Vector3((float)15, (float)1, (float)1), Time.deltaTime * (float)10);
			this.Eyes.material.color = new Color((float)1, (float)0, (float)0, (float)1);
		}
		if (this.animation["Blast"].time >= this.animation["Blast"].length)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00025D38 File Offset: 0x00023F38
	public virtual void LateUpdate()
	{
		if (this.animation["Blast"].time < 1.5f)
		{
			this.Size = Mathf.Lerp(this.Size, (float)2, Time.deltaTime * (float)5);
		}
		else
		{
			this.Size = Mathf.Lerp(this.Size, (float)0, Time.deltaTime * (float)10);
		}
		this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00025DC4 File Offset: 0x00023FC4
	public virtual void Main()
	{
	}

	// Token: 0x04000435 RID: 1077
	public Transform Skull;

	// Token: 0x04000436 RID: 1078
	public Renderer Eyes;

	// Token: 0x04000437 RID: 1079
	public Transform Beam;

	// Token: 0x04000438 RID: 1080
	public float Size;
}
