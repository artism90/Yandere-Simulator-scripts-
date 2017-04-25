using System;
using UnityEngine;

// Token: 0x0200008E RID: 142
[Serializable]
public class ExpressionMaskScript : MonoBehaviour
{
	// Token: 0x06000353 RID: 851 RVA: 0x00046324 File Offset: 0x00044524
	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (this.ID < 3)
			{
				this.ID++;
			}
			else
			{
				this.ID = 0;
			}
			int id = this.ID;
			if (id == 0)
			{
				this.Mask.material.mainTextureOffset = new Vector2((float)0, (float)0);
			}
			else if (id == 1)
			{
				this.Mask.material.mainTextureOffset = new Vector2((float)0, 0.5f);
			}
			else if (id == 2)
			{
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, (float)0);
			}
			else if (id == 3)
			{
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
			}
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x0004640C File Offset: 0x0004460C
	public virtual void Main()
	{
	}

	// Token: 0x04000863 RID: 2147
	public Renderer Mask;

	// Token: 0x04000864 RID: 2148
	public int ID;
}
