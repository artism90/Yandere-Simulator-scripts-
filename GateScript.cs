using System;
using UnityEngine;

// Token: 0x0200009D RID: 157
[Serializable]
public class GateScript : MonoBehaviour
{
	// Token: 0x0600038F RID: 911 RVA: 0x00048F18 File Offset: 0x00047118
	public virtual void Update()
	{
		if (this.Clock.PresentTime / (float)60 > 8.5f && this.Clock.PresentTime / (float)60 < 15.5f)
		{
			this.Closed = true;
			if (this.EmergencyDoor.enabled)
			{
				this.EmergencyDoor.enabled = false;
			}
		}
		else
		{
			this.Closed = false;
			if (!this.EmergencyDoor.enabled)
			{
				this.EmergencyDoor.enabled = true;
			}
		}
		if (!this.Closed)
		{
			float x = Mathf.Lerp(this.RightGate.localPosition.x, (float)7, Time.deltaTime);
			Vector3 localPosition = this.RightGate.localPosition;
			float num = localPosition.x = x;
			Vector3 vector = this.RightGate.localPosition = localPosition;
			float x2 = Mathf.Lerp(this.LeftGate.localPosition.x, (float)-7, Time.deltaTime);
			Vector3 localPosition2 = this.LeftGate.localPosition;
			float num2 = localPosition2.x = x2;
			Vector3 vector2 = this.LeftGate.localPosition = localPosition2;
		}
		else
		{
			float x3 = Mathf.Lerp(this.RightGate.localPosition.x, 2.325f, Time.deltaTime);
			Vector3 localPosition3 = this.RightGate.localPosition;
			float num3 = localPosition3.x = x3;
			Vector3 vector3 = this.RightGate.localPosition = localPosition3;
			float x4 = Mathf.Lerp(this.LeftGate.localPosition.x, -2.325f, Time.deltaTime);
			Vector3 localPosition4 = this.LeftGate.localPosition;
			float num4 = localPosition4.x = x4;
			Vector3 vector4 = this.LeftGate.localPosition = localPosition4;
		}
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00049108 File Offset: 0x00047308
	public virtual void Main()
	{
	}

	// Token: 0x040008E5 RID: 2277
	public Collider EmergencyDoor;

	// Token: 0x040008E6 RID: 2278
	public ClockScript Clock;

	// Token: 0x040008E7 RID: 2279
	public Collider GateCollider;

	// Token: 0x040008E8 RID: 2280
	public Transform RightGate;

	// Token: 0x040008E9 RID: 2281
	public Transform LeftGate;

	// Token: 0x040008EA RID: 2282
	public bool UpdateGates;

	// Token: 0x040008EB RID: 2283
	public bool Closed;
}
