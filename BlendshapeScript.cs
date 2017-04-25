using System;
using UnityEngine;

// Token: 0x02000048 RID: 72
[Serializable]
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x060001F9 RID: 505 RVA: 0x00025DD0 File Offset: 0x00023FD0
	public virtual void LateUpdate()
	{
		this.Happiness += Time.deltaTime * (float)10;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * (float)10;
		this.MyMesh.SetBlendShapeWeight(8, (float)100);
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00025E2C File Offset: 0x0002402C
	public virtual void Main()
	{
	}

	// Token: 0x04000439 RID: 1081
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x0400043A RID: 1082
	public float Happiness;

	// Token: 0x0400043B RID: 1083
	public float Blink;
}
