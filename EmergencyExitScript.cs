using System;
using UnityEngine;

// Token: 0x0200008A RID: 138
[Serializable]
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x06000340 RID: 832 RVA: 0x00043BBC File Offset: 0x00041DBC
	public virtual void Update()
	{
		if (!this.Open)
		{
			float y = Mathf.Lerp(this.Pivot.localEulerAngles.y, (float)0, Time.deltaTime * (float)10);
			Vector3 localEulerAngles = this.Pivot.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.Pivot.localEulerAngles = localEulerAngles;
		}
		else
		{
			float y2 = Mathf.Lerp(this.Pivot.localEulerAngles.y, (float)90, Time.deltaTime * (float)10);
			Vector3 localEulerAngles2 = this.Pivot.localEulerAngles;
			float num2 = localEulerAngles2.y = y2;
			Vector3 vector2 = this.Pivot.localEulerAngles = localEulerAngles2;
			this.Timer -= Time.deltaTime;
			if (this.Timer <= (float)0)
			{
				this.Student = null;
				this.Open = false;
			}
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00043CB4 File Offset: 0x00041EB4
	public virtual void OnTriggerStay(Collider other)
	{
		this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
		if (this.Student != null && this.Student.Fleeing)
		{
			this.Open = true;
			this.Timer = (float)1;
		}
	}

	// Token: 0x06000342 RID: 834 RVA: 0x00043D14 File Offset: 0x00041F14
	public virtual void Main()
	{
	}

	// Token: 0x04000825 RID: 2085
	public StudentScript Student;

	// Token: 0x04000826 RID: 2086
	public Transform Pivot;

	// Token: 0x04000827 RID: 2087
	public bool Open;

	// Token: 0x04000828 RID: 2088
	public float Timer;
}
