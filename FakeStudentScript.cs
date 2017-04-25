using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
[Serializable]
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x06000356 RID: 854 RVA: 0x00046418 File Offset: 0x00044618
	public virtual void Start()
	{
		this.targetRotation = this.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00046448 File Offset: 0x00044648
	public virtual void Update()
	{
		if (!this.Student.Talking && this.Rotate)
		{
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, (float)10 * Time.deltaTime);
			this.RotationTimer += Time.deltaTime;
			if (this.RotationTimer > (float)1)
			{
				this.RotationTimer = (float)0;
				this.Rotate = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.TargetStudent = this.Student;
			this.Subtitle.UpdateLabel("Club Greeting", this.Student.Club, (float)4);
			this.DialogueWheel.ClubLeader = true;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			this.DialogueWheel.Show = true;
			this.DialogueWheel.Panel.enabled = true;
			this.Student.Talking = true;
			this.Student.TalkTimer = (float)0;
			this.Yandere.ShoulderCamera.OverShoulder = true;
			this.Yandere.WeaponMenu.KeyboardShow = false;
			this.Yandere.Obscurance.enabled = false;
			this.Yandere.WeaponMenu.Show = false;
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
			this.Rotate = true;
		}
	}

	// Token: 0x06000358 RID: 856 RVA: 0x000465D8 File Offset: 0x000447D8
	public virtual void Main()
	{
	}

	// Token: 0x04000865 RID: 2149
	public StudentManagerScript StudentManager;

	// Token: 0x04000866 RID: 2150
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04000867 RID: 2151
	public SubtitleScript Subtitle;

	// Token: 0x04000868 RID: 2152
	public YandereScript Yandere;

	// Token: 0x04000869 RID: 2153
	public StudentScript Student;

	// Token: 0x0400086A RID: 2154
	public PromptScript Prompt;

	// Token: 0x0400086B RID: 2155
	public Quaternion targetRotation;

	// Token: 0x0400086C RID: 2156
	public float RotationTimer;

	// Token: 0x0400086D RID: 2157
	public bool Rotate;

	// Token: 0x0400086E RID: 2158
	public int Club;
}
