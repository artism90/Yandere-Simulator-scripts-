using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
[Serializable]
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x06000401 RID: 1025 RVA: 0x000513F0 File Offset: 0x0004F5F0
	public HomeSenpaiShrineScript()
	{
		this.Selected = 1;
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00051400 File Offset: 0x0004F600
	public virtual void Start()
	{
		this.UpdateText();
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x00051408 File Offset: 0x0004F608
	public virtual void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.HomeCamera.ID == 6)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, (float)135, Time.deltaTime * (float)10);
				float rotation = this.Rotation;
				Vector3 localEulerAngles = this.RightDoor.localEulerAngles;
				float num = localEulerAngles.y = rotation;
				Vector3 vector = this.RightDoor.localEulerAngles = localEulerAngles;
				float y = this.Rotation * (float)-1;
				Vector3 localEulerAngles2 = this.LeftDoor.localEulerAngles;
				float num2 = localEulerAngles2.y = y;
				Vector3 vector2 = this.LeftDoor.localEulerAngles = localEulerAngles2;
				if (this.InputManager.TappedRight)
				{
					this.Selected++;
					this.UpdateText();
				}
				if (this.InputManager.TappedLeft)
				{
					this.Selected--;
					this.UpdateText();
				}
				this.HomeCamera.Destination = this.Destinations[this.Selected];
				this.HomeCamera.Target = this.Targets[this.Selected];
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeYandere.active = true;
					this.HomeWindow.Show = false;
				}
			}
		}
		else
		{
			this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * (float)10);
			float rotation2 = this.Rotation;
			Vector3 localEulerAngles3 = this.RightDoor.localEulerAngles;
			float num3 = localEulerAngles3.y = rotation2;
			Vector3 vector3 = this.RightDoor.localEulerAngles = localEulerAngles3;
			float rotation3 = this.Rotation;
			Vector3 localEulerAngles4 = this.LeftDoor.localEulerAngles;
			float num4 = localEulerAngles4.y = rotation3;
			Vector3 vector4 = this.LeftDoor.localEulerAngles = localEulerAngles4;
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0005164C File Offset: 0x0004F84C
	public virtual void UpdateText()
	{
		if (this.Selected > 11)
		{
			this.Selected = 1;
		}
		else if (this.Selected < 1)
		{
			this.Selected = 11;
		}
		this.NameLabel.text = this.Names[this.Selected];
		this.DescLabel.text = this.Descs[this.Selected];
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x000516B8 File Offset: 0x0004F8B8
	public virtual void Main()
	{
	}

	// Token: 0x04000A41 RID: 2625
	public InputManagerScript InputManager;

	// Token: 0x04000A42 RID: 2626
	public PauseScreenScript PauseScreen;

	// Token: 0x04000A43 RID: 2627
	public HomeYandereScript HomeYandere;

	// Token: 0x04000A44 RID: 2628
	public HomeCameraScript HomeCamera;

	// Token: 0x04000A45 RID: 2629
	public HomeWindowScript HomeWindow;

	// Token: 0x04000A46 RID: 2630
	public Transform[] Destinations;

	// Token: 0x04000A47 RID: 2631
	public Transform[] Targets;

	// Token: 0x04000A48 RID: 2632
	public Transform RightDoor;

	// Token: 0x04000A49 RID: 2633
	public Transform LeftDoor;

	// Token: 0x04000A4A RID: 2634
	public UILabel NameLabel;

	// Token: 0x04000A4B RID: 2635
	public UILabel DescLabel;

	// Token: 0x04000A4C RID: 2636
	public string[] Names;

	// Token: 0x04000A4D RID: 2637
	public string[] Descs;

	// Token: 0x04000A4E RID: 2638
	public float Rotation;

	// Token: 0x04000A4F RID: 2639
	public int Selected;

	// Token: 0x04000A50 RID: 2640
	public int ID;
}
