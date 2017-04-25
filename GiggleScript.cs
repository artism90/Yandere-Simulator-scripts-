using System;
using UnityEngine;

// Token: 0x020000A0 RID: 160
[Serializable]
public class GiggleScript : MonoBehaviour
{
	// Token: 0x06000399 RID: 921 RVA: 0x00049224 File Offset: 0x00047424
	public virtual void Start()
	{
		float x = (float)500 * ((float)2 - PlayerPrefs.GetFloat("SchoolAtmosphere") * 0.01f);
		Vector3 localScale = this.transform.localScale;
		float num = localScale.x = x;
		Vector3 vector = this.transform.localScale = localScale;
		float x2 = this.transform.localScale.x;
		Vector3 localScale2 = this.transform.localScale;
		float num2 = localScale2.z = x2;
		Vector3 vector2 = this.transform.localScale = localScale2;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x000492C4 File Offset: 0x000474C4
	public virtual void Update()
	{
		if (this.Frame > 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		this.Frame++;
	}

	// Token: 0x0600039B RID: 923 RVA: 0x000492EC File Offset: 0x000474EC
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9 && !this.Distracted)
		{
			this.Student = (StudentScript)other.gameObject.GetComponent(typeof(StudentScript));
			if (this.Student != null && this.Student.Giggle == null && !this.Student.YandereVisible && !this.Student.Alarmed && !this.Student.Distracted && !this.Student.Wet && !this.Student.Slave && !this.Student.WitnessedMurder && !this.Student.WitnessedCorpse && !this.Student.Investigating && !this.Student.InEvent && !this.Student.Following && !this.Student.Confessing && !this.Student.Meeting)
			{
				this.Student.Character.animation.CrossFade(this.Student.IdleAnim);
				this.Giggle = (GameObject)UnityEngine.Object.Instantiate(this.EmptyGameObject, new Vector3(this.transform.position.x, this.Student.transform.position.y, this.transform.position.z), Quaternion.identity);
				this.Student.Giggle = this.Giggle;
				if (this.Student.Pathfinding != null && !this.Student.Nemesis)
				{
					this.Student.Pathfinding.canSearch = false;
					this.Student.Pathfinding.canMove = false;
					this.Student.InvestigationPhase = 0;
					this.Student.InvestigationTimer = (float)0;
					this.Student.Investigating = true;
					this.Student.DiscCheck = true;
					this.Student.Routine = false;
					this.Student.ReadPhase = 0;
				}
				this.Distracted = true;
			}
		}
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00049544 File Offset: 0x00047744
	public virtual void Main()
	{
	}

	// Token: 0x040008F3 RID: 2291
	public GameObject EmptyGameObject;

	// Token: 0x040008F4 RID: 2292
	public GameObject Giggle;

	// Token: 0x040008F5 RID: 2293
	public StudentScript Student;

	// Token: 0x040008F6 RID: 2294
	public bool Distracted;

	// Token: 0x040008F7 RID: 2295
	public int Frame;
}
