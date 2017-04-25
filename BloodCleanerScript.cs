using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[Serializable]
public class BloodCleanerScript : MonoBehaviour
{
	// Token: 0x060001FC RID: 508 RVA: 0x00025E38 File Offset: 0x00024038
	public virtual void Start()
	{
		Physics.IgnoreLayerCollision(11, 15, true);
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00025E44 File Offset: 0x00024044
	public virtual void Update()
	{
		if (this.Blood < (float)100 && this.BloodParent.childCount > 0)
		{
			this.Pathfinding.target = this.BloodParent.GetChild(0);
			if (this.Pathfinding.target.position.y < (float)4)
			{
				this.Label.text = "1";
			}
			else if (this.Pathfinding.target.position.y < (float)8)
			{
				this.Label.text = "2";
			}
			else if (this.Pathfinding.target.position.y < (float)12)
			{
				this.Label.text = "3";
			}
			else
			{
				this.Label.text = "R";
			}
			if (this.Pathfinding.target != null)
			{
				this.Distance = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
				if (this.Distance < 0.45f)
				{
					this.Pathfinding.speed = (float)0;
					if (this.BloodParent.GetChild(0).GetComponent("BloodPoolScript") != null)
					{
						float x = this.BloodParent.GetChild(0).localScale.x - Time.deltaTime;
						Vector3 localScale = this.BloodParent.GetChild(0).localScale;
						float num = localScale.x = x;
						Vector3 vector = this.BloodParent.GetChild(0).localScale = localScale;
						float y = this.BloodParent.GetChild(0).localScale.y - Time.deltaTime;
						Vector3 localScale2 = this.BloodParent.GetChild(0).localScale;
						float num2 = localScale2.y = y;
						Vector3 vector2 = this.BloodParent.GetChild(0).localScale = localScale2;
						this.Blood += Time.deltaTime;
						if (this.Blood >= (float)100)
						{
							this.Lens.active = true;
						}
						if (this.BloodParent.GetChild(0).transform.localScale.x < 0.1f)
						{
							UnityEngine.Object.Destroy(this.BloodParent.GetChild(0).gameObject);
						}
					}
					else
					{
						UnityEngine.Object.Destroy(this.BloodParent.GetChild(0).gameObject);
					}
				}
				else
				{
					this.Pathfinding.speed = (float)1;
				}
			}
		}
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00026104 File Offset: 0x00024304
	public virtual void Main()
	{
	}

	// Token: 0x0400043C RID: 1084
	public Transform BloodParent;

	// Token: 0x0400043D RID: 1085
	public PromptScript Prompt;

	// Token: 0x0400043E RID: 1086
	public AIPath Pathfinding;

	// Token: 0x0400043F RID: 1087
	public GameObject Lens;

	// Token: 0x04000440 RID: 1088
	public UILabel Label;

	// Token: 0x04000441 RID: 1089
	public float Distance;

	// Token: 0x04000442 RID: 1090
	public float Blood;
}
