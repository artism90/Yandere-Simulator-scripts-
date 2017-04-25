using System;
using UnityEngine;

// Token: 0x020000B5 RID: 181
[Serializable]
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x060003F0 RID: 1008 RVA: 0x0004F5A0 File Offset: 0x0004D7A0
	public virtual void Update()
	{
		if (this.PantyChanger.Selected == this.ID)
		{
			float y = this.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed;
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = this.transform.eulerAngles = eulerAngles;
		}
		else
		{
			int num2 = 0;
			Vector3 eulerAngles2 = this.transform.eulerAngles;
			float num3 = eulerAngles2.y = (float)num2;
			Vector3 vector2 = this.transform.eulerAngles = eulerAngles2;
		}
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x0004F650 File Offset: 0x0004D850
	public virtual void Main()
	{
	}

	// Token: 0x040009E0 RID: 2528
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040009E1 RID: 2529
	public float RotationSpeed;

	// Token: 0x040009E2 RID: 2530
	public int ID;
}
