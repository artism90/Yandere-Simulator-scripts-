using System;
using UnityEngine;

// Token: 0x020000A3 RID: 163
[Serializable]
public class GraphUpdaterScript : MonoBehaviour
{
	// Token: 0x060003A6 RID: 934 RVA: 0x00049A9C File Offset: 0x00047C9C
	public virtual void Update()
	{
		if (this.Frames > 0)
		{
			this.Graph.Scan();
			UnityEngine.Object.Destroy(this);
		}
		this.Frames++;
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00049ACC File Offset: 0x00047CCC
	public virtual void Main()
	{
	}

	// Token: 0x0400090F RID: 2319
	public AstarPath Graph;

	// Token: 0x04000910 RID: 2320
	public int Frames;
}
