using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
[Serializable]
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x060003B1 RID: 945 RVA: 0x00049E80 File Offset: 0x00048080
	public virtual void Update()
	{
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00049E84 File Offset: 0x00048084
	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript)) != null)
		{
			this.Student = (StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student.StudentID != 1 && !this.Student.Dead)
			{
				this.Student.Dead = true;
				if (!this.Student.Male)
				{
					UnityEngine.Object.Instantiate(this.FemaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				}
				else
				{
					UnityEngine.Object.Instantiate(this.MaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				}
				this.Student.BecomeRagdoll();
				this.Student.Ragdoll.Dismember();
				this.audio.Play();
			}
		}
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00049FB4 File Offset: 0x000481B4
	public virtual void Main()
	{
	}

	// Token: 0x04000921 RID: 2337
	public GameObject FemaleBloodyScream;

	// Token: 0x04000922 RID: 2338
	public GameObject MaleBloodyScream;

	// Token: 0x04000923 RID: 2339
	public Vector3 PreviousPosition;

	// Token: 0x04000924 RID: 2340
	public Collider MyCollider;

	// Token: 0x04000925 RID: 2341
	public float Timer;

	// Token: 0x04000926 RID: 2342
	public StudentScript Student;
}
