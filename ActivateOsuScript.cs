using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x020000F5 RID: 245
[Serializable]
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x060004FB RID: 1275 RVA: 0x0005FD84 File Offset: 0x0005DF84
	public virtual void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x0005FDD0 File Offset: 0x0005DFD0
	public virtual void Update()
	{
		if (this.Student == null)
		{
			this.Student = this.StudentManager.Students[this.PlayerID];
		}
		else if (!this.Osu.active)
		{
			if (Vector3.Distance(this.transform.position, this.Student.transform.position) < 0.1f && this.Student.Routine && this.Student.Actions[this.Student.Phase] == 2)
			{
				this.ActivateOsu();
			}
		}
		else
		{
			this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
			if (!this.Student.Routine)
			{
				this.DeactivateOsu();
			}
			else if (this.Student.Actions[this.Student.Phase] != 2)
			{
				this.DeactivateOsu();
			}
		}
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x0005FED4 File Offset: 0x0005E0D4
	public virtual void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.active = true;
		this.Music.active = true;
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = new Vector3((float)0, (float)0, (float)0);
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x0005FF3C File Offset: 0x0005E13C
	public virtual void DeactivateOsu()
	{
		this.Osu.transform.parent.gameObject.active = false;
		this.Music.active = false;
		for (int i = 0; i < Extensions.get_length(this.OsuScripts); i++)
		{
			this.OsuScripts[i].Timer = (float)0;
		}
		this.Mouse.parent = this.transform.parent;
		this.Mouse.transform.position = this.OriginalMousePosition;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x0005FFC8 File Offset: 0x0005E1C8
	public virtual void Main()
	{
	}

	// Token: 0x04000CAA RID: 3242
	public StudentManagerScript StudentManager;

	// Token: 0x04000CAB RID: 3243
	public OsuScript[] OsuScripts;

	// Token: 0x04000CAC RID: 3244
	public StudentScript Student;

	// Token: 0x04000CAD RID: 3245
	public ClockScript Clock;

	// Token: 0x04000CAE RID: 3246
	public GameObject Music;

	// Token: 0x04000CAF RID: 3247
	public Transform Mouse;

	// Token: 0x04000CB0 RID: 3248
	public GameObject Osu;

	// Token: 0x04000CB1 RID: 3249
	public int PlayerID;

	// Token: 0x04000CB2 RID: 3250
	public Vector3 OriginalMousePosition;

	// Token: 0x04000CB3 RID: 3251
	public Vector3 OriginalMouseRotation;
}
