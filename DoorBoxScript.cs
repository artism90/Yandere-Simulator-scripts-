using System;
using UnityEngine;

// Token: 0x02000081 RID: 129
[Serializable]
public class DoorBoxScript : MonoBehaviour
{
	// Token: 0x06000317 RID: 791 RVA: 0x00040FD0 File Offset: 0x0003F1D0
	public virtual void Update()
	{
		if (this.Show)
		{
			float y = Mathf.Lerp(this.transform.localPosition.y, (float)-530, Time.deltaTime * (float)10);
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.transform.localPosition = localPosition;
		}
		else
		{
			float y2 = Mathf.Lerp(this.transform.localPosition.y, (float)-630, Time.deltaTime * (float)10);
			Vector3 localPosition2 = this.transform.localPosition;
			float num2 = localPosition2.y = y2;
			Vector3 vector2 = this.transform.localPosition = localPosition2;
		}
	}

	// Token: 0x06000318 RID: 792 RVA: 0x000410A0 File Offset: 0x0003F2A0
	public virtual void Main()
	{
	}

	// Token: 0x040007D6 RID: 2006
	public UILabel Label;

	// Token: 0x040007D7 RID: 2007
	public bool Show;
}
