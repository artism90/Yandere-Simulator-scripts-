using System;
using UnityEngine;

// Token: 0x0200007F RID: 127
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x0600030C RID: 780 RVA: 0x0003E7EC File Offset: 0x0003C9EC
	public virtual void Start()
	{
		this.transform.LookAt(new Vector3(this.Target.position.x, this.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3((float)1, (float)0, (float)1);
		this.transform.localScale = new Vector3((float)1, (float)1, (float)1);
		int num = 0;
		Color color = this.Tex.color;
		float num2 = color.a = (float)num;
		Color color2 = this.Tex.color = color;
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0003E8A8 File Offset: 0x0003CAA8
	public virtual void Update()
	{
		if (this.Tex.color.a > (float)0 && this.transform != null && this.Target != null)
		{
			this.transform.LookAt(new Vector3(this.Target.position.x, this.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0003E93C File Offset: 0x0003CB3C
	public virtual void Main()
	{
	}

	// Token: 0x040007AD RID: 1965
	public Transform Target;

	// Token: 0x040007AE RID: 1966
	public UITexture Tex;
}
