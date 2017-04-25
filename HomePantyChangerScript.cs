using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
[Serializable]
public class HomePantyChangerScript : MonoBehaviour
{
	// Token: 0x060003F3 RID: 1011 RVA: 0x0004F65C File Offset: 0x0004D85C
	public virtual void Start()
	{
		while (this.ID < this.TotalPanties)
		{
			this.NewPanties = (GameObject)UnityEngine.Object.Instantiate(this.PantyModels[this.ID], new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - (float)1), Quaternion.identity);
			this.NewPanties.transform.parent = this.PantyParent;
			((HomePantiesScript)this.NewPanties.GetComponent(typeof(HomePantiesScript))).PantyChanger = this;
			((HomePantiesScript)this.NewPanties.GetComponent(typeof(HomePantiesScript))).ID = this.ID;
			float y = this.PantyParent.transform.localEulerAngles.y + (float)(360 / this.TotalPanties);
			Vector3 localEulerAngles = this.PantyParent.transform.localEulerAngles;
			float num = localEulerAngles.y = y;
			Vector3 vector = this.PantyParent.transform.localEulerAngles = localEulerAngles;
			this.ID++;
		}
		int num2 = 0;
		Vector3 localEulerAngles2 = this.PantyParent.transform.localEulerAngles;
		float num3 = localEulerAngles2.y = (float)num2;
		Vector3 vector2 = this.PantyParent.transform.localEulerAngles = localEulerAngles2;
		float z = 1.8f;
		Vector3 localPosition = this.PantyParent.transform.localPosition;
		float num4 = localPosition.z = z;
		Vector3 vector3 = this.PantyParent.transform.localPosition = localPosition;
		this.UpdatePantyLabels();
		this.PantyParent.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.PantyParent.gameObject.active = false;
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0004F864 File Offset: 0x0004DA64
	public virtual void Update()
	{
		if (this.HomeWindow.Show)
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
			this.PantyParent.gameObject.active = true;
			if (this.InputManager.TappedRight)
			{
				this.DestinationReached = false;
				this.TargetRotation += (float)(360 / this.TotalPanties);
				this.Selected++;
				if (this.Selected > this.TotalPanties - 1)
				{
					this.Selected = 0;
				}
				this.UpdatePantyLabels();
			}
			if (this.InputManager.TappedLeft)
			{
				this.DestinationReached = false;
				this.TargetRotation -= (float)(360 / this.TotalPanties);
				this.Selected--;
				if (this.Selected < 0)
				{
					this.Selected = this.TotalPanties - 1;
				}
				this.UpdatePantyLabels();
			}
			this.Rotation = Mathf.Lerp(this.Rotation, this.TargetRotation, Time.deltaTime * (float)10);
			float rotation = this.Rotation;
			Vector3 localEulerAngles = this.PantyParent.localEulerAngles;
			float num = localEulerAngles.y = rotation;
			Vector3 vector = this.PantyParent.localEulerAngles = localEulerAngles;
			if (Input.GetButtonDown("A"))
			{
				PlayerPrefs.SetInt("PantiesEquipped", this.Selected);
				this.UpdatePantyLabels();
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
				this.HomeCamera.Target = this.HomeCamera.Targets[0];
				this.HomeYandere.CanMove = true;
				this.HomeWindow.Show = false;
			}
		}
		else
		{
			this.PantyParent.localScale = Vector3.Lerp(this.PantyParent.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
			if (this.PantyParent.localScale.x < 0.01f)
			{
				this.PantyParent.gameObject.active = false;
			}
		}
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0004FAB4 File Offset: 0x0004DCB4
	public virtual void UpdatePantyLabels()
	{
		this.PantyNameLabel.text = this.PantyNames[this.Selected];
		this.PantyDescLabel.text = this.PantyDescs[this.Selected];
		this.PantyBuffLabel.text = this.PantyBuffs[this.Selected];
		if (this.Selected == PlayerPrefs.GetInt("PantiesEquipped"))
		{
			this.ButtonLabel.text = "Equipped";
		}
		else
		{
			this.ButtonLabel.text = "Wear";
		}
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0004FB44 File Offset: 0x0004DD44
	public virtual void Main()
	{
	}

	// Token: 0x040009E3 RID: 2531
	public InputManagerScript InputManager;

	// Token: 0x040009E4 RID: 2532
	public HomeYandereScript HomeYandere;

	// Token: 0x040009E5 RID: 2533
	public HomeCameraScript HomeCamera;

	// Token: 0x040009E6 RID: 2534
	public HomeWindowScript HomeWindow;

	// Token: 0x040009E7 RID: 2535
	private GameObject NewPanties;

	// Token: 0x040009E8 RID: 2536
	public UILabel PantyNameLabel;

	// Token: 0x040009E9 RID: 2537
	public UILabel PantyDescLabel;

	// Token: 0x040009EA RID: 2538
	public UILabel PantyBuffLabel;

	// Token: 0x040009EB RID: 2539
	public UILabel ButtonLabel;

	// Token: 0x040009EC RID: 2540
	public Transform PantyParent;

	// Token: 0x040009ED RID: 2541
	public bool DestinationReached;

	// Token: 0x040009EE RID: 2542
	public float TargetRotation;

	// Token: 0x040009EF RID: 2543
	public float Rotation;

	// Token: 0x040009F0 RID: 2544
	public int TotalPanties;

	// Token: 0x040009F1 RID: 2545
	public int Selected;

	// Token: 0x040009F2 RID: 2546
	private int ID;

	// Token: 0x040009F3 RID: 2547
	public GameObject[] PantyModels;

	// Token: 0x040009F4 RID: 2548
	public string[] PantyNames;

	// Token: 0x040009F5 RID: 2549
	public string[] PantyDescs;

	// Token: 0x040009F6 RID: 2550
	public string[] PantyBuffs;
}
