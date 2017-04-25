using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
[Serializable]
public class GradingPaperScript : MonoBehaviour
{
	// Token: 0x060003A1 RID: 929 RVA: 0x000496A8 File Offset: 0x000478A8
	public GradingPaperScript()
	{
		this.Phase = 1;
		this.Speed = 1f;
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x000496C4 File Offset: 0x000478C4
	public virtual void Start()
	{
		this.OriginalPosition = this.Chair.position;
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x000496D8 File Offset: 0x000478D8
	public virtual void Update()
	{
		if (!this.Writing)
		{
			this.Chair.position = Vector3.Lerp(this.Chair.position, this.OriginalPosition, Time.deltaTime * (float)10);
		}
		else
		{
			this.Chair.position = Vector3.Lerp(this.Chair.position, this.Character.transform.position + this.Character.transform.forward * 0.1f, Time.deltaTime * (float)10);
			if (this.Phase == 1)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.PickUpTime1)
				{
					this.Character.animation["f02_deskWrite"].speed = this.Speed;
					this.Paper.parent = this.LeftHand;
					this.Paper.localPosition = this.PickUpPosition1;
					this.Paper.localEulerAngles = this.PickUpRotation1;
					this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.SetDownTime1)
				{
					this.Paper.parent = this.Character.transform;
					this.Paper.localPosition = this.SetDownPosition1;
					this.Paper.localEulerAngles = this.SetDownRotation1;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.PickUpTime2)
				{
					this.Paper.parent = this.LeftHand;
					this.Paper.localPosition = this.PickUpPosition2;
					this.Paper.localEulerAngles = this.PickUpRotation2;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.Character.animation["f02_deskWrite"].time > this.SetDownTime2)
				{
					this.Paper.parent = this.Character.transform;
					this.Paper.localScale = new Vector3((float)0, (float)0, (float)0);
					this.Phase++;
				}
			}
			else if (this.Phase == 5 && this.Character.animation["f02_deskWrite"].time >= this.Character.animation["f02_deskWrite"].length)
			{
				this.Character.animation["f02_deskWrite"].time = (float)0;
				this.Character.animation.Play("f02_deskWrite");
				this.Phase = 1;
			}
			if (this.Teacher.Actions[this.Teacher.Phase] != 12 || !this.Teacher.Routine || this.Teacher.Stop)
			{
				this.Paper.localScale = new Vector3((float)0, (float)0, (float)0);
				this.Teacher.Obstacle.enabled = false;
				this.Teacher.Pen.active = false;
				this.Writing = false;
				this.Phase = 1;
			}
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00049A90 File Offset: 0x00047C90
	public virtual void Main()
	{
	}

	// Token: 0x040008FC RID: 2300
	public StudentScript Teacher;

	// Token: 0x040008FD RID: 2301
	public GameObject Character;

	// Token: 0x040008FE RID: 2302
	public Transform LeftHand;

	// Token: 0x040008FF RID: 2303
	public Transform Chair;

	// Token: 0x04000900 RID: 2304
	public Transform Paper;

	// Token: 0x04000901 RID: 2305
	public float PickUpTime1;

	// Token: 0x04000902 RID: 2306
	public float SetDownTime1;

	// Token: 0x04000903 RID: 2307
	public float PickUpTime2;

	// Token: 0x04000904 RID: 2308
	public float SetDownTime2;

	// Token: 0x04000905 RID: 2309
	public Vector3 OriginalPosition;

	// Token: 0x04000906 RID: 2310
	public Vector3 PickUpPosition1;

	// Token: 0x04000907 RID: 2311
	public Vector3 SetDownPosition1;

	// Token: 0x04000908 RID: 2312
	public Vector3 PickUpPosition2;

	// Token: 0x04000909 RID: 2313
	public Vector3 PickUpRotation1;

	// Token: 0x0400090A RID: 2314
	public Vector3 SetDownRotation1;

	// Token: 0x0400090B RID: 2315
	public Vector3 PickUpRotation2;

	// Token: 0x0400090C RID: 2316
	public int Phase;

	// Token: 0x0400090D RID: 2317
	public float Speed;

	// Token: 0x0400090E RID: 2318
	public bool Writing;
}
