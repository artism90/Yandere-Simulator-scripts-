using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[Serializable]
public class DoorOpenerScript : MonoBehaviour
{
	// Token: 0x0600031E RID: 798 RVA: 0x00041358 File Offset: 0x0003F558
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null && !this.Student.Dying && !this.Door.Open && !this.Door.Locked)
			{
				this.Door.Student = this.Student;
				this.Door.OpenDoor();
			}
		}
	}

	// Token: 0x0600031F RID: 799 RVA: 0x000413F4 File Offset: 0x0003F5F4
	public virtual void Main()
	{
	}

	// Token: 0x040007DE RID: 2014
	public StudentScript Student;

	// Token: 0x040007DF RID: 2015
	public DoorScript Door;
}
