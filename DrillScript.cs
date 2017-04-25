using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
[Serializable]
public class DrillScript : MonoBehaviour
{
	// Token: 0x0600032B RID: 811 RVA: 0x00042B08 File Offset: 0x00040D08
	public virtual void LateUpdate()
	{
		this.transform.Rotate(Vector3.up * Time.deltaTime * (float)3600);
	}

	// Token: 0x0600032C RID: 812 RVA: 0x00042B3C File Offset: 0x00040D3C
	public virtual void Main()
	{
	}
}
